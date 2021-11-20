using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Identity4Example.DAL;
using Identity4Example.Models;

namespace Identity4Example.Controllers
{
    [Authorize]
    public class TimersController : Controller
    {
        private FamilyContext db = new FamilyContext();

        // GET: Timers
        public ActionResult Index()
        {
            return View(db.Timers.ToList());
        }

        // GET: Timers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timer timer = db.Timers.Find(id);
            if (timer == null)
            {
                return HttpNotFound();
            }
            return View(timer);
        }

        // GET: Timers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Timers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GetDate,Days")] Timer timer)
        {
            if (ModelState.IsValid)
            {
                timer.GetDate = DateTime.Now;
                db.Timers.Add(timer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timer);
        }

        // GET: Timers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timer timer = db.Timers.Find(id);
            if (timer == null)
            {
                return HttpNotFound();
            }
            return View(timer);
        }

        // POST: Timers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GetDate,Days")] Timer timer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timer);
        }

        // GET: Timers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timer timer = db.Timers.Find(id);
            if (timer == null)
            {
                return HttpNotFound();
            }
            return View(timer);
        }

        // POST: Timers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Timer timer = db.Timers.Find(id);
            db.Timers.Remove(timer);
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
