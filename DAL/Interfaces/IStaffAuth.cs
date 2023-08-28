using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStaffAuth
    {
        StaffLogin Authenticate(string email, string pass);
    }
}
