using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sough.Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Sough.Helpers;
using PagedList;

namespace Sough.Controllers
{
    public class AdController : BaseController
    {
        private ToujjarDatabase db = new ToujjarDatabase();

        private const int PageSize = 6;
        
        [HttpGet]
        public ActionResult GetWaresFC(string r = "", int f = 0, int page = 1)
        {
            try
            {
                AdHelper.region = r;
                AdHelper.f = f;
                List<Ware> ware;
                List<Ware> wares = new List<Ware>();
                string qr = "";

                if (f == 1)
                {
                    AdHelper.trie = 1;
                    AdHelper.last_Region = r;
                    switch (r)
                    {
                        case "Nouakchott": qr = " WHERE ville = 'Nouakchott'"; break;
                        case "adrar": qr = " WHERE ville = 'Atar'";  break;
                        case "assaba": qr = " WHERE ville = 'Kiffa' OR ville ='Guerou'";  break;
                        case "brakna": qr = " WHERE ville = 'Aleg' OR ville = 'Magta-Lahjar'"; break;
                        case "dakhlet-nouadhibou": qr = " WHERE ville = 'Nouadhibou'";break;
                        case "gorgol": qr = " WHERE ville = 'gorgol'"; break;
                        case "hodh-chargui": qr = " WHERE ville = 'Nema'";  break;
                        case "hodh-gharbi": qr = " WHERE ville = 'Aioun'"; break;
                        case "guidimaka": qr = " WHERE ville = 'Selibaby'";  break;
                        case "inchiri": qr = " WHERE ville = 'Akjoujt'"; break;
                        case "tagant": qr = " WHERE ville = 'Tidjikdja'"; break;
                        case "tiris": qr = " WHERE ville = 'Zouerate'"; break;
                        case "trarza": qr = " WHERE ville = 'Rosso'"; break;
                        case "all": qr = ""; break;

                        default: break;
                    }

                    for (int i = 0; i < TjjConst.tjjtables.Length; i++)
                    {
                        ware = db.Database.SqlQuery<Ware>("SELECT * FROM " + TjjConst.tjjtables[i] + "" + qr).ToList();

                        for (int j = 0; j < ware.Count; j++)
                        {
                            ware[j].model_name = TjjConst.tjjtables[i];
                            wares.Add(ware[j]);
                        }
                    }
                    
                    wares.Sort((p, q) => -1 * p.temps.CompareTo(q.temps));

                    AdHelper.last_wares = wares;
                    PagedList<Ware> plwares = new PagedList<Ware>(wares, page, PageSize);
                    
                    ViewBag.region = r;
                    ViewBag.cat = "all";
                    
                    return View("~/Views/Ad/Awfc.cshtml", plwares);
                }
                else if (f == 0)
                {
                    
                    if (AdHelper.last_Region.Equals("") && AdHelper.last_wares.Count < 1)
                    {
                        PagedList<Ware> plware = null;

                        ViewBag.err = "true";
                        return PartialView("~/Views/Ad/_WaresList.cshtml", plware);
                    }

                    qr = "";
                    switch (AdHelper.last_Region)
                    {
                        case "Nouakchott": qr = " WHERE ville = 'Nouakchott'"; break;
                        case "adrar": qr = " WHERE ville = 'Atar'"; break;
                        case "assaba": qr = " WHERE ville = 'Kiffa' OR ville ='Guerou'"; break;
                        case "brakna": qr = " WHERE ville = 'Aleg' OR ville = 'Magta-Lahjar'"; break;
                        case "dakhlet-nouadhibou": qr = " WHERE ville = 'Nouadhibou'"; break;
                        case "gorgol": qr = " WHERE ville = 'gorgol'"; break;
                        case "hodh-chargui": qr = " WHERE ville = 'Nema'"; break;
                        case "hodh-gharbi": qr = " WHERE ville = 'Aioun'"; break;
                        case "guidimaka": qr = " WHERE ville = 'Selibaby'"; break;
                        case "inchiri": qr = " WHERE ville = 'Akjoujt'"; break;
                        case "tagant": qr = " WHERE ville = 'Tidjikdja'"; break;
                        case "tiris": qr = " WHERE ville = 'Zouerate'"; break;
                        case "trarza": qr = " WHERE ville = 'Rosso'"; break;
                        case "all": qr = ""; break;

                        default: break;
                    }

                    for (int i = 0; i < TjjConst.tjjtables.Length; i++)
                    {
                        ware = db.Database.SqlQuery<Ware>("SELECT * FROM " + TjjConst.tjjtables[i] + "" + qr).ToList();
                        for (int j = 0; j < ware.Count; j++)
                        {
                            ware[j].model_name = TjjConst.tjjtables[i];
                            wares.Add(ware[j]);
                        }
                    }

                    if (AdHelper.trie == 1) wares.Sort((p, q) => -1 * p.temps.CompareTo(q.temps));
                    else if (AdHelper.trie == 2) wares.Sort((p, q) => p.prix.CompareTo(q.prix));

                    AdHelper.last_wares = wares;
                    PagedList<Ware> plwares = new PagedList<Ware>(wares, page, PageSize);

                    ViewBag.region = r;
                    ViewBag.cat = "all";

                    return PartialView("~/Views/Ad/_WaresList.cshtml", plwares);
                }
            }
            catch (Exception e)
            {
                ViewBag.ex = e.Message + " & " + e.Data;
                return View("~/Views/Error/Exception.cshtml");
            }
            return View("~/Views/Error/Exception.cshtml");
        }

