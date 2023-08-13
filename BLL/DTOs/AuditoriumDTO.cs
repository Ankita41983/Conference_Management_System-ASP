using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
   public class AuditoriumDTO
    {
        public int Id { get; set; }

        [Required]
        public int Venue_id { get; set; }

        [Required]
        [MinLength(0)]
        public int Capacity  { get; set; }

    }
}
