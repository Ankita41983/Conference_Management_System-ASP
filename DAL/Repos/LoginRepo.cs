using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LoginRepo : Repo, IAuth<object, Login>
    {
        public object Authenticate(Login data)
        {
            var user = (from login in db.Logins
                        where login.Email == data.Email && login.Password == data.Password
                        select login).SingleOrDefault();

            if (user != null)
            {
                var staff = (from s in db.Staffs
                             where s.Email == user.Email
                             select new
                             {
                                 s.Id, s.Name, s.Email, s.Gender, s.Phone, s.Address, s.Venue_id
                             }).SingleOrDefault();

                return new { staff = staff, message = "Login Successfull", status = true };
            }

            else
                return new { staff = "Null", message = "User email or password incorrect", status = false };
        }
    }
}
