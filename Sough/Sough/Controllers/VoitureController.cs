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
using System.Data.SqlClient;
using System.Collections;
using System.Data.Entity.Validation;
using PagedList;
using System.Web.Helpers;
using System.Security.Cryptography;

namespace Sough.Controllers
{
    public class VoitureController : BaseController
    {

        private ToujjarDatabase db = new ToujjarDatabase();
        List<Voiture> listVoitures;
        private VoitureHelp Vsql;
        private TraitementDonnees tdonnee;
        private const int PageSize = 3;
        //
        // GET: /Voiture/
        
        public ActionResult Index()
        {
            return View(db.Voitures.OrderByDescending(a => a.temps).ThenBy(a => a.Id).ToList());
        }

        //
        // GET: /Voiture/Details/5


        public ActionResult Details(long id = 0)
        {
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        //
        // GET: /Voiture/Create
        [HttpGet]
        public ActionResult Create()
        {
            if (TempData["return"] != null)
                ViewBag.msg = TempData["return"].ToString();
            return View();
        }

        //
        // POST: /Voiture/Create
        
        //[ValidateAntiForgeryToken]
        //[AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult Create([Bind(Include = "prix, marque, Modele,ville,kilometrage,BoiteDeVitesse,carburant,"
            + "trader_name,Email,phone,color,car_shape,trader_facebook,trader_instagram,password"
            )]Voiture voiture,
            string EstNeuf="", string image1 = "", string image2 = "", string image3 = "", string image4 = ""
            , IEnumerable<HttpPostedFileBase> files = null
         )
        {
            try
            {

                tdonnee = new TraitementDonnees();
                Voiture _voiture = new Voiture();
                

                string model = "";
                string email = "";
                string face = "";
                string insta = "";
                long prix = voiture.prix;
                string marque = voiture.marque.Trim().ToString();
                if (voiture.Modele.Trim().ToString().Length > 1)
                    model = voiture.Modele.Trim().ToString();

                string ville = voiture.ville.Trim().ToString();
                long kilometrage = voiture.kilometrage;
                string boiteDeVitesse = voiture.BoiteDeVitesse.Trim().ToString();
                string carburant = voiture.carburant.Trim().ToString();
                string tname = "";
                string color = voiture.color.Trim().ToString();
                string car_shape = setCarType(voiture.car_shape.Trim().ToString());
                string st_pass = voiture.password.Trim().ToString();
                string est_neuf = EstNeuf;
                if (!tdonnee.NumberIsValid(voiture.prix) || !tdonnee.StringIsValid(marque) ||
                    !tdonnee.StringIsValid(model) || !tdonnee.StringIsValid(est_neuf) ||
                    !tdonnee.StringIsValid(ville) || !tdonnee.NumberIsValid(kilometrage) ||
                    !tdonnee.StringIsValid(boiteDeVitesse)
                    || !tdonnee.StringIsValid(carburant)
                    || car_shape.Equals("null") || color.Equals("null")
                    || !tdonnee.StringIsValid(st_pass))
                {
                    System.Diagnostics.Debug.WriteLine("modele not valide");
                    TempData["return"] = "nook";
                    return RedirectToAction("Create");
                }


                if (tdonnee.StringIsValid(voiture.trader_name))
                    tname = voiture.trader_name.Trim().ToString();

                if (tdonnee.StringIsValid(voiture.email))
                    email = voiture.email.Trim().ToString();

                if (tdonnee.StringIsValid(voiture.trader_facebook))
                    face = voiture.trader_facebook.Trim().ToString();

                if (tdonnee.StringIsValid(voiture.trader_instagram))
                    insta = voiture.trader_instagram.Trim().ToString();

                /* Images */
                Sough.Helpers.ImagesActions.ImagesModel<Voiture>(ref _voiture, ref image1, ref image2, ref image3,
                            ref image4, ref files);

                /* P@$$W0RD */
                tdonnee.Tmd5<Voiture>(st_pass, ref _voiture);

                /* Date */
                tdonnee.SaveDate<Voiture>(ref _voiture);

                _voiture.prix = prix;
                _voiture.marque = marque;
                _voiture.Modele = model;
                _voiture.EstNeuf = est_neuf;
                _voiture.ville = ville;
                _voiture.kilometrage = kilometrage;
                _voiture.BoiteDeVitesse = boiteDeVitesse;
                _voiture.carburant = carburant;
                _voiture.trader_name = tname;
                _voiture.email = email;
                _voiture.color = color;
                _voiture.car_shape = car_shape;
                _voiture.trader_facebook = face;
                _voiture.trader_instagram = insta;
                string phone = voiture.phone.Trim().ToString();
                _voiture.phone = phone;


                db.Voitures.Add(_voiture);
                db.SaveChanges();
                _voiture = null;
                //Gallerie1 glr = new Gallerie1();
                //long id = _voiture.Id;
                //glr.ModelId = id;
                //glr.ModelName = "Voiture";
                //db.Gallerie1.Add(glr);

                //db.SaveChanges();

                //return View(_voiture);
                TempData["return"] = "ok";

                return RedirectToAction("Create");


            }
            catch (Exception e)
            {
                ViewBag.ex = e.Message;
                return View("~/Views/Error/Exception.cshtml");
            }
        }

        public ActionResult ShowWare(long id = 0)
        {
            try
            {
                Voiture voiture = db.Voitures.Find(id);
                if (voiture == null)
                {
                    return HttpNotFound();
                }

                List<Voiture> listVoitures = db.Voitures.Where(s => s.phone == voiture.phone &&
                        s.Id != voiture.Id).OrderByDescending(a => a.temps).ThenBy(a => a.Id).ToList();

                VoitureHelp.lastResult = listVoitures; // save result for pagination

                listVoitures.Add(voiture);

                voiture = listVoitures[0];
                listVoitures[0] = listVoitures[listVoitures.Count - 1];
                listVoitures[listVoitures.Count - 1] = voiture;

                PagedList<Voiture> model = new PagedList<Voiture>(listVoitures, 1, PageSize);
                return View(model);
            }
            catch (Exception e)
            {
                ViewBag.ex = e.Message + " & " + e.Data;
                return View("~/Views/Error/Exception.cshtml");
            }
        }

        [HttpGet]
         public ActionResult ShowWarePagination(int page = 1)
        {
            try
            {
                    listVoitures = VoitureHelp.lastResult;
                    PagedList<Voiture> model = new PagedList<Voiture>(listVoitures, page, PageSize);

                    return PartialView("~/Views/Voiture/_UserWare.cshtml", model);
            }
            catch (Exception e)
            {
                return View("~/Views/Error/Exception.cshtml");
            }
        }

        [AllowAnonymous]
        public FileContentResult GetAdImageByName(long id = 0, int n = 1)
        {
            var voiture = db.Voitures.FirstOrDefault(p => p.Id == id);
            if (voiture != null)
            {
                if (n == 1)
                    return File(voiture.image1, "image/jpg", "image/png");
                else if (n == 2)
                {
                    if (voiture.image2 != null)
                        return File(voiture.image2, "image/jpg", "image/png");
                }
                else if (n == 3)
                    return File(voiture.image3, "image/jpg", "image/png");
                else if (n == 4)
                    return File(voiture.image4, "image/jpg", "image/png");

            }

            return null;
        }

        [AllowAnonymous]
        public FileContentResult GetAdImage(long id = 0)
        {
            var voiture = db.Voitures.FirstOrDefault(p => p.Id == id);
            if (voiture != null)
            {
                return File(voiture.image1, "image/jpg", "image/png");
            }

            else
            {
                return null;
            }
        }

        //
        // GET: /Voiture/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        //
        // POST: /Voiture/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voiture);
        }

        //
        // GET: /Voiture/Delete/5

        public ActionResult Delete(long id = 0)
        {
            // --------Original-----------
            //Voiture voiture = db.Voitures.Find(id);
            //if (voiture == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(voiture);
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            db.Voitures.Remove(voiture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Voiture/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Voiture voiture = db.Voitures.Find(id);
            db.Voitures.Remove(voiture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteAll()
        {
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Ads(int page = 1, string v_p = "p")
        {
            try
            {
                if (v_p.Equals("v"))
                {
                    string sql = "select * from Voitures";

                    if(AdHelper.trie == 1) 
                        listVoitures = db.Voitures.SqlQuery(sql).OrderByDescending(v => v.temps).ThenBy(v => v.Id).ToList();
                    else
                        listVoitures = db.Voitures.SqlQuery(sql).OrderBy(v => v.prix).ThenBy(v => v.Id).ToList();
                    
                    PagedList<Voiture> model = new PagedList<Voiture>(listVoitures, page, PageSize);
                    VoitureHelp.lastResult = listVoitures;

                    ViewBag.ville = "all";
                    ViewBag.cat = "Voitures";
                    return View("~/Views/Voiture/Ads.cshtml", model);
                }
                else
                {
                    listVoitures = VoitureHelp.lastResult;
                    if (AdHelper.trie == 1) listVoitures = listVoitures.OrderByDescending(v => v.temps).ThenBy(v => v.Id).ToList();
                    else listVoitures = listVoitures.OrderBy(v => v.prix).ThenBy(v => v.Id).ToList();

                    PagedList<Voiture> model = new PagedList<Voiture>(listVoitures, page, PageSize);

                    return PartialView("~/Views/Voiture/_CarsList.cshtml", model);
                }
            }
            catch (Exception e)
            {
                return View("~/Views/Error/Exception.cshtml");
            }
            //return PartialView("~/Views/Voiture/_CarsList.cshtml");

        }


        [HttpPost]
        public ActionResult Ads(FormCollection param, int page = 1)
        {
            try
            {
                tdonnee = new TraitementDonnees();
                string cat = tdonnee.splitStrSM(param["cat"].Trim());

                if (!cat.Equals("Voitures"))
                {
                    string view = tdonnee.GetAdsView(cat);
                }

                Vsql = new VoitureHelp();

                string pmn_s = tdonnee.splitStrSM(param["pmn"].Trim());
                string pmx_s = tdonnee.splitStrSM(param["pmx"].Trim());
                string marque = tdonnee.splitStrSM(param["marque"].Trim());
                string m_audi = tdonnee.splitStrSM(param["model_audi"].Trim());
                string m_bmw = tdonnee.splitStrSM(param["model_bmw"].Trim());
                string m_mercedes = tdonnee.splitStrSM(param["model_mercedes"].Trim());
                string m_nissan = tdonnee.splitStrSM(param["model_nissan"].Trim());
                string m_reault = tdonnee.splitStrSM(param["model_renault"].Trim());
                string m_toyota = tdonnee.splitStrSM(param["model_toyota"].Trim());
                string km_min = tdonnee.splitStrSM(param["km_min"].Trim());
                string km_max = tdonnee.splitStrSM(param["km_max"].Trim());
                string boite = tdonnee.splitStrSM(param["boite"].Trim());
                string carburant = tdonnee.splitStrSM(param["carburant"].Trim());
                string car_shape1 = tdonnee.splitStrSM(param["car_shape1"].Trim());
                string car_shape2 = tdonnee.splitStrSM(param["car_shape2"].Trim());
                string car_shape3 = tdonnee.splitStrSM(param["car_shape3"].Trim());
                string car_shape4 = tdonnee.splitStrSM(param["car_shape4"].Trim());
                string color1 = tdonnee.splitStrSM(param["color1"].Trim());
                string color2 = tdonnee.splitStrSM(param["color2"].Trim());
                string color3 = tdonnee.splitStrSM(param["color3"].Trim());
                string color4 = tdonnee.splitStrSM(param["color4"].Trim());
                string color5 = tdonnee.splitStrSM(param["color5"].Trim());
                string color6 = tdonnee.splitStrSM(param["color6"].Trim());
                string color7 = tdonnee.splitStrSM(param["color7"].Trim());
                string color8 = tdonnee.splitStrSM(param["color8"].Trim());
                string ville = tdonnee.splitStrSM(param["ville"].Trim());
                string neuf = tdonnee.splitStrSM(tdonnee.NullToString(param["neuf"]));
                string occ = tdonnee.splitStrSM(tdonnee.NullToString(param["occ"]));


                string query = "SELECT * FROM " + cat;
                ArrayList fields = new ArrayList();

                string query_modele = Vsql.GetQueryModele(m_audi, m_bmw, m_mercedes, m_nissan, m_reault, m_toyota);

                string query_shape = "";
                int cpt_car_shape = 0;
                query_shape = Vsql.GetQueryShape(car_shape1, car_shape2, car_shape3, car_shape4);
                cpt_car_shape = Vsql.GetCptShape();

                string query_color = "";
                int cpt_color = 0;
                query_color = Vsql.GetQueryColor(color1, color2, color3, color4, color5, color6, color7, color8);
                cpt_color = Vsql.GetCptColor();

                if (!ville.Equals("all") && ville.Length > 1)
                    fields.Add("ville = '" + ville + "'");

                tdonnee.Prixmm(ref fields, pmn_s, pmx_s);
                if (marque.Length > 0) fields.Add("marque = '" + marque + "'");
                if (query_modele != null) fields.Add("Modele = '" + query_modele + "'");
                if (km_min.Length > 0) fields.Add("kilometrage >= " + km_min);
                if (km_max.Length > 0) fields.Add("kilometrage <= " + km_max);
                if (boite.Length > 0) fields.Add("BoiteDeVitesse = '" + boite + "'");
                if (carburant.Length > 0) fields.Add("carburant = '" + carburant + "'");

                if (cpt_color > 0) fields.Add(query_color);
                if (cpt_car_shape > 0) fields.Add(query_shape);

                if (neuf.Length > 1 && occ.Length < 1)
                {
                    fields.Add("EstNeuf = '" + neuf + "'");
                }
                else if (neuf.Length < 1 && occ.Length > 1)
                {
                    fields.Add("EstNeuf = '" + occ + "'");
                }


                for (int i = 0; i < fields.Count; i++)
                {
                    if (i == 0 && fields.Count > 0) query += " WHERE ";

                    query += fields[i];
                    if (i < (fields.Count - 1))
                        query += " AND ";
                }

                query += " ;";
                //VoitureHelp.last_query = query;
                System.Diagnostics.Debug.WriteLine(query);

                ViewBag.ville = ville;
                ViewBag.cat = cat;

                setCat(cat);
                if(AdHelper.trie == 1)  listVoitures = db.Voitures.SqlQuery(query).OrderByDescending(v => v.temps).ThenBy(v => v.Id).ToList();
                else listVoitures = db.Voitures.SqlQuery(query).OrderBy(a => a.prix).ThenBy(a => a.Id).ToList();

                VoitureHelp.lastResult = listVoitures;

                PagedList<Voiture> model = new PagedList<Voiture>(listVoitures, page, PageSize);

                return PartialView("~/Views/Voiture/_CarsList.cshtml", model);

            }
            catch (Exception e)
            {
                ViewBag.donnees = "error";
                return PartialView("~/Views/Voiture/_CarsList.cshtml");
            }

        }

        //[HttpGet]
        //public ActionResult getByPhone(string p, int page = 0)
        //{
        //    string phone;
        //    if (!tdonnee.StringIsValid(p))
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        phone = p;
        //    }

        //    List<Voiture> listVoitures = db.Voitures.Where(v => v.phone == phone).ToList();
        //    PagedList<Voiture> model = new PagedList<Voiture>(listVoitures, page, PageSize);

        //    return PartialView("~/Views/Voiture/_CarsWhere.cshtml", model);

        //}


        /*-------------------------------------------------*/
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

        [HttpGet]
        public ActionResult TrierParDate(int page = 1)
        {
            AdHelper.trie = 1;

            PagedList<Voiture> model = null;
            if (VoitureHelp.lastResult.Count < 1)
                return PartialView("~/Views/Voiture/_CarsList.cshtml", model);

            List<Voiture> listVoitures = VoitureHelp.lastResult;
            listVoitures = listVoitures.OrderByDescending(v => v.temps).ThenBy(v => v.Id).ToList();
            
            model = new PagedList<Voiture>(listVoitures, page, PageSize);
            
            return PartialView("~/Views/Voiture/_CarsList.cshtml", model);

        }

        [HttpGet]
        public ActionResult TrierParPrix(int page = 1)
        {
            AdHelper.trie = 2;

            PagedList<Voiture> model = null;
            if(VoitureHelp.lastResult.Count < 1)
                return PartialView("~/Views/Voiture/_CarsList.cshtml", model);

            List<Voiture> listVoitures = VoitureHelp.lastResult;
            listVoitures = listVoitures.OrderBy(v => v.prix).ThenBy(v => v.Id).ToList();
            model = new PagedList<Voiture>(listVoitures, page, PageSize);
            return PartialView("~/Views/Voiture/_CarsList.cshtml", model);

        }

        private void setCat(string cat)
        {
            if (cat.Equals("Voitures") || cat.Equals("Moto") || cat.Equals("EquipementAuto"))
            {
                ViewBag.p_cat = "Vehicules";
            }
            else if (cat.Equals("LocationImmobiliers") || cat.Equals("VenteImmobiliers") || cat.Equals("BureauCommerces"))
            {
                ViewBag.p_cat = "Immobilier";
            }
            else if (cat.Equals("Chameaux") || cat.Equals("Chevres") || cat.Equals("Vaches"))
            {
                ViewBag.p_cat = "Animaux";
            }
            else if (cat.Equals("Vetements"))
            {
                ViewBag.p_cat = "Vetements";
            }
            else if (cat.Equals("Ammeublements") || cat.Equals("Electromenagers") || cat.Equals("ArtTables") || cat.Equals("Decorations") || cat.Equals("Jardinages"))
            {
                ViewBag.p_cat = "Materiel maison";
            }
            else if (cat.Equals("Ordinateurs") || cat.Equals("Telephones") || cat.Equals("Televisions") || cat.Equals("Jeux") || cat.Equals("Informatiques"))
            {
                ViewBag.p_cat = "Multimedia";
            }
            else if (cat.Equals("Mtransports") || cat.Equals("MGrosOeuvres") || cat.Equals("EquipementIndustriels") || cat.Equals("RestaurantHotelleries") || cat.Equals("FournitureBureaux") || cat.Equals("CommerceMarches") || cat.Equals("MaterielMedicals"))
            {
                ViewBag.p_cat = "Materiel proffessionel";
            }
            else if (cat.Equals("ServiceMaisons") || cat.Equals("CourParticuliers") || cat.Equals("EcoleAuto"))
            {
                ViewBag.p_cat = "Services";
            }
        }


        public string setCarType(string nt)
        {
            string type = "non";
            // Les types de voitures : SUV, Berline , Break , Pickup
            if (nt.Equals("2")) type = "SUV";
            else if (nt.Equals("3")) type = "Berline";
            else if (nt.Equals("4")) type = "Break";
            else if (nt.Equals("5")) type = "Pickup";

            return type;
        }

    }
}


/*
 if (string.IsNullOrWhiteSpace(pmx_s))
                        {
   
                            if (ville.Equals("all"))
                            {
                                ViewBag.ville = ville;

                                if (cat.Equals("Ammeublements"))
                                {
                                    List<Ammeublement> _model2 = db.Ammeublements.ToList();
                                    return View("~/Views/Ammeublement/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("ArtTables"))
                                {
                                    List<ArtTable> _model2 = db.ArtTables.ToList();
                                    return View("~/Views/ArtTable/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("BureauCommerces"))
                                {
                                    List<BureauCommerce> _model2 = db.BureauCommerces.ToList();
                                    return View("~/Views/BureauCommerce/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Chameaux"))
                                {
                                    List<Chameau> _model2 = db.Chameaux.ToList();
                                    return View("~/Views/Chameau/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Chevres"))
                                {
                                    List<Chevre> _model2 = db.Chevres.ToList();
                                    return View("~/Views/Chevre/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("CommerceMarches"))
                                {
                                    List<CommerceMarche> _model2 = db.CommerceMarches.ToList();
                                    return View("~/Views/CommerceMarche/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("CourParticuliers"))
                                {
                                    List<CourParticulier> _model2 = db.CourParticuliers.ToList();
                                    return View("~/Views/CourParticulier/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Decorations"))
                                {
                                    List<Decoration> _model2 = db.Decorations.ToList();
                                    return View("~/Views/Decoration/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("EcoleAuto"))
                                {
                                    List<EcoleAuto> _model2 = db.EcoleAutoes.ToList();
                                    return View("~/Views/EcoleAuto/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Electromenagers"))
                                {
                                    List<Electromenager> _model2 = db.Electromenagers.ToList();
                                    return View("~/Views/Electromenager/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("EquipementAuto"))
                                {
                                    List<EquipementAuto> _model2 = db.EquipementAutoes.ToList();
                                    return View("~/Views/EquipementAuto/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("EquipementIndustriels"))
                                {
                                    List<EquipementIndustriel> _model2 = db.EquipementIndustriels.ToList();
                                    return View("~/Views/EquipementIndustriel/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("FournitureBureaux"))
                                {
                                    List<FournitureBureau> _model2 = db.FournitureBureaux.ToList();
                                    return View("~/Views/FournitureBureau/Ads.cshtml", _model2);
                                }


                                else if (cat.Equals("Informatiques"))
                                {
                                    List<Informatique> _model2 = db.Informatiques.ToList();
                                    return View("~/Views/Informatique/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Jardinages"))
                                {
                                    List<Jardinage> _model2 = db.Jardinages.ToList();
                                    return View("~/Views/Jardinage/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Jeux"))
                                {
                                    List<Jeu> _model2 = db.Jeus.ToList();
                                    return View("~/Views/Jeu/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("LocationImmobiliers"))
                                {
                                    List<LocationImmobilier> _model2 = db.LocationImmobiliers.ToList();
                                    return View("~/Views/LocationImmobilier/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("MaterielMedicals"))
                                {
                                    List<MaterielMedical> _model2 = db.MaterielMedicals.ToList();
                                    return View("~/Views/MaterielMedical/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("MGrosOeuvres"))
                                {
                                    List<MGrosOeuvre> _model2 = db.MGrosOeuvres.ToList();
                                    return View("~/Views/MGrosOeuvre/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Moto"))
                                {
                                    List<Moto> _model2 = db.Motoes.ToList();
                                    return View("~/Views/Moto/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Mtransports"))
                                {
                                    List<Mtransport> _model2 = db.Mtransports.ToList();
                                    return View("~/Views/Mtransport/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Ordinateurs"))
                                {
                                    List<Ordinateur> _model2 = db.Ordinateurs.ToList();
                                    return View("~/Views/Ordinateur/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("RestaurantHotelleries"))
                                {
                                    List<RestaurantHotellerie> _model2 = db.RestaurantHotelleries.ToList();
                                    return View("~/Views/RestaurantHotellerie/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("ServiceMaisons"))
                                {
                                    List<ServiceMaison> _model2 = db.ServiceMaisons.ToList();
                                    return View("~/Views/ServiceMaison/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Telephones"))
                                {
                                    List<Telephone> _model2 = db.Telephones.ToList();
                                    return View("~/Views/Telephone/Ads.cshtml", _model2);
                                }

                                else if (cat.Equals("Televisions"))
                                {
                                    List<Television> _model2 = db.Televisions.ToList();
                                    return View("~/Views/Television/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Vaches"))
                                {
                                    List<Vache> _model2 = db.Vaches.ToList();
                                    return View("~/Views/Vache/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("VenteImmobiliers"))
                                {
                                    List<VenteImmobilier> _model2 = db.VenteImmobiliers.ToList();
                                    return View("~/Views/VenteImmobilier/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Vetements"))
                                {
                                    List<Vetement> _model2 = db.Vetements.ToList();
                                    return View("~/Views/Vetement/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Voitures"))
                                {
                                    List<Voiture> _model2;
                                    if (VoitureSCH.trier.Equals("prix"))
                                    {
                                        _model2 = db.Voitures.OrderBy(a => a.prix).ThenBy(a => a.Id).ToList();
                                        return View("~/Views/Voiture/Ads.cshtml", _model2);
                                    }
                                    else
                                    {
                                        _model2 = db.Voitures.OrderByDescending(a => a.temps).ThenBy(a => a.Id).ToList();
                                        return View("~/Views/Voiture/Ads.cshtml", _model2);
                                    }
                                }
                            }
                            else
                            {
                                ViewBag.ville = ville;
                                if (cat.Equals("Ammeublements"))
                                {
                                    List<string> l = new List<string>();
                                    l.Add("d");
                                    //List<Ammeublement> _mode = db.Ammeublements.Where(l).ToList();
                                    List<Ammeublement> _model2 = db.Ammeublements.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Ammeublement/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("ArtTables"))
                                {
                                    List<ArtTable> _model2 = db.ArtTables.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/ArtTable/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("BureauCommerces"))
                                {
                                    List<BureauCommerce> _model2 = db.BureauCommerces.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/BureauCommerce/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Chameaux"))
                                {
                                    List<Chameau> _model2 = db.Chameaux.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Chameau/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Chevres"))
                                {
                                    List<Chevre> _model2 = db.Chevres.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Chevre/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("CommerceMarches"))
                                {
                                    List<CommerceMarche> _model2 = db.CommerceMarches.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/CommerceMarche/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("CourParticuliers"))
                                {
                                    List<CourParticulier> _model2 = db.CourParticuliers.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/CourParticulier/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Decorations"))
                                {
                                    List<Decoration> _model2 = db.Decorations.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Decoration/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("EcoleAuto"))
                                {
                                    List<EcoleAuto> _model2 = db.EcoleAutoes.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/EcoleAuto/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Electromenagers"))
                                {
                                    List<Electromenager> _model2 = db.Electromenagers.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Electromenager/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("EquipementAuto"))
                                {
                                    List<EquipementAuto> _model2 = db.EquipementAutoes.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/EquipementAuto/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("EquipementIndustriels"))
                                {
                                    List<EquipementIndustriel> _model2 = db.EquipementIndustriels.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/EquipementIndustriel/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("FournitureBureaux"))
                                {
                                    List<FournitureBureau> _model2 = db.FournitureBureaux.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/FournitureBureau/Ads.cshtml", _model2);
                                }


                                else if (cat.Equals("Informatiques"))
                                {
                                    List<Informatique> _model2 = db.Informatiques.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Informatique/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Jardinages"))
                                {
                                    List<Jardinage> _model2 = db.Jardinages.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Jardinage/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Jeux"))
                                {
                                    List<Jeu> _model2 = db.Jeus.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Jeu/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("LocationImmobiliers"))
                                {
                                    List<LocationImmobilier> _model2 = db.LocationImmobiliers.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/LocationImmobilier/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("MaterielMedicals"))
                                {
                                    List<MaterielMedical> _model2 = db.MaterielMedicals.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/MaterielMedical/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("MGrosOeuvres"))
                                {
                                    List<MGrosOeuvre> _model2 = db.MGrosOeuvres.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/MGrosOeuvre/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Moto"))
                                {
                                    List<Moto> _model2 = db.Motoes.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Moto/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Mtransports"))
                                {
                                    List<Mtransport> _model2 = db.Mtransports.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Mtransport/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Ordinateurs"))
                                {
                                    List<Ordinateur> _model2 = db.Ordinateurs.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Ordinateur/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("RestaurantHotelleries"))
                                {
                                    List<RestaurantHotellerie> _model2 = db.RestaurantHotelleries.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/RestaurantHotellerie/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("ServiceMaisons"))
                                {
                                    List<ServiceMaison> _model2 = db.ServiceMaisons.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/ServiceMaison/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Telephones"))
                                {
                                    List<Telephone> _model2 = db.Telephones.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Telephone/Ads.cshtml", _model2);
                                }

                                else if (cat.Equals("Televisions"))
                                {
                                    List<Television> _model2 = db.Televisions.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Television/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Vaches"))
                                {
                                    List<Vache> _model2 = db.Vaches.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Vache/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("VenteImmobiliers"))
                                {
                                    List<VenteImmobilier> _model2 = db.VenteImmobiliers.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/VenteImmobilier/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Vetements"))
                                {
                                    List<Vetement> _model2 = db.Vetements.Where(s => s.ville == ville).ToList();
                                    return View("~/Views/Vetement/Ads.cshtml", _model2);
                                }
                                else if (cat.Equals("Voitures"))
                                {
                                    List<Voiture> _model2;
                                    if (VoitureSCH.trier.Equals("prix"))
                                    {
                                        _model2 = db.Voitures.Where(s => s.ville == ville).OrderBy(a => a.prix).ThenBy(a => a.Id).ToList();
                                        return View("~/Views/Voiture/Ads.cshtml", _model2);
                                    }
                                    else
                                    {
                                        _model2 = db.Voitures.Where(s => s.ville == ville).OrderByDescending(a => a.temps).ThenBy(a => a.Id).ToList();
                                        return View("~/Views/Voiture/Ads.cshtml", _model2);
                                    }

                                }
                            }

                        }
                       
 */