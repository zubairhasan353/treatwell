using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class Categories : BaseClass
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string CatDesc { get; set; }
    }
}