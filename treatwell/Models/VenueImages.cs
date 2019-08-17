using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace treatwell.Models
{
    public class VenueImages : BaseClass
    {
        public int Id { get; set; }

        public Venues Venues { get; set; }
        public int VenuesId { get; set; }

        [Display(Name = "Path")]
        public string ImagePath { get; set; }
    }
}