using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace treatwell.Models
{
    public class UserServices : BaseClass
    {
        public int Id { get; set; }

        public SubCategories subCategories { get; set; }
        public int subCategoriesId { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}