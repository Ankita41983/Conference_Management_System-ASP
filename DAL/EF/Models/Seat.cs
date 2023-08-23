using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Seat
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Row { get; set; }
        [Required]
        public bool Type { get; set; }
        [ForeignKey("Staff")]
        public int Staff_id { get; set; }
        public virtual Staff Staff { get; set; }

    }
}
