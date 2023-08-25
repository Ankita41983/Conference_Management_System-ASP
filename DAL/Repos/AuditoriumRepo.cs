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
    internal class AuditoriumRepo : Repo, IRepo<Auditorium, int, bool>
    {
        public bool Add(Auditorium obj)
        {
            db.Auditoriums.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool DELETE(int id)
        {
            var auditorium = Get(id);
            db.Auditoriums.Remove(auditorium);
            return db.SaveChanges() > 0;
        }


        public List<Auditorium> Get()
        {
            return db.Auditoriums.ToList();
        }

        public Auditorium Get(int id)
        {
            return db.Auditoriums.Find(id);
        }

        public bool Update(Auditorium obj)
        {
            var aud = Get(obj.Id);
            db.Entry(aud).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public List<Auditorium> AudByVenue()
        {
            var auditorium = (from a in db.Auditoriums
                              select a).ToList();
            return auditorium;
        }
    }
}
