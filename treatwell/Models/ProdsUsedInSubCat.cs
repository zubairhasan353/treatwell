using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class ProdsUsedInSubCat : BaseClass
    {
        public int Id { get; set; }

        public Products Product { get; set; }
        public int ProductId { get; set; }

        public SubCategories SubCat { get; set; }
        public int SubCatId { get; set; }

        [Display(Name = "Quantity Used")]
        public int QtyUsed { get; set; }
    }
}