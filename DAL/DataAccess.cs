﻿using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        public static IRepo<Auditorium, int, bool> AuditoriumData()
        {
            return new AuditoriumRepo();
        }

        public static IRepo<Seat, int, bool> SeatData()
        {
            return new SeatRepo();
        }

        public static IRepo<Staff, int, bool> StaffData()
        {
            return new StaffRepo();
        }
        public static IRepo<Venue, int, bool> VenueData()
        {
            return new VenueRepo();
        }
        public static IStaffAuth AuthData()
        {
            return new StaffLoginRepo();
        }
        public static IRepo<StaffToken, int, StaffToken> TokensData()
        {
            return new StaffTokenRepo();
        }
    }
}
