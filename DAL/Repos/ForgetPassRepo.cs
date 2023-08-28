using DAL.EF.Models;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ForgetPassRepo
    {
        public static bool SetOTP(PassOTP obj)
        {
            var db = new CTSContext();
            db.PassOTPs.Add(obj);
            return db.SaveChanges() > 0;
        }
    }
}