        [HttpGet]
        public ActionResult TrierParDate(int page = 1)
        {
            try
            {
                AdHelper.trie = 1;

                PagedList<Ware> plwares = null;

                if (AdHelper.last_wares.Count < 1)
                {
                    ViewBag.err = "true";
                    return View("~/Views/Ad/Awfc.cshtml", plwares);
                }

                List<Ware> wares = new List<Ware>();

                wares = AdHelper.last_wares;

                wares.Sort((p, q) => -1 * p.temps.CompareTo(q.temps));

                plwares = new PagedList<Ware>(wares, page, PageSize);

                return View("~/Views/Ad/Awfc.cshtml", plwares);

            }
            catch (Exception e)
            {
                ViewBag.ex = e.Message + " & " + e.Data;
                return View("~/Views/Error/Exception.cshtml");
            }
        }

        [HttpGet]
        public ActionResult TrierParPrix(int page = 1)
        {
            try
            {
                AdHelper.trie = 2;

                PagedList<Ware> plwares = null;

                if (AdHelper.last_wares.Count < 1)
                {
                    ViewBag.err = "true";
                    return View("~/Views/Ad/Awfc.cshtml", plwares);
                }

                List<Ware> wares = new List<Ware>();
                wares = AdHelper.last_wares;
                wares.Sort((p, q) => p.prix.CompareTo(q.prix));

                plwares = new PagedList<Ware>(wares, page, PageSize);

                return View("~/Views/Ad/Awfc.cshtml", plwares);
            }
            catch (Exception e)
            {
                ViewBag.ex = e.Message + " & " + e.Data;
                return View("~/Views/Error/Exception.cshtml");
            }
        }


        [AllowAnonymous]
        public FileContentResult GetAdImageByName(byte[] img)
        {

            //var voiture = db.Voitures.FirstOrDefault(p => p.IdVoiture == id);
            //List<Ware> _ware = db.Database.SqlQuery<Ware>("SELECT * FROM " + ware.model_name + " WHERE").ToList();

            //System.Diagnostics.Debug.WriteLine("ware prix: "+ _ware.prix);

            if (img != null)
                return File(img, "image/jpg", "image/png");

            return null;
        }
        //
        // GET: /Ad/Create

        public ActionResult Create()
        {
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult ChangeLanguage(string lang)
        {
            //string sql = "UPDATE StatisticLang SET " + lang + " = " + lang + " + 1;";
            
            GererLang.currentLang = lang;
            new GererLang().setLang(lang);
            return RedirectToAction("Index", "Home");
        }
    }
}