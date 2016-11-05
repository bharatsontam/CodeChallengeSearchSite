using SearchSite.External;
using SearchSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchSite.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string message = "")
        {
            var model = new SearchDetailViewModel();
            if (message != "")
            {
                ViewBag.Message = message;
            }
            return View(model);
        }

        [Route("Search/LocationSearch")]
        [HttpPost]
        public ActionResult LocationSearch(string term)
        {
            var keywords = new List<string>();

            TeleportSearchEngine searchEngine = new TeleportSearchEngine();

            keywords = searchEngine.SearchLocation(term);

            return Json(keywords, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(SearchDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            using (DatabaseContext con = new DatabaseContext())
            {
                var searchDetail = new SearchDetail
                {
                    CheckIn = model.CheckIn,
                    CheckOut = model.CheckOut,
                    Location = model.Location,
                    RoomsCount = model.RoomsCount
                };
                con.SearchDetails.Add(searchDetail);
                con.SaveChanges();

                foreach (var roomDetail in model.RoomsList)
                {
                    var room = new Room
                    {
                        Adults = roomDetail.Adults,
                        Children = roomDetail.Children,
                        SearchId = searchDetail.Id
                    };
                    con.Rooms.Add(room);
                    con.SaveChanges();
                }
            }
            return RedirectToAction("Index", new { message = "You have saved your search." });
        }

        public ActionResult InsertRoomList(int count)
        {
            var roomList = new List<RoomViewModel>();
            for (int i = 0; i < count; i++)
            {
                roomList.Add(new RoomViewModel());
            }

            return PartialView("_RoomsList", roomList);
        }
    }
}