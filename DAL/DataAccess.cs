using DAL.Interface;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class DataAccess
    {
        public static IRepo<Venue, int, bool> VenueData() {
            return new VenueRepo();
        }
        public static IRepo<Auditorium, int, bool> AuditoriumData()
        {
            return new AuditoriumRepo();
        }

        public static object CommentData()
        {
            throw new NotImplementedException();
        }
    }
}

