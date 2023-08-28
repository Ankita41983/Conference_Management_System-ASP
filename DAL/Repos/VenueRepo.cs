using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class VenueRepo : Repo, IRepo<Venue, int, bool>
    {
        public bool Add(Venue obj)
        {
            obj.Capacity = 0;
            db.Venues.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var venue = Get(id);
            db.Venues.Remove(venue);
            return db.SaveChanges() > 0;
        }

        

        public List<Venue> Get()
        {
            return db.Venues.ToList();
        }

        public Venue Get(int id)
        {
            return db.Venues.Find(id);
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Venue obj)
        {
            var venue = Get(obj.Id);
            db.Entry(venue).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
