using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sough.Models;
using PagedList;
using Sough.Helpers;

namespace Sough.Controllers
{
    public class VetementController : Controller
    {
        private ToujjarDatabase db = new ToujjarDatabase();
        private TraitementDonnees tdonnee;
        private Tdate tdate;
        private const int PageSize = 6;

        //
        // GET: /Vetement/

        public ActionResult Index()
        {
            return View(db.Vetements.ToList());
        }

        //
        // GET: /Vetement/Details/5

        public ActionResult Details(long id = 0)
        {
            Vetement vetement = db.Vetements.Find(id);
            if (vetement == null)
            {
                return HttpNotFound();
            }
            return View(vetement);
        }

        //
        // GET: /Vetement/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Vetement/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vetement vetement, string image1 = "", string image2 = "", string image3 = "", string image4 = ""
            , IEnumerable<HttpPostedFileBase> files = null)
        {
            tdonnee = new TraitementDonnees();
            tdate = new Tdate();
            Sough.Helpers.ImagesActions.ImagesModel<Vetement>(ref vetement, ref image1, ref image2, ref image3, ref image4, ref files);

                tdate.SaveDate<Vetement>(ref vetement);
                db.Vetements.Add(vetement);
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }

        [AllowAnonymous]
        public FileContentResult GetAdImageByName(long id = 0, int n = 1)
        {
            var vetement = db.Vetements.FirstOrDefault(p => p.Id == id);
            if (vetement != null)
            {
                if (n == 1)
                    return File(vetement.image1, "image/jpg", "image/png");
                else if (n == 2)
                {
                    if (vetement.image2 != null)
                        return File(vetement.image2, "image/jpg", "image/png");
                }
                else if (n == 3)
                    return File(vetement.image3, "image/jpg", "image/png");
                else if (n == 4)
                    return File(vetement.image4, "image/jpg", "image/png");

            }

            return null;
        }
        //
        // GET: /Vetement/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Vetement vetement = db.Vetements.Find(id);
            if (vetement == null)
            {
                return HttpNotFound();
            }
            return View(vetement);
        }

        //
        // POST: /Vetement/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vetement vetement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vetement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vetement);
        }

        //
        // GET: /Vetement/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Vetement vetement = db.Vetements.Find(id);
            if (vetement == null)
            {
                return HttpNotFound();
            }
            return View(vetement);
        }

        //
        // POST: /Vetement/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Vetement vetement = db.Vetements.Find(id);
            db.Vetements.Remove(vetement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowWare(long id = 0)
        {
            try
            {
                Vetement v = db.Vetements.Find(id);

                if (v == null)
                {
                    return HttpNotFound();
                }
                List<Vetement> listvs = db.Vetements.Where(s => s.phone == v.phone &&
                        s.Id != v.Id).OrderByDescending(a => a.temps).ThenBy(a => a.Id).ToList();
                listvs.Add(v);
                PagedList<Vetement> model = new PagedList<Vetement>(listvs, 1, PageSize);
                return View(model);
            }
            catch (Exception e)
            {
                ViewBag.ex = e.Message + " & " + e.Data;
                return View("~/Views/Error/Exception.cshtml");
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult ChangeLanguage(string lang)
        {
            GererLang.currentLang = lang;
            new GererLang().setLang(lang);
            return RedirectToAction("Create", "Voiture");
        }
    }
}