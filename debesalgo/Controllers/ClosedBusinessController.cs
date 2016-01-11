using debesalgo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace debesalgo.Controllers
{    
    public class ClosedBusinessController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ClosedBusiness
        public ActionResult Index()
        {
            var listOfItems = db.ClosedBusinesses.ToList();            

            return Json(listOfItems, JsonRequestBehavior.AllowGet);
        }        
    }
}
