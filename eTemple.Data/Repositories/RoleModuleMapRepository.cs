using eTemple.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace eTemple.Data.Repositories
{
    public class RoleModuleMapRepository : IRepository<rolemodulemappings>
    {
        private eTempleDbDB TempleDb;
        private DataSet dsreturnObj;
        string strConn = ConfigurationManager.ConnectionStrings["eTempleDb"].ConnectionString;

        public RoleModuleMapRepository()
        {
            TempleDb = new eTempleDbDB();
        }
        public void Add(rolemodulemappings entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(rolemodulemappings entity)
        {
            throw new NotImplementedException();
        }

        public rolemodulemappings FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<rolemodulemappings> GetAllAsQuerable()
        {
            return TempleDb.Query<rolemodulemappings>("Select * From rolemodulemapping order by Id asc").ToList();
        }

        public int isAuthorized(int role,int entitlement, string Module)
        {
            int count;
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                using (MySqlCommand cmd = new MySqlCommand("select count(1) as cnt from RoleModuleMapping where role=" + role + " and Entitlement=" + entitlement + " and module ='" + Module + "'", conn))
                {
                    conn.Open();
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return count;
        }

        public void Update(rolemodulemappings entity)
        {
            throw new NotImplementedException();
        }
    }
}
