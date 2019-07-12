using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace treatwell.Models
{
    public class UserServices
    {
        public int Id { get; set; }

        public SubCategories subCategories { get; set; }
        public int subCategoriesId { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public ApplicationUser ApplicationUserCreatedBy { get; set; }
        public string ApplicationUserCreatedById { get; set; }
        public DateTime ApplicationUserCreatedDate { get; set; }

        public ApplicationUser ApplicationUserLastUpdatedBy { get; set; }
        public string ApplicationUserLastUpdatedById { get; set; }
        public DateTime ApplicationUserLastUpdatedDate { get; set; }
    }
}