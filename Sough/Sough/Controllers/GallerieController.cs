//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Sough.Models;

//namespace Sough.Controllers
//{
//    public class GallerieController : Controller
//    {
//        private SoughDB db = new SoughDB();

//        //
//        // GET: /Gallerie/

//        //[AllowAnonymous]
//        //public FileContentResult GetAdImage(long id = 0, string table = "Voitures", string n_id = "IdVoiture")
//        //{
//        //    var model = db.[table].FirstOrDefault(p => p.[n_id] == id);
            
//        //    if (model != null)
//        //    {
//        //        return File(model.image1, "image/jpg", "image/png");
//        //    }

//        //    else
//        //    {
//        //        return null;
//        //    }
//        //}

//        public ActionResult Index()
//        {
//            return View(db.Gallerie1.ToList());
//        }

//        //
//        // GET: /Gallerie/Details/5

//        public ActionResult Details(long id = 0)
//        {
//            Gallerie1 gallerie1 = db.Gallerie1.Find(id);
//            if (gallerie1 == null)
//            {
//                return HttpNotFound();
//            }
//            return View(gallerie1);
//        }

//        //
//        // GET: /Gallerie/Create

//        public ActionResult Create()
//        {
//            return View();
//        }

//        //
//        // POST: /Gallerie/Create

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(Gallerie1 gallerie1)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Gallerie1.Add(gallerie1);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(gallerie1);
//        }

//        //
//        // GET: /Gallerie/Edit/5

//        public ActionResult Edit(long id = 0)
//        {
//            Gallerie1 gallerie1 = db.Gallerie1.Find(id);
//            if (gallerie1 == null)
//            {
//                return HttpNotFound();
//            }
//            return View(gallerie1);
//        }

//        //
//        // POST: /Gallerie/Edit/5

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(Gallerie1 gallerie1)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(gallerie1).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(gallerie1);
//        }

//        //
//        // GET: /Gallerie/Delete/5

//        public ActionResult Delete(long id = 0)
//        {
//            Gallerie1 gallerie1 = db.Gallerie1.Find(id);
//            if (gallerie1 == null)
//            {
//                return HttpNotFound();
//            }
//            return View(gallerie1);
//        }

//        //
//        // POST: /Gallerie/Delete/5

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(long id)
//        {
//            Gallerie1 gallerie1 = db.Gallerie1.Find(id);
//            db.Gallerie1.Remove(gallerie1);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            db.Dispose();
//            base.Dispose(disposing);
//        }
//    }
//}