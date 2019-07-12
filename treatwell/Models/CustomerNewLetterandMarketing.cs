using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace treatwell.Models
{
    public class CustomerNewLetterandMarketing
    {
        public int Id { get; set; }

        public NewsLetterandMarketing NewsLetterandMarketing { get; set; }
        public int NewsLetterandMarketingId { get; set; }

        public DateTime EntryDate { get; set; }
    }
}