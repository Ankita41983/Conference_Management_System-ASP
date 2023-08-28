using DAL.EF.Models;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace DAL.Repos
{
    public class ForgetPassRepo
    {
        public static bool SetOTP(string email)
        {
            var db = new CTSContext();
            var staff = (from s in db.Staffs
                         where s.Email == email
                         select s).SingleOrDefault();

            if (staff != null)
            {
                System.Random random = new System.Random();
                int OTP = random.Next(10000, 99999);

                string fromMail = "ankita.saha41983@gmail.com";
                string fromPassword = "vtxeuorovryfepqg";

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromMail);
                message.Subject = "Forget Password for CMS";
                message.To.Add(new MailAddress(staff.Email));
                message.Body = "<html><body> Your OTP for reser password is <br><h2>" + OTP + "</h2> <br><br>Copyright 2023, Conference Management System </body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                smtpClient.Send(message);

                var pass = new PassOTP();
                pass.Email = email;
                pass.OTP = OTP;
                db.PassOTPs.Add(pass);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public static bool Varify(int OTP, string Password)
        {
            var db = new CTSContext();
            var isValidUser = (from data in db.PassOTPs
                               where data.OTP == OTP
                               select data).SingleOrDefault();

            var staff = (from s in db.Staffs
                         where isValidUser.Email == s.Email
                         select s).SingleOrDefault();

            if (isValidUser != null)
            {
                staff.Password = Password;
                db.SaveChanges();

                db.PassOTPs.Remove(isValidUser);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
