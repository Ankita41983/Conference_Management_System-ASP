using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }
        [Required]
        public string ConferenceDate { get; set; }

        public string BookingDate { get; set; }
        [Required]
        public bool Status { get; set; }
        public int UserId { get; set; }
    }
}

