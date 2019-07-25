using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace treatwell.Dtos
{
    public class UserVenuesDto
    {
        public int Id { get; set; }

        public ApplicationUserDto User { get; set; }
    }
}