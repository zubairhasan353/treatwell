using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class LogInDetails
    {
        public int Id { get; set; }

        [Required]
        public string Website { get; set; }
    }
}