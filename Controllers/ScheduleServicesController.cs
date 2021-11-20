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
    
    public class ScheduleServicesController : Controller
    {
        private FamilyContext db = new FamilyContext();

        // GET: ScheduleServices
        public ActionResult Index()
        {
            return View(db.ScheduleServices.ToList());
        }

        public ActionResult Success()
        {
            return View();
        }

        // GET: ScheduleServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleService scheduleService = db.ScheduleServices.Find(id);
            if (scheduleService == null)
            {
                return HttpNotFound();
            }
            return View(scheduleService);
        }

        // GET: ScheduleServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScheduleServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Phone,InterestOfService,Message")] ScheduleService scheduleService)
        {
            if (ModelState.IsValid)
            {
                scheduleService.GetDate = DateTime.Now;
                db.ScheduleServices.Add(scheduleService);
                db.SaveChanges();
                return RedirectToAction("Success");
            }

            return View(scheduleService);
        }

        // GET: ScheduleServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleService scheduleService = db.ScheduleServices.Find(id);
            if (scheduleService == null)
            {
                return HttpNotFound();
            }
            return View(scheduleService);
        }

        // POST: ScheduleServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Phone,InterestOfService,Message")] ScheduleService scheduleService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scheduleService);
        }

        // GET: ScheduleServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleService scheduleService = db.ScheduleServices.Find(id);
            if (scheduleService == null)
            {
                return HttpNotFound();
            }
            return View(scheduleService);
        }

        // POST: ScheduleServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleService scheduleService = db.ScheduleServices.Find(id);
            db.ScheduleServices.Remove(scheduleService);
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
