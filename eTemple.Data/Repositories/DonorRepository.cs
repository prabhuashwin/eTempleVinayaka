using eTemple.Data.Models;
using eTemple.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace eTemple.Data.Repositories
{
    public class DonorRepository : IRepository<Donors>
    {
        private eTempleDbDB TempleDb;
        private DataSet dsreturnObj;
        string strConn = ConfigurationManager.ConnectionStrings["eTempleDb"].ConnectionString;
        public DonorRepository()
        {
            TempleDb = new eTempleDbDB();
        }

        public IEnumerable<Donors> GetAllAsQuerable()
        {
            return TempleDb.Query<Donors>("Select * From donors").ToList();
        }

        public DataSet getMaxIdFromDonor(string id)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                using (MySqlCommand cmd = new MySqlCommand("select coalesce(MAX(CAST(replace(id,'" + id + "' ,'')AS SIGNED)), 0) as donroId from donors where id like '" + id + "%'", conn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        dsreturnObj = new DataSet();
                        da.Fill(dsreturnObj);
                    }
                }
            }
            return dsreturnObj;
        }

        public DataSet getMaxMRNoFromDonor()
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT coalesce(MAX(MR_No), 0) AS donroMRNo FROM donors", conn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        dsreturnObj = new DataSet();
                        da.Fill(dsreturnObj);
                    }
                }
            }
            return dsreturnObj;
        }

        public DataSet getCostbyId(string serviceID)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                using (MySqlCommand cmd = new MySqlCommand("select cost from servicetypes where id =" + serviceID, conn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        dsreturnObj = new DataSet();
                        da.Fill(dsreturnObj);
                    }
                }
            }
            return dsreturnObj;
        }

        public DataSet getTotalAmountpbySVC(string frmDate,string toDate)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                using (MySqlCommand cmd = new MySqlCommand("select st.Name as ServiceType,sum(d.amount) as Amount,count(1) as cnt,st.cost as cost from donors d  inner join servicetypes st on d.ServiceTypeId=st.id where d.DonorDate BETWEEN '" + frmDate + "' AND '" + toDate + "' group by d.ServiceTypeId", conn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        dsreturnObj = new DataSet();
                        da.Fill(dsreturnObj);
                    }
                }
            }
            return dsreturnObj;
        }
        public DataSet getServiceReport(string serviceType, string DonorDate)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                using (MySqlCommand cmd = new MySqlCommand(@"select d.id as TicketID,MR_No as ReceiptID,ServiceTypeId as ServiceID,gothram,donorname as DevoteeName,Amount,case datetypeid when 0 then '' when 1 then concat(m.name,' ',t.Name) when 2 then performDate else s.name end as performDate,
                    DATE_FORMAT(date(donordate),'%d-%m-%Y') as createdon,doorno as dno,Mandal,city ,districtname, state as statename,pin as pin,
                    Occasion as OtherDetails, mobile as PhoneNumber, tt.name as TransactionType
                    from donors d
                    inner join month m on m.Id=donormonth
                    inner join thidhi t on t.id =thidhi
                    inner join specialday s on s.id=specialDayid
                    inner join TransactionType tt on tt.id= TransactionTypeid
                    where Donordate='" + DonorDate + "' and servicetypeid=" + serviceType + " order by MR_No", conn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        dsreturnObj = new DataSet();
                        da.Fill(dsreturnObj);
                    }
                }
            }
            return dsreturnObj;
        }

        public DataSet getServiceReportByEmployee(string CreatedBy, string DonorDate)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                using (MySqlCommand cmd = new MySqlCommand(@"SELECT st.Name as servicename,sum(d.Amount) as totalcollection,count(1) as totalquantity,d.createdby FROM donors d
                            inner join servicetypes st on d.ServiceTypeId=st.Id  where d.createdby=" + CreatedBy + " and d.donordate='" + DonorDate + "' group by d.createdby,d.ServiceTypeId", conn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        dsreturnObj = new DataSet();
                        da.Fill(dsreturnObj);
                    }
                }
            }
            return dsreturnObj;
        }

        public Donors checkModifyDonorIDExists(string chkId)
        {
            var donors = TempleDb.SingleOrDefault<Donors>("Select * from Donors where Id=@0", chkId);
            if (donors != null && donors.Id != null)
            {
                return donors;
            }
            else
            {
                return null;
            }
        }

        public Donors checkModifyDonorNameExists(string chkName)
        {
            var donors = TempleDb.SingleOrDefault<Donors>("Select * from Donors where DonorName=@0", chkName);
            if (donors != null && donors.DonorName != null)
            {
                return donors;
            }
            else
            {
                return null;
            }
        }

        public Donors checkModifyMRNoExists(string chkMRNo)
        {
            var donors = TempleDb.SingleOrDefault<Donors>("Select * from Donors where MR_No=@0", chkMRNo);
            if (donors != null && donors.MR_No != string.Empty)
            {
                return donors;
            }
            else
            {
                return null;
            }
        }

        public Donors fetchDataFromMobileNumber(string chkMobile)
        {
            var donors = TempleDb.SingleOrDefault<Donors>("Select D.*,max(cast(d.mr_no as SIGNED)) from Donors d  where Mobile=@0 group by Mobile", chkMobile);
            if (donors != null && donors.MR_No != string.Empty)
            {
                return donors;
            }
            else
            {
                return null;
            }
        }

        public string insertDonorInformation(Donors donor)
        {
            string insertStatus = string.Empty;
            string commandText = "INSERT INTO donors(Id,Donordate,Surname,DonorName,DistrictName,City,Pin,State,Country,NameOn,Star,Occasion,Gothram,Amount,MR_No,Remarks,Landline,SpecialDayId,ServiceTypeId,ServiceNameId,DateTypeId,PerformDate,EmailId,DonorMonth,Thidhi,DonorDay,Mobile,DonorThithi,DoorNo,Mandal,TransactionTypeId,TransactionID,TransactionDate,CreatedBy)VALUES(@Id, @Donordate,@Surname,@DonorName,@DistrictName,@City,@Pin,@State,@Country,@NameOn,@Star,@Occasion,@Gothram,@Amount,@MR_No,@Remarks,@Landline,@SpecialDayId,@ServiceTypeId,@ServiceNameId,@DateTypeId,@PerformDate,@EmailId,@DonorMonth,@Thidhi,@DonorDay,@Mobile,@DonorThithi,@DoorNo,@Mandal,@TransactionTypeId,@TransactionID,@TransactionDate,@CreatedBy)";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand(commandText, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Id", donor.Id);
                            cmd.Parameters.AddWithValue("@Donordate", donor.Donordate);
                            
                            cmd.Parameters.AddWithValue("@Surname", donor.Surname.NullString());
                            cmd.Parameters.AddWithValue("@DonorName", donor.DonorName.NullString());
                            cmd.Parameters.AddWithValue("@DistrictName", donor.DistrictName.NullString());
                            cmd.Parameters.AddWithValue("@City", donor.City.NullString());
                            cmd.Parameters.AddWithValue("@Pin", donor.Pin.NullString());
                            cmd.Parameters.AddWithValue("@State", donor.State.NullString());
                            cmd.Parameters.AddWithValue("@Country", donor.Country.NullString());
                            cmd.Parameters.AddWithValue("@NameOn", donor.NameOn);
                            cmd.Parameters.AddWithValue("@Star", donor.Star);
                            cmd.Parameters.AddWithValue("@Occasion", donor.Occasion);
                            cmd.Parameters.AddWithValue("@Gothram", donor.Gothram.NullString());
                            cmd.Parameters.AddWithValue("@Amount", donor.Amount);
                            cmd.Parameters.AddWithValue("@MR_No", donor.MR_No.NullString());
                            cmd.Parameters.AddWithValue("@Remarks", donor.Remarks.NullString());
                            cmd.Parameters.AddWithValue("@Landline", donor.Landline.NullString());
                            cmd.Parameters.AddWithValue("@SpecialDayId", donor.SpecialDayId);
                            cmd.Parameters.AddWithValue("@ServiceTypeId", donor.ServiceTypeId);
                            cmd.Parameters.AddWithValue("@ServiceNameId", donor.ServiceNameId);
                            cmd.Parameters.AddWithValue("@DateTypeId", donor.DateTypeId);
                            cmd.Parameters.AddWithValue("@PerformDate", donor.PerformDate.NullString());
                            cmd.Parameters.AddWithValue("@EmailId", donor.EmailId.NullString());
                            cmd.Parameters.AddWithValue("@DonorMonth", donor.DonorMonth);
                            cmd.Parameters.AddWithValue("@Thidhi", donor.Thidhi);
                            cmd.Parameters.AddWithValue("@DonorDay", donor.DonorDay);
                            cmd.Parameters.AddWithValue("@Mobile", donor.Mobile.NullString());
                            cmd.Parameters.AddWithValue("@DonorThithi", donor.DonorThithi);
                            cmd.Parameters.AddWithValue("@DoorNo", donor.DoorNo.NullString());
                            cmd.Parameters.AddWithValue("@Mandal", donor.Mandal.NullString());
                            cmd.Parameters.AddWithValue("@TransactionTypeId", donor.TransactionTypeId);
                            cmd.Parameters.AddWithValue("@TransactionID", donor.TransactionId.NullString());
                            cmd.Parameters.AddWithValue("@TransactionDate", donor.TransactionDate.NullString());
                            cmd.Parameters.AddWithValue("@CreatedBy", donor.CreatedBy);

                            cmd.ExecuteNonQuery();
                            insertStatus = "Success";
                        }

                        trans.Commit();

                    }
                    catch (MySqlException ex)
                    {
                        trans.Rollback();
                        conn.Close();
                        insertStatus = ex.ToString();
                    }

                    finally
                    {
                        if (conn != null)
                        {
                            conn.Close();
                        }
                    }
                }
            }
            return insertStatus;
        }



        public string updateDonorInformation(Donors donor)
        {
            string updateStatus = string.Empty;
            string commandText = "update donors set Donordate=@Donordate,DonorName=@DonorName,DistrictName=@DistrictName,City=@City,Pin=@Pin,State=@State,NameOn=@NameOn,Star=@Star,Occasion=@Occasion,Gothram=@Gothram,Amount=@Amount,MR_No=@MR_No,Remarks=@Remarks,Landline=@Landline,SpecialDayId=@SpecialDayId,ServiceTypeId=@ServiceTypeId,ServiceNameId=@ServiceNameId,DateTypeId=@DateTypeId,PerformDate=@PerformDate,EmailId=@EmailId,DonorMonth=@DonorMonth,Thidhi=@Thidhi,DonorDay=@DonorDay,Mobile=@Mobile,DonorThithi=@DonorThithi,DoorNo=@DoorNo,Mandal=@Mandal,TransactionTypeId=@TransactionTypeId,TransactionID=@TransactionID,TransactionDate=@TransactionDate,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate WHERE Id = @Id";


            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand(commandText, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Id", donor.Id);
                            cmd.Parameters.AddWithValue("@Donordate", donor.Donordate);
                            
                            cmd.Parameters.AddWithValue("@DonorName", donor.DonorName.NullString());
                            cmd.Parameters.AddWithValue("@DistrictName", donor.DistrictName.NullString());
                            cmd.Parameters.AddWithValue("@City", donor.City.NullString());
                            cmd.Parameters.AddWithValue("@Pin", donor.Pin.NullString());
                            cmd.Parameters.AddWithValue("@State", donor.State.NullString());
                           
                            cmd.Parameters.AddWithValue("@NameOn", donor.NameOn);
                            cmd.Parameters.AddWithValue("@Star", donor.Star);
                            cmd.Parameters.AddWithValue("@Occasion", donor.Occasion);
                            cmd.Parameters.AddWithValue("@Gothram", donor.Gothram.NullString());
                            cmd.Parameters.AddWithValue("@Amount", donor.Amount);
                            cmd.Parameters.AddWithValue("@MR_No", donor.MR_No.NullString());
                            cmd.Parameters.AddWithValue("@Remarks", donor.Remarks.NullString());
                            cmd.Parameters.AddWithValue("@Landline", donor.Landline.NullString());
                            cmd.Parameters.AddWithValue("@SpecialDayId", donor.SpecialDayId);
                            cmd.Parameters.AddWithValue("@ServiceTypeId", donor.ServiceTypeId);
                            cmd.Parameters.AddWithValue("@ServiceNameId", donor.ServiceNameId);
                            cmd.Parameters.AddWithValue("@DateTypeId", donor.DateTypeId);
                            cmd.Parameters.AddWithValue("@PerformDate", donor.PerformDate.NullString());
                            cmd.Parameters.AddWithValue("@EmailId", donor.EmailId.NullString());
                            cmd.Parameters.AddWithValue("@DonorMonth", donor.DonorMonth);
                            cmd.Parameters.AddWithValue("@Thidhi", donor.Thidhi);
                            cmd.Parameters.AddWithValue("@DonorDay", donor.DonorDay);
                            cmd.Parameters.AddWithValue("@Mobile", donor.Mobile.NullString());
                            cmd.Parameters.AddWithValue("@DonorThithi", donor.DonorThithi);
                            cmd.Parameters.AddWithValue("@DoorNo", donor.DoorNo.NullString());
                            cmd.Parameters.AddWithValue("@Mandal", donor.Mandal.NullString());
                            cmd.Parameters.AddWithValue("@TransactionTypeId", donor.TransactionTypeId);
                            cmd.Parameters.AddWithValue("@TransactionID", donor.TransactionId.NullString());
                            cmd.Parameters.AddWithValue("@TransactionDate", donor.TransactionDate.NullString());
                            cmd.Parameters.AddWithValue("@ModifiedBy", donor.ModifiedBy);
                            cmd.Parameters.AddWithValue("@ModifiedDate", donor.ModifiedDate);

                            cmd.ExecuteNonQuery();
                            updateStatus = "Success";
                        }

                        trans.Commit();

                    }
                    catch (MySqlException ex)
                    {
                        trans.Rollback();
                        conn.Close();
                        updateStatus = ex.ToString();
                    }

                    finally
                    {
                        if (conn != null)
                        {
                            conn.Close();
                        }
                    }
                }
            }
            return updateStatus;
        }


        public DataTable GetAllasDataTable()
        {
            return TempleDb.ExecuteReader("Select * From donors order by DonorName asc");
        }

        public void Add(Donors entity)
        {
            //TempleDb.Save(entity);
            TempleDb.Insert("Donors", "Id", true, entity);
        }

        public void Delete(Donors entity)
        {
            throw new NotImplementedException();
        }

        public Donors FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Donors entity)
        {
            TempleDb.Update(entity);
        }

        public IEnumerable<Donors> GetCityVillageAsQuerable()
        {
            return TempleDb.Query<Donors>("SELECT distinct city FROM donors").ToList();
        }

        public IEnumerable<Donors> GetMandalAsQuerable()
        {
            return TempleDb.Query<Donors>("SELECT distinct Mandal FROM donors").ToList();
        }

        public IEnumerable<Donors> GetDistrictAsQuerable()
        {
            return TempleDb.Query<Donors>("SELECT distinct DistrictName FROM donors").ToList();
        }
    }
}
