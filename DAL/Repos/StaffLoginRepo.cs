using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StaffLoginRepo : Repo, IStaffAuth
    {
        public StaffLogin Authenticate(string email, string pass)
        {
            var user = from u in db.Logins
                       where u.Email.Equals(email)
                       && u.Password.Equals(pass)
                       select u;
            if (user != null) return user.SingleOrDefault();
            return null;
        }
    }
}
