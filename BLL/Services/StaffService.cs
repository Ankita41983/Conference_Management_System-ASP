using BLL.DTOs;
using DAL;
using DAL.EF;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// SOLID 

namespace BLL.Services
{
    public class StaffService
    {
        public static bool ForgetPass(PassOTP obj)
        {
            return ForgetPassRepo.SetOTP(obj);
        }

        public static bool Verify(ForgetPassDTO obj)
        {
            var db = new ConferenceContext();
            var isValidUser = (from data in db.PassOTPs
                           where data.OTP == obj.OTP
                           select data).SingleOrDefault();

            var staff = (from s in db.Staffs
                         where isValidUser.Email == s.Email
                         select s).SingleOrDefault();

            if (isValidUser != null)
            {
                staff.Password = obj.Password;
                db.SaveChanges();

                db.PassOTPs.Remove(isValidUser);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<StaffDTO> Get()
        {
            var data = DataAccess.StaffData().Get();// list of staff
            var map = MapperService<Staff, StaffDTO>.GetMapper();
            return map.Map<List<StaffDTO>>(data);
        }

        public static StaffDTO Get(int id)
        {
            var data = DataAccess.StaffData().Get(id);// list of staff
            var map = MapperService<Staff, StaffDTO>.GetMapper();
            return map.Map<StaffDTO>(data);
        }

        public static bool Add(StaffDTO staff)
        {
            var mapper = MapperService<StaffDTO, Staff>.GetMapper();
            var map = mapper.Map<Staff>(staff);
            return DataAccess.StaffData().Add(map);
        }

        public static bool Update(StaffDTO staff)
        {
            var mapper = MapperService<StaffDTO, Staff>.GetMapper();
            var map = mapper.Map<Staff>(staff);
            return DataAccess.StaffData().Update(map);
        }

        public static bool Delete(int id)
        {
            return DataAccess.StaffData().Delete(id);
        }
    }
}
