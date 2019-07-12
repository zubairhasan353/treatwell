using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;
using System.Data.Entity;

namespace treatwell.ViewModels
{
    public class CatSubCatViewModel
    {
        public IEnumerable<Categories> categories { get; set; }
        public SubCategories subCategories { get; set; }
    }
}