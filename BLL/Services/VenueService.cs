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
    public class VenueService
    {
        public static List<VenueDTO> Get()
        {
            var data = DataAccess.VenueData().Get();
            var map = MapperService<Venue, VenueDTO>.GetMapper();
            return map.Map<List<VenueDTO>>(data);
        }

        public static VenueDTO Get(int id)
        {
            var data = DataAccess.VenueData().Get(id);
            var map = MapperService<Venue, VenueDTO>.GetMapper();
            return map.Map<VenueDTO>(data);
        }

        public static bool Add(VenueDTO venue)
        {
            var mapper = MapperService<VenueDTO, Venue>.GetMapper();
            var map = mapper.Map<Venue>(venue);
            return DataAccess.VenueData().Add(map);
        }

        public static bool Update(VenueDTO venue)
        {
            var mapper = MapperService<VenueDTO, Venue>.GetMapper();
            var map = mapper.Map<Venue>(venue);
            return DataAccess.VenueData().Update(map);
        }

        public static bool Delete(int id)
        {
            return DataAccess.VenueData().Delete(id);
        }
    }
}
