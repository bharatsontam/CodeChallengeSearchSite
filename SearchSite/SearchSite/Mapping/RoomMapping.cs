using SearchSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SearchSite.Mapping
{
    public class RoomMapping : EntityTypeConfiguration<Room>
    {
        public RoomMapping()
        {
            HasKey(r => r.Id);

            Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(r => r.SearchId).IsRequired();
            Property(r => r.Adults);
            Property(r => r.Children);

            ToTable("Rooms");
        }
    }
}