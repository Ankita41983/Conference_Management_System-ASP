using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal interface IPass<RET>
    {
        RET ChangePassword(string oldPassword, string newPassword, string rePassword);
    }
}
