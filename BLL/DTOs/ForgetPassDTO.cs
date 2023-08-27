using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ForgetPassDTO
    {
        public string Email { set; get; }
        public string OTP { set; get; }
        public string Password { set; get; }
    }
}
