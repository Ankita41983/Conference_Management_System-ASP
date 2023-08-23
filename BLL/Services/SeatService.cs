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
    public class SeatService
    {
        public static List<SeatDTO> Get()
        {
            var data = DataAccess.SeatData().Get();
            var map = MapperService<Seat, SeatDTO>.GetMapper();
            return map.Map<List<SeatDTO>>(data);
        }

        public static SeatDTO Get(int id)
        {
            var data = DataAccess.SeatData().Get(id);
            var map = MapperService<Seat, SeatDTO>.GetMapper();
            return map.Map<SeatDTO>(data);
        }

        
        }
    }
