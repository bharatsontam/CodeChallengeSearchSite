using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchSite.Models
{
    public class SearchDetailViewModel
    {
        public SearchDetailViewModel()
        {
            this.RoomsList = new List<RoomViewModel>();
        }
        [DisplayName("Location")]
        [Required(ErrorMessage = "Please enter location")]
        public string Location { get; set; }
        [DisplayName("Check In")]
        [Required(ErrorMessage = "Please select check in date")]
        public DateTime? CheckIn { get; set; }
        [DisplayName("Check Out")]
        [Required(ErrorMessage = "Please select check out date")]
        public DateTime? CheckOut { get; set; }
        [DisplayName("Rooms Count")]
        [Required(ErrorMessage = "Please select rooms")]
        [Range(1, 9)]
        public int RoomsCount { get; set; }
        public IList<RoomViewModel> RoomsList { get; set; }
    }

    public class RoomViewModel
    {
        [DisplayName("Adults")]
        [Required(ErrorMessage = "Please select adults count")]
        public int Adults { get; set; }
        [DisplayName("Children")]
        [Required(ErrorMessage = "Please select children count")]
        public int Children { get; set; }
    }
}