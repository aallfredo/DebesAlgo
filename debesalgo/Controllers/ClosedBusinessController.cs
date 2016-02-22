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
        public Dictionary<string, decimal> SummaryOfDebtPerTowns { get; internal set; }
        public List<string> TownTags { set; get; }
    }

    public class ClosedBusinessController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ClosedBusiness    
        public ActionResult Index(string tag = null, string search =null)
        {
            var allTags = db.Tags.Where(s => s.Type == "Town");
            var tags = allTags.Select(s => s.Name).Distinct().ToList();
            List<ClosedBusiness> listOfItems;
            if (!string.IsNullOrWhiteSpace(search))
            {
                listOfItems = db.ClosedBusinesses.Where(s => s.Details.ToLower().Contains(search.ToLower()) || s.Name.ToLower().Contains(search.ToLower())|| s.Address.ToLower().Contains(search.ToLower())).ToList();
            }
            else if (tag == null)
            {
                listOfItems = db.ClosedBusinesses.ToList();                                            
            }
            else
            {                
                listOfItems = allTags.Where(s => s.Name == tag).Select(s => s.TaggedBusiness).ToList();              
            }
            var debtpertown = CalculateTownsAnAmountOwed(allTags);
            var response = new ClosedBusinessResponse
            {
                Businesses = listOfItems,
                TownTags = tags,
                SummaryOfDebtPerTowns = debtpertown
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        private Dictionary<string,decimal> CalculateTownsAnAmountOwed(IQueryable<Tag> listOfItems)
        {
            Dictionary<string, decimal> returnable = new Dictionary<string, decimal>();
            foreach (var t in listOfItems)
            {
                if (!returnable.ContainsKey(t.Name))
                {
                    returnable.Add(t.Name, t.TaggedBusiness.TotalMoneyOwed);
                }
                else
                {
                    returnable[t.Name]+= t.TaggedBusiness.TotalMoneyOwed;
                }
            }
            return returnable;
        }
    }
    
}
