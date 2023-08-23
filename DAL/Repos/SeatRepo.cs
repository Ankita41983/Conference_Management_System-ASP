using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SeatRepo : Repo, IRepo<Seat, int, bool>
    {
        public bool Add(Seat obj)
        {
            db.Seats.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool DELETE(int id)
        {
            var seat = Get(id);
            db.Seats.Remove(seat);
            return db.SaveChanges() > 0;
        }


        public List<Seat> Get()
        {
            return db.Seats.ToList();
        }

        public Seat Get(int id)
        {
            return db.Seats.Find(id);
        }

        public bool Update(Seat obj)
        {
            var St = Get(obj.Id);
            db.Entry(St).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
