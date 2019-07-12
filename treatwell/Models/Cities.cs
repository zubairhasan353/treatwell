using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class Cities
    {
        public int Id { get; set; }

        [Display(Name = "City")]
        public string CityName { get; set; }
        public string PostalCode { get; set; }
    }
}