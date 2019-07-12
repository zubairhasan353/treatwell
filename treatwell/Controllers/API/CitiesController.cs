using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using treatwell.Models;

namespace treatwell.Controllers.API
{
    public class CitiesController : ApiController
    {
        private ApplicationDbContext _context;
        public CitiesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: api/Cities
        public IEnumerable<Cities> Get()
        {
            var cities = _context.Cities.ToList();
            return cities;
        }

        // GET: api/Cities/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cities
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cities/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cities/5
        public void Delete(int id)
        {
        }
    }
}
