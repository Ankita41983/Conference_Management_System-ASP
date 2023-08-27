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

        [Required(ErrorMessage = "Name should not be empty!")]
        public string Name { get; set; }

        [ForeignKey("Venue")]
        public int Venue_id { get; set; }
        public virtual Venue Venue { get; set; }

        [Required(ErrorMessage = "Capacity should not be empty!")]
        public int Capacity { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
        public Auditorium()
        {
            Seats = new List<Seat>();
        }
    }
}

