using BugetBookSPA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BugetBookSPA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=BugetBookDb")
        {

        }
        public DbSet<Entry> Entries { get; set; }

    }
}