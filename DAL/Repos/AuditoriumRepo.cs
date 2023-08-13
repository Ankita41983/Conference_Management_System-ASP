using DAL.Interface;
using DAL.Models;
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
            var auditorium = (from aud in db.Auditoriums
                              where aud.Id == obj.Id
                              select aud).SingleOrDefault();

            
            auditorium.Capacity = obj.Capacity;
            return db.SaveChanges() > 0;
        }
    }
}
