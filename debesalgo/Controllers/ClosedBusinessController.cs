using debesalgo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace debesalgo.Controllers
{
    public class ClosedBusinessResponse
    {
        public List<ClosedBusiness> Businesses { set; get; }
        public List<string> TownTags { set; get; }
    }

    public class ClosedBusinessController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ClosedBusiness    
        public ActionResult Index(string tag = null)
        {
            if (tag == null)
            {
                var listOfItems = db.ClosedBusinesses.ToList();
                var tags = db.Tags.Where(s => s.Type == "Town").Select(s => s.Name).Distinct().ToList();
                var response = new ClosedBusinessResponse
                {
                    Businesses = listOfItems,
                    TownTags = tags
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allTags = db.Tags.Where(s => s.Type == "Town");
                var tags = allTags.Select(s => s.Name).Distinct().ToList();
                var listOfItems = allTags.Where(s => s.Name == tag).Select(s => s.TaggedBusiness).ToList();
                var response = new ClosedBusinessResponse
                {
                    Businesses = listOfItems,
                    TownTags = tags
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
