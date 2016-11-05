using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchSite.Models
{
    public class SearchDetail
    {
        [Key]
        public Guid Id { get; set; }

        public string Location { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int RoomsCount { get; set; }
    }
}