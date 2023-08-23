using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Auditorium
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Venue")]
        public int Venue_id { get; set; }
        public virtual Venue Venue { get; set; }



        [Required]
        public int Capacity { get; set; }
    }
}

