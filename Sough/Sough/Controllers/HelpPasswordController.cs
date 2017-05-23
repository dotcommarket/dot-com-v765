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
    public class HelpPasswordController : Controller
    {
        private ToujjarDatabase db = new ToujjarDatabase();

        //
        // GET: /HelpPassword/

        public ActionResult Index()
        {
            return View(db.HelpPasswords.ToList());
        }

        //
        // GET: /HelpPassword/Details/5

        public ActionResult Details(long id = 0)
        {
            HelpPassword helppassword = db.HelpPasswords.Find(id);
            if (helppassword == null)
            {
                return HttpNotFound();
            }
            return View(helppassword);
        }


        public ActionResult Create(string ck, string cat)
        {
            HelpPassword helppassword = new HelpPassword();
            long _ck = Int64.Parse(ck);
            string action = "../"+cat+"/ShowWare";

            helppassword.CatId = _ck;
            helppassword.cat = cat;
            helppassword.temps = DateTime.Now;

            db.HelpPasswords.Add(helppassword);
            db.SaveChanges();

            return RedirectToAction(action, new { id=ck});

        }

        //
        // GET: /HelpPassword/Edit/5

        public ActionResult Edit(long id = 0)
        {
            HelpPassword helppassword = db.HelpPasswords.Find(id);
            if (helppassword == null)
            {
                return HttpNotFound();
            }
            return View(helppassword);
        }

        //
        // POST: /HelpPassword/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HelpPassword helppassword)
        {
            if (ModelState.IsValid)
            {
                db.Entry(helppassword).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(helppassword);
        }

        //
        // GET: /HelpPassword/Delete/5

        public ActionResult Delete(long id = 0)
        {
            HelpPassword helppassword = db.HelpPasswords.Find(id);
            if (helppassword == null)
            {
                return HttpNotFound();
            }
            return View(helppassword);
        }

        //
        // POST: /HelpPassword/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            HelpPassword helppassword = db.HelpPasswords.Find(id);
            db.HelpPasswords.Remove(helppassword);
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