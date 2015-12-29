using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using debesalgo.Models;

namespace debesalgo.Controllers
{
     [Authorize(Roles = "Admin")]
     public class ClosedBusinessesAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClosedBusinessesAdmin
        public ActionResult Index()
        {
            return View(db.ClosedBusinesses.ToList());
        }

        // GET: ClosedBusinessesAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClosedBusiness closedBusiness = db.ClosedBusinesses.Find(id);
            if (closedBusiness == null)
            {
                return HttpNotFound();
            }
            return View(closedBusiness);
        }

        // GET: ClosedBusinessesAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClosedBusinessesAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,DateClosed,CurrentStatus,ArticleLink,Img,Details")] ClosedBusiness closedBusiness)
        {
            if (ModelState.IsValid)
            {
                db.ClosedBusinesses.Add(closedBusiness);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(closedBusiness);
        }

        // GET: ClosedBusinessesAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClosedBusiness closedBusiness = db.ClosedBusinesses.Find(id);
            if (closedBusiness == null)
            {
                return HttpNotFound();
            }
            return View(closedBusiness);
        }

        // POST: ClosedBusinessesAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,DateClosed,CurrentStatus,ArticleLink,Img,Details")] ClosedBusiness closedBusiness)
        {
            if (ModelState.IsValid)
            {
                db.Entry(closedBusiness).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(closedBusiness);
        }

        // GET: ClosedBusinessesAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClosedBusiness closedBusiness = db.ClosedBusinesses.Find(id);
            if (closedBusiness == null)
            {
                return HttpNotFound();
            }
            return View(closedBusiness);
        }

        // POST: ClosedBusinessesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClosedBusiness closedBusiness = db.ClosedBusinesses.Find(id);
            db.ClosedBusinesses.Remove(closedBusiness);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
