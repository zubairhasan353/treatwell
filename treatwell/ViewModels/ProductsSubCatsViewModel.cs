using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;

namespace treatwell.ViewModels
{
    public class ProductsSubCatsViewModel
    {
        public IEnumerable<Products> Products { get; set; }
        public IEnumerable<SubCategories> SubCat { get; set; }
        public ProdsUsedInSubCat Psc { get; set; }
    }
}