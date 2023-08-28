using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class CTSContext: DbContext
    {
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<StaffLogin> Logins { get; set; }
        public DbSet<PassOTP> PassOTPs { get; set; }
        public DbSet<StaffToken> Tokens { get; set; }
    }
}
