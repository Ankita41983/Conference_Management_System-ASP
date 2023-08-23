using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class AuditoriumService
    {
        public static List<AuditoriumDTO> Get()
        {
            var data = DataAccess.AuditoriumData().Get();
            var map = MapperService<Auditorium, AuditoriumDTO>.GetMapper();
            return map.Map<List<AuditoriumDTO>>(data);
        }

        public static AuditoriumDTO Get(int id)
        {
            var data = DataAccess.AuditoriumData().Get(id);
            var map = MapperService<Auditorium, AuditoriumDTO>.GetMapper();
            return map.Map<AuditoriumDTO>(data);
        }

        public static bool Add(AuditoriumDTO Auditorium)
        {
            var mapper = MapperService<AuditoriumDTO, Auditorium>.GetMapper();
            var map = mapper.Map<Auditorium>(Auditorium);
            return DataAccess.AuditoriumData().Add(map);
        }

        public static bool Update(AuditoriumDTO Auditorium)
        {
            var mapper = MapperService<AuditoriumDTO, Auditorium>.GetMapper();
            var map = mapper.Map<Auditorium>(Auditorium);
            return DataAccess.AuditoriumData().Update(map);
        }

        public static bool Delete(int id)
        {
            return DataAccess.AuditoriumData().DELETE(id);
        }
    }
}
