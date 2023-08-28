using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class PassOTP
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public int OTP { get; set; }
    }
}
