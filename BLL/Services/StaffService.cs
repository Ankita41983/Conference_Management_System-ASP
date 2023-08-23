using BLL.DTOs;
using DAL;
using DAL.EF.Models;
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
            return DataAccess.StaffData().DELETE(id);
        }
    }
}
