using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ConferenceDate { get; set; }
        
        public string  BookingDate { get; set; }
        [Required]
        public bool Status { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual  User User { get; set; }
    }
}
