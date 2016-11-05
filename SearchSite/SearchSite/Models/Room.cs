using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchSite.Models
{
    public class Room
    {
        [Key]
        public Guid Id { get; set; }

        public Guid SearchId { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
    }
}