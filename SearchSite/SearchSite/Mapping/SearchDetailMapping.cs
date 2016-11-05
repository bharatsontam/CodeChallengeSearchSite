using SearchSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SearchSite.Mapping
{
    public class SearchDetailMapping : EntityTypeConfiguration<SearchDetail>
    {
        public SearchDetailMapping()
        {
            HasKey(s => s.Id);

            Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(s => s.CheckIn);
            Property(s => s.CheckOut);
            Property(s => s.Location);
            Property(s => s.RoomsCount);

            ToTable("SearchDetails");
        }
    }
}