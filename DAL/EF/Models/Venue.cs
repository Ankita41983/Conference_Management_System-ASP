﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public int Capacity { get; set; }

        public virtual ICollection<Auditorium> Auditoriums { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
        public Venue()
        {
            Auditoriums = new List<Auditorium>();
            Staffs = new List<Staff>();
        }
    }
}
