using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class NewsLetterandMarketing
    {
        public int Id { get; set; }

        [Required]
        public string Heading { get; set; }

        [Required]
        public string Desc { get; set; }
    }
}