using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;

namespace treatwell.Dtos
{
    public class BookingDaysTimeDto
    {
        public int Id { get; set; }

        public DaysDto Day { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public int IntervalinMinutes { get; set; }
    }
}