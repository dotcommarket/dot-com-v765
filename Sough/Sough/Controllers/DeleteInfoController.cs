using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sough.Models;

namespace Sough.Controllers
{
    public class DeleteInfoController : Controller
    {
        private ToujjarDatabase db = new ToujjarDatabase();

        //
        // GET: /DeleteInfo/

        public ActionResult Index()
        {
            return View(db.DeleteInfoes.ToList());
        }

        //
        // GET: /DeleteInfo/Details/5

        public ActionResult Details(long id = 0)
        {
            DeleteInfo deleteinfo = db.DeleteInfoes.Find(id);
            if (deleteinfo == null)
            {
                return HttpNotFound();
            }
            return View(deleteinfo);
        }

        //
        // GET: /DeleteInfo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DeleteInfo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeleteInfo deleteinfo)
        {
            if (ModelState.IsValid)
            {
                db.DeleteInfoes.Add(deleteinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deleteinfo);
        }

        //
        // GET: /DeleteInfo/Edit/5

        public ActionResult Edit(long id = 0)
        {
            DeleteInfo deleteinfo = db.DeleteInfoes.Find(id);
            if (deleteinfo == null)
            {
                return HttpNotFound();
            }
            return View(deleteinfo);
        }

        //
        // POST: /DeleteInfo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DeleteInfo deleteinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deleteinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deleteinfo);
        }

        //
        // GET: /DeleteInfo/Delete/5

        public ActionResult Delete(long id = 0)
        {
            DeleteInfo deleteinfo = db.DeleteInfoes.Find(id);
            if (deleteinfo == null)
            {
                return HttpNotFound();
            }
            return View(deleteinfo);
        }

        //
        // POST: /DeleteInfo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DeleteInfo deleteinfo = db.DeleteInfoes.Find(id);
            db.DeleteInfoes.Remove(deleteinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}