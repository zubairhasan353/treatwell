using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class EmployeeAbsent : BaseClass
    {
        public int Id { get; set; }
        
        public ApplicationUser Employee { get; set; }
        public string EmployeeId { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Absent On")]
        public DateTime AbsentOn { get; set; }
    }
}