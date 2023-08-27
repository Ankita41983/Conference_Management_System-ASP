using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StaffRepo : Repo, IRepo<Staff, int, bool>, IPass<bool>
    {
        public bool Add(Staff obj)
        {
            var login = new Login();
            login.Email = obj.Email;
            login.Password = obj.Password;
            db.Logins.Add(login);
            db.SaveChanges();

            db.Staffs.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool ChangePassword(string oldPassword, string newPassword, string rePassword)
        {
            
            /*var user = (from login in db.Logins
                        where login.Password == oldPassword
                        select login).sin*/
            return true;
        }

        public bool DELETE(int id)
        {
            var staff = Get(id);
            db.Staffs.Remove(staff);
            return db.SaveChanges() > 0;
        }

        public List<Staff> Get()
        {
            return db.Staffs.ToList();
        }

        public Staff Get(int id)
        {
            return db.Staffs.Find(id);
        }

        public bool Update(Staff obj)
        {
            var staff = Get(obj.Id);
            db.Entry(staff).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
