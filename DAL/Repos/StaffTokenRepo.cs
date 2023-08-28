using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StaffTokenRepo : Repo, IRepo<StaffToken, int, StaffToken>
    {
        public StaffToken Create(StaffToken obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<StaffToken> Get()
        {
            return db.Tokens.ToList();
        }

        public StaffToken Get(int id)
        {
            throw new NotImplementedException();
        }

        public StaffToken Update(StaffToken obj)
        {
            throw new NotImplementedException();
        }
    }
}
