using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class EmployeeAbsent
    {
        public int Id { get; set; }
        
        public ApplicationUser Employee { get; set; }
        public string EmployeeId { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Absent On")]
        public DateTime AbsentOn { get; set; }

        public ApplicationUser ApplicationUserCreatedBy { get; set; }
        public string ApplicationUserCreatedById { get; set; }
        public DateTime ApplicationUserCreatedDate { get; set; }

        public ApplicationUser ApplicationUserLastUpdatedBy { get; set; }
        public string ApplicationUserLastUpdatedById { get; set; }
        public DateTime ApplicationUserLastUpdatedDate { get; set; }
    }
}