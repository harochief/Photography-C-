using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Identity4Example.DAL;
using Identity4Example.Models;


namespace Identity4Example.Controllers
{
    public class FileController : Controller
    {
       private FamilyContext db = new FamilyContext();
        //
        // GET: /File/
       // GET: /File/
       public ActionResult Index(int id)
       {
           var fileToRetrieve = db.Files.Find(id);
           return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
       }
    }
}