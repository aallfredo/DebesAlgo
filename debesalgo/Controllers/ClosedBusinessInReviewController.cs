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
    [Authorize]
    public class ClosedBusinessInReviewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin")]
        // GET: ClosedBusinessInReview
        public ActionResult Index()
        {
            return View(db.ClosedBusinessesInReview.ToList());
        }

        [Authorize(Roles = "Admin")]
        // GET: ClosedBusinessInReview/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClosedBusinessInReview closedBusiness = db.ClosedBusinessesInReview.Find(id);
            if (closedBusiness == null)
            {
                return HttpNotFound();
            }
            return View(closedBusiness);
        }

        [Authorize(Roles = "Admin")]
        // GET: ClosedBusinessInReview/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClosedBusinessInReview/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,DateClosed,CurrentStatus,ArticleLink,Img,Details")] ClosedBusinessInReview closedBusiness)
        {
            if (ModelState.IsValid)
            {
                closedBusiness.Updated = DateTime.Now;
                db.ClosedBusinessesInReview.Add(closedBusiness);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(closedBusiness);
        }

        [Authorize(Roles = "Admin")]
        // GET: ClosedBusinessInReview/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Edit loads from the
            ClosedBusinessInReview closedBusiness = db.ClosedBusinessesInReview.Find(id);
            if (closedBusiness == null)
            {
                return HttpNotFound();
            }
            return View(closedBusiness);
        }

        // GET: ClosedBusinessInReview/PassThrough/5
        public ActionResult PassThrough(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Edit loads from the
            ClosedBusiness closedBusiness = db.ClosedBusinesses.Find(id);
            if (closedBusiness == null)
            {
                return HttpNotFound();
            }
            return View(closedBusiness);
        }


        [Authorize(Roles = "Admin")]
        // POST: ClosedBusinessInReview/Edit/5
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
        [Authorize(Roles = "Admin")]
        // GET: ClosedBusinessInReview/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClosedBusinessInReview closedBusiness = db.ClosedBusinessesInReview.Find(id);
            if (closedBusiness == null)
            {
                return HttpNotFound();
            }
            return View(closedBusiness);
        }

        [Authorize(Roles = "Admin")]
        // POST: ClosedBusinessInReview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClosedBusinessInReview closedBusiness = db.ClosedBusinessesInReview.Find(id);
            db.ClosedBusinessesInReview.Remove(closedBusiness);
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
