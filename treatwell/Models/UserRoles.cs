using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace treatwell.Models
{
    public class UserRoles
    {
        public ApplicationUser User { get; set; }
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        public ApplicationRole Role { get; set; }
        [Key]
        [Column(Order = 2)]
        public string RoleId { get; set; }
    }
}