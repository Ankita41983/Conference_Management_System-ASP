using DAL.Interface;
using DAL.Models;
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
            db.Venues.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool DELETE(int id)
        {
            var venue = Get(id);
            db.Venues.Remove(venue);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
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
            var venue = (from v in db.Venues
                              where v.Id == obj.Id
                              select v).SingleOrDefault();

            venue.Name = obj.Name;
            venue.Location = obj.Location;
            venue.Capacity = obj.Capacity;
            return db.SaveChanges() > 0;
        }
    }
}
