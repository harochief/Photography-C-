using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Identity4Example.DAL;
using Identity4Example.Models;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Configuration;

namespace FaamilyHouse.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }





        public ActionResult Generate(int? size1)
        {
            TimeSpan ts = TimeSpan.FromSeconds(10);
ts = ts.Subtract(TimeSpan.FromSeconds(1));


ViewBag.re = ts.ToString(@"hh\:mm\:ss");
            return View();
        }


     


        public ActionResult Products()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult AL8000()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AL9010()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ALC1()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult ALP1()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult EBS010()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult EBS()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        private FamilyContext db = new FamilyContext();

        // GET: ScheduleServices
        public ActionResult Indexa()
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

            return View("Index",scheduleService);
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