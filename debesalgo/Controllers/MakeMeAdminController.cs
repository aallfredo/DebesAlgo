using debesalgo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace debesalgo.Controllers
{
    public class MakeMeAdminController : Controller
    {
       /*This should be removed after the first admin gets made */
        // GET: MakeMeAdmin/Create
        public ActionResult Create(string email)
        {
            using (var context = new ApplicationDbContext())
            {
                var fadmin = context.KeyValueSettings.FirstOrDefault(s => s.Key == "FirstAdminSet");
                if (fadmin == null || fadmin.Value == "false")
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);

                    roleManager.Create(new IdentityRole("Admin"));

                    var userStore = new UserStore<ApplicationUser>(context);
                    var userManager = new UserManager<ApplicationUser>(userStore);

                    var user = userManager.FindByEmail(email);
                    userManager.AddToRole(user.Id, "Admin");
                    if (fadmin == null)
                    {
                        context.KeyValueSettings.Add(new KeyValueSettings() { Key = "FirstAdminSet", Value = "true" });
                    }
                    else
                    {
                        fadmin.Value = "true";
                    }
                    context.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }       
    }
}
