using eTemple.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTemple.Data.Repositories
{
    public class TransactionTypeRepository : IRepository<TransactionType>
    {
        private eTempleDbDB TempleDb;

        public TransactionTypeRepository()
        {
            TempleDb = new eTempleDbDB();
        }

        public void Add(TransactionType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TransactionType entity)
        {
            throw new NotImplementedException();
        }

        public TransactionType FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionType> GetAllAsQuerable()
        {
            return TempleDb.Query<TransactionType>("Select * From transactiontype order by Id asc").ToList();
        }

        public IEnumerable<TransactionType> GetAllAsQuerable(int transId)
        {
            return TempleDb.Query<TransactionType>("Select * From transactiontype where Id = " + transId + " order by Name asc").ToList();
        }

        public void Update(TransactionType entity)
        {
            throw new NotImplementedException();
        }
    }
}
