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
using System.Data.Entity.Infrastructure;

namespace Identity4Example.Controllers
{
    public class FileUploadersController : Controller
    {
        private FamilyContext db = new FamilyContext();

        // GET: FileUploaders
        public ActionResult Index()
        {
            return View(db.FileUploaders.ToList());
        }

        // GET: FileUploaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUploader fileUploader = db.FileUploaders.Find(id);
            if (fileUploader == null)
            {
                return HttpNotFound();
            }
            return View(fileUploader);
        }

        // GET: FileUploaders/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: FileUploaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] FileUploader fileUploader, HttpPostedFileBase upload)
        {
          

            // Displays the property values of the RegionInfo for "US".
          
       

            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var avatar = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    fileUploader.Files = new List<File> { avatar };
                }

                db.FileUploaders.Add(fileUploader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fileUploader);
        }



        // GET: FileUploaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          

            FileUploader fileUploader = db.FileUploaders.Include(s => s.Files).SingleOrDefault(s => s.ID == id);


            if (fileUploader == null)
            {
                return HttpNotFound();
            }
            return View(fileUploader);
        }

  



        // POST: FileUploaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, HttpPostedFileBase upload)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentToUpdate = db.FileUploaders.Find(id);
            if (TryUpdateModel(studentToUpdate, "",
               new string[] { "ID" }))
            {

            



                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        if (studentToUpdate.Files.Any(f => f.FileType == FileType.Avatar))
                        {
                            db.Files.Remove(studentToUpdate.Files.First(f => f.FileType == FileType.Avatar));
                        }
                        var avatar = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Avatar,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        studentToUpdate.Files = new List<File> { avatar };
                    }
                    db.Entry(studentToUpdate).State = EntityState.Modified;
                  
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(studentToUpdate);
        }



        // GET: FileUploaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUploader fileUploader = db.FileUploaders.Find(id);
            if (fileUploader == null)
            {
                return HttpNotFound();
            }
            return View(fileUploader);
        }

        // POST: FileUploaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FileUploader fileUploader = db.FileUploaders.Find(id);
            db.FileUploaders.Remove(fileUploader);
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
