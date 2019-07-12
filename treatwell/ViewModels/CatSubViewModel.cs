using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;

namespace treatwell.ViewModels
{
    public class CatSubViewModel
    {
        public Categories category { get; set; }
        public List<SubCategories> subCategories { get; set; }
    }
}