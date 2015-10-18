using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTemple.Data.Models;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;

namespace eTemple.Data.Repositories
{
    public class ServiceTypeRepository : IRepository<ServiceTypes>
    {
        string strConn = ConfigurationManager.ConnectionStrings["eTempleDb"].ConnectionString;
        private eTempleDbDB TempleDb;
        public ServiceTypeRepository()
        {
            TempleDb = new eTempleDbDB();
        }

        public IEnumerable<ServiceTypes> GetAllAsQuerable()
        {

            return TempleDb.Query<ServiceTypes>("Select * From ServiceTypes order by Id asc").ToList();

        }
        
        public DataTable GetAllasDataTable()
        {

            return TempleDb.ExecuteReader("SELECT id,Name,CAST(isdaterelated as CHAR(50)) as isdaterelated,Cost FROM servicetypes where id!=0 order by Id asc");

        }


        public IEnumerable<ServiceTypes> GetAllAsQuerable(int serviceTypeId)
        {

            return TempleDb.Query<ServiceTypes>("Select * From ServiceTypes where Id = " + serviceTypeId + " order by Name asc").ToList();

        }

        public string updateSvcInformation(ServiceTypes oServiceTypes)
        {
            string updateStatus = string.Empty;
            string commandText = "update ServiceTypes set Name=@Name,IsDateRelated=@IsDateRelated,cost=@cost,ModifiedBy=@ModifiedBy,ModifiedOn=@ModifiedOn WHERE Id = @Id";


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
                            cmd.Parameters.AddWithValue("@Id", oServiceTypes.Id);
                            cmd.Parameters.AddWithValue("@Name", oServiceTypes.Name);
                            cmd.Parameters.AddWithValue("@IsDateRelated", oServiceTypes.IsDateRelated);
                            cmd.Parameters.AddWithValue("@cost", oServiceTypes.Cost);
                            cmd.Parameters.AddWithValue("@ModifiedBy", oServiceTypes.ModifiedBy);
                            cmd.Parameters.AddWithValue("@ModifiedOn", oServiceTypes.ModifiedOn);

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

        public string DeleteService(string servId)
        {
            string deleteStatus = string.Empty;
            string commandText = "Delete from servicetypes WHERE Id = @Id";

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
                            cmd.Parameters.AddWithValue("@Id", servId);
                            cmd.ExecuteNonQuery();
                            deleteStatus = "Success";
                        }

                        trans.Commit();

                    }
                    catch (MySqlException ex)
                    {
                        trans.Rollback();
                        conn.Close();
                        deleteStatus = ex.ToString();
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
            return deleteStatus;
        }

        public string InsertEmployee(ServiceTypes oServiceTypes)
        {
            string insertStatus = string.Empty;
            string commandText = "INSERT INTO ServiceTypes(Id,Name,IsDateRelated,cost,CreatedBy,CreatedOn)VALUES(@Id,@Name,@IsDateRelated,@cost,@CreatedBy,@CreatedOn)";

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
                            cmd.Parameters.AddWithValue("@Id", oServiceTypes.Id);
                            cmd.Parameters.AddWithValue("@Name", oServiceTypes.Name);
                            cmd.Parameters.AddWithValue("@IsDateRelated", oServiceTypes.IsDateRelated);
                            cmd.Parameters.AddWithValue("@cost", oServiceTypes.Cost);
                            cmd.Parameters.AddWithValue("@CreatedBy", oServiceTypes.CreatedBy);
                            cmd.Parameters.AddWithValue("@CreatedOn", oServiceTypes.CreatedOn);
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

        public void Add(ServiceTypes entity)
        {
            TempleDb.Save(entity);
        }

        public void Delete(ServiceTypes entity)
        {
            throw new NotImplementedException();
        }

        public ServiceTypes FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(ServiceTypes entity)
        {
            TempleDb.Update(entity);
        }
    }
}
