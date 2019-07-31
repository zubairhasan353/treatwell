using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class Venues : BaseClass
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Venue Name")]
        public string VenueName { get; set; }

        [Required]
        public string Address { get; set; }
        public string Street { get; set; }
        public string Sector { get; set; }
        
        public Cities City { get; set; }
        public int CityId { get; set; }

        [Required]
        public string Introduction { get; set; }

        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }
    }
}