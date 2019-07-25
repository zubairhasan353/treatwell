using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using treatwell.Models;

namespace treatwell.Dtos
{
    public class VenuesDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Venue Name")]
        public string VenueName { get; set; }

        [Required]
        public string Address { get; set; }
        public string Street { get; set; }
        public string Sector { get; set; }

        public CitiesDto City { get; set; }
        
        [Required]
        public string Introduction { get; set; }

        public string ContactNo { get; set; }

        public string ImagePath { get; set; }
    }
}