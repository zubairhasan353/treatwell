using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class Days
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Day")]
        public string DayName { get; set; }
    }
}