using BugetBookSPA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BugetBookSPA.Controllers
{
    public class EntriesController : ApiController
    {
        public IHttpActionResult GetEntries()
        {
            try
            {
                //"Uing" Open connection once everything below in the bracket is done.
                using (var context = new AppDbContext())
                {
                    var entries = context.Entries.ToList();
                    return Ok(entries);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
