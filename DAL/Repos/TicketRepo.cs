using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TicketRepo : Repo, IRepo<Ticket, int, bool>
    {
        public bool Add(Ticket obj)
        {
            throw new NotImplementedException();
        }

        public bool DELETE(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> Get()
        {
            throw new NotImplementedException();
        }

        public Ticket Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ticket obj)
        {
            throw new NotImplementedException();
        }
    }
}
