using SearchSite.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SearchSite.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("SearchSiteConnection")
        {

        }

        public virtual DbSet<SearchDetail> SearchDetails { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SearchDetailMapping());
            modelBuilder.Configurations.Add(new RoomMapping());
        }
    }
}