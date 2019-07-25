using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Dtos
{
    public class SubCategoriesDto
    {
        public int Id { get; set; }
        public string SubCatDesc { get; set; }

        [Display(Name = "Time in Minutes")]
        public int TimeInMinutes { get; set; }
    }
}