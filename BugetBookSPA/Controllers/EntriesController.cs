using BugetBookSPA.Data;
using BugetBookSPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BugetBookSPA.Controllers
{
    [EnableCors(origins:"http://localhost:4200", headers: "*", methods: "*")]
    public class EntriesController : ApiController
    {
        [HttpGet]
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

        [HttpPost]
        public IHttpActionResult PostEntries([FromBody]Entry entry)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Entries.Add(entry);
                    context.SaveChanges();

                    return Ok("Entry is created!");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IHttpActionResult UpdateEntry(int id, [FromBody]Entry entry)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != entry.Id) return BadRequest();
            try
            {
                using (var context = new AppDbContext())
                {
                    var oldEntry = context.Entries.FirstOrDefault(n => n.Id == id);
                    if (oldEntry == null) return NotFound();
                    oldEntry.Description = entry.Description;
                    oldEntry.IsExpense = entry.IsExpense;
                    oldEntry.Value = entry.Value;

                    context.SaveChanges();
                    return Ok("Entry Updated");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
