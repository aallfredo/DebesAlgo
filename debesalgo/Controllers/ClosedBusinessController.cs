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
        public ActionResult Index()
        {
            var listOfItems = db.ClosedBusinesses.ToList();
            var tags = db.Tags.Where(s=>s.Type == "Town").Select(s=>s.Name).Distinct().ToList();
            var response = new ClosedBusinessResponse
            {
                Businesses = listOfItems,
                TownTags = tags
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }        
    }
}
