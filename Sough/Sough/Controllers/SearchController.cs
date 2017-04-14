using Sough.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Sough.Helpers;
namespace Sough.Controllers
{
    public class SearchController : Controller
    {
        private ToujjarDatabase db = new ToujjarDatabase();
        private const int PageSize = 6;



        [HttpPost]
        public ActionResult Control(FormCollection param, int page = 1)
        {
            try
            {
                string cat = param["cat"];
                string ville = param["ville"];
                string query = "";

                setCat(cat);

                ViewBag.cat = cat;
                if (ville.Equals("all"))
                {
                    ViewBag.ville = ville;

                //    if (cat.Equals("Ammeublements"))
                //    {
                //        List<Ammeublement> _model = db.Ammeublements.ToList();
                //        return View("~/Views/Ammeublement/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("ArtTables"))
                //    {
                //        List<ArtTable> _model = db.ArtTables.ToList();
                //        return View("~/Views/ArtTable/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("BureauCommerces"))
                //    {
                //        List<BureauCommerce> _model = db.BureauCommerces.ToList();
                //        return View("~/Views/BureauCommerce/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("Chameaux"))
                //    {
                //        List<Chameau> _model = db.Chameaux.ToList();
                //        return View("~/Views/Chameau/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("Chevres"))
                //    {
                //        List<Chevre> _model = db.Chevres.ToList();
                //        return View("~/Views/Chevre/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("CommerceMarches"))
                //    {
                //        List<CommerceMarche> _model = db.CommerceMarches.ToList();
                //        return View("~/Views/CommerceMarche/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("CourParticuliers"))
                //    {
                //        List<CourParticulier> _model = db.CourParticuliers.ToList();
                //        return View("~/Views/CourParticulier/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("Decorations"))
                //    {
                //        List<Decoration> _model = db.Decorations.ToList();
                //        return View("~/Views/Decoration/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("EcoleAuto"))
                //    {
                //        List<EcoleAuto> _model = db.EcoleAutoes.ToList();
                //        return View("~/Views/EcoleAuto/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("Electromenagers"))
                //    {
                //        List<Electromenager> _model = db.Electromenagers.ToList();
                //        return View("~/Views/Electromenager/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("EquipementAuto"))
                //    {
                //        List<EquipementAuto> _model = db.EquipementAutoes.ToList();
                //        return View("~/Views/EquipementAuto/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("EquipementIndustriels"))
                //    {
                //        List<EquipementIndustriel> _model = db.EquipementIndustriels.ToList();
                //        return View("~/Views/EquipementIndustriel/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("FournitureBureaux"))
                //    {
                //        List<FournitureBureau> _model = db.FournitureBureaux.ToList();
                //        return View("~/Views/FournitureBureau/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("Informatiques"))
                //    {
                //        List<Informatique> _model = db.Informatiques.ToList();
                //        return View("~/Views/Informatique/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("Jardinages"))
                //    {
                //        List<Jardinage> _model = db.Jardinages.ToList();
                //        return View("~/Views/Jardinage/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("Jeux"))
                //    {
                //        List<Jeu> _model = db.Jeus.ToList();
                //        return View("~/Views/Jeu/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("LocationImmobiliers"))
                //    {
                //        List<LocationImmobilier> _model = db.LocationImmobiliers.ToList();
                //        return View("~/Views/LocationImmobilier/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("MaterielMedicals"))
                //    {
                //        List<MaterielMedical> _model = db.MaterielMedicals.ToList();
                //        return View("~/Views/MaterielMedical/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("MGrosOeuvres"))
                //    {
                //        List<MGrosOeuvre> _model = db.MGrosOeuvres.ToList();
                //        return View("~/Views/MGrosOeuvre/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("Moto"))
                //    {
                //        List<Moto> _model = db.Motoes.ToList();
                //        return View("~/Views/Moto/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("Mtransports"))
                //    {
                //        List<Mtransport> _model = db.Mtransports.ToList();
                //        return View("~/Views/Mtransport/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("Ordinateurs"))
                //    {
                //        List<Ordinateur> _model = db.Ordinateurs.ToList();
                //        return View("~/Views/Ordinateur/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("RestaurantHotelleries"))
                //    {
                //        List<RestaurantHotellerie> _model = db.RestaurantHotelleries.ToList();
                //        return View("~/Views/RestaurantHotellerie/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("ServiceMaisons"))
                //    {
                //        List<ServiceMaison> _model = db.ServiceMaisons.ToList();
                //        return View("~/Views/ServiceMaison/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("Telephones"))
                //    {
                //        List<Telephone> _model = db.Telephones.ToList();
                //        return View("~/Views/Telephone/Ads.cshtml", _model);
                //    }

                //    else if (cat.Equals("Televisions"))
                //    {
                //        List<Television> _model = db.Televisions.ToList();
                //        return View("~/Views/Television/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("Vaches"))
                //    {
                //        List<Vache> _model = db.Vaches.ToList();
                //        return View("~/Views/Vache/Ads.cshtml", _model);
                //    }
                //    else if (cat.Equals("VenteImmobiliers"))
                //    {
                //        List<VenteImmobilier> _model = db.VenteImmobiliers.ToList();
                //        return View("~/Views/VenteImmobilier/Ads.cshtml", _model);
                //    }
                //    else 
                        if (cat.Equals("Vetements"))
                    {
                        List<Vetement> _model = db.Vetements.ToList();
                        return View("~/Views/Vetement/Ads.cshtml", _model);
                    }
                    else if (cat.Equals("Voitures"))
                    {
                        List<Voiture> listVoitures;
                        if(AdHelper.trie == 1)
                            listVoitures = db.Voitures.OrderByDescending(a => a.temps).ThenBy(a => a.Id).ToList();
                        else listVoitures = db.Voitures.OrderBy(a => a.prix).ThenBy(a => a.Id).ToList();
                        
                        VoitureHelp.lastResult = listVoitures;

                        //query = "SELECT * FROM Voitures;";
                        //VoitureHelp.last_query = query;

                        PagedList<Voiture> model = new PagedList<Voiture>(listVoitures, page, PageSize);
                        return View("~/Views/Voiture/Ads.cshtml", model);
                    }
                }
                else
                {
                    ViewBag.ville = ville;
                    //if (cat.Equals("Ammeublements"))
                    //{
                    //    List<Ammeublement> _model = db.Ammeublements.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/Ammeublement/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("ArtTables"))
                    //{
                    //    List<ArtTable> _model = db.ArtTables.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/ArtTable/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("BureauCommerces"))
                    //{
                    //    List<BureauCommerce> _model = db.BureauCommerces.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/BureauCommerce/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("Chameaux"))
                    //{
                    //    List<Chameau> _model = db.Chameaux.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/Chameau/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("Chevres"))
                    //{
                    //    List<Chevre> _model = db.Chevres.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/Chevre/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("CommerceMarches"))
                    //{
                    //    List<CommerceMarche> _model = db.CommerceMarches.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/CommerceMarche/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("CourParticuliers"))
                    //{
                    //    List<CourParticulier> _model = db.CourParticuliers.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/CourParticulier/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("Decorations"))
                    //{
                    //    List<Decoration> _model = db.Decorations.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/Decoration/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("EcoleAuto"))
                    //{
                    //    List<EcoleAuto> _model = db.EcoleAutoes.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/EcoleAuto/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("Electromenagers"))
                    //{
                    //    List<Electromenager> _model = db.Electromenagers.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/Electromenager/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("EquipementAuto"))
                    //{
                    //    List<EquipementAuto> _model = db.EquipementAutoes.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/EquipementAuto/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("EquipementIndustriels"))
                    //{
                    //    List<EquipementIndustriel> _model = db.EquipementIndustriels.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/EquipementIndustriel/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("FournitureBureaux"))
                    //{
                    //    List<FournitureBureau> _model = db.FournitureBureaux.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/FournitureBureau/Ads.cshtml", _model);
                    //}


                    //else if (cat.Equals("Informatiques"))
                    //{
                    //    List<Informatique> _model = db.Informatiques.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/Informatique/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("Jardinages"))
                    //{
                    //    List<Jardinage> _model = db.Jardinages.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/Jardinage/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("Jeux"))
                    //{
                    //    List<Jeu> _model = db.Jeus.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/Jeu/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("LocationImmobiliers"))
                    //{
                    //    List<LocationImmobilier> _model = db.LocationImmobiliers.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/LocationImmobilier/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("MaterielMedicals"))
                    //{
                    //    List<MaterielMedical> _model = db.MaterielMedicals.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/MaterielMedical/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("MGrosOeuvres"))
                    //{
                    //    List<MGrosOeuvre> _model = db.MGrosOeuvres.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/MGrosOeuvre/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("Moto"))
                    //{
                    //    List<Moto> _model = db.Motoes.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/Moto/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("Mtransports"))
                    //{
                    //    List<Mtransport> _model = db.Mtransports.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/Mtransport/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("Ordinateurs"))
                    //{
                    //    List<Ordinateur> _model = db.Ordinateurs.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/Ordinateur/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("RestaurantHotelleries"))
                    //{
                    //    List<RestaurantHotellerie> _model = db.RestaurantHotelleries.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/RestaurantHotellerie/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("ServiceMaisons"))
                    //{
                    //    List<ServiceMaison> _model = db.ServiceMaisons.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/ServiceMaison/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("Telephones"))
                    //{
                    //    List<Telephone> _model = db.Telephones.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/Telephone/Ads.cshtml", _model);
                    //}

                    //else if (cat.Equals("Televisions"))
                    //{
                    //    List<Television> _model = db.Televisions.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/Television/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("Vaches"))
                    //{
                    //    List<Vache> _model = db.Vaches.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/Vache/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("VenteImmobiliers"))
                    //{
                    //    List<VenteImmobilier> _model = db.VenteImmobiliers.Where(s => s.ville == ville).ToList();
                    //    return View("~/Views/VenteImmobilier/Ads.cshtml", _model);
                    //}
                    //else if (cat.Equals("Vetements"))
                    if (cat.Equals("Vetements"))
                    {
                        List<Vetement> _model = db.Vetements.Where(s => s.ville == ville).ToList();
                        return View("~/Views/Vetement/Ads.cshtml", _model);
                    }
                    else if (cat.Equals("Voitures"))
                    {
                        List<Voiture> listVoitures;

                        //query = "SELECT * FROM Voitures WHERE ville = '" + ville + "';";
                        //VoitureHelp.last_query = query;
                        if(AdHelper.trie == 1)
                            listVoitures = db.Voitures.Where(s => s.ville == ville).OrderByDescending(a => a.temps).ThenBy(a => a.Id).ToList();
                        else listVoitures = db.Voitures.Where(s => s.ville == ville).OrderBy(a => a.prix).ThenBy(a => a.Id).ToList();
                        
                        VoitureHelp.lastResult = listVoitures;

                        PagedList<Voiture> model = new PagedList<Voiture>(listVoitures, page, PageSize);
                        return View("~/Views/Voiture/Ads.cshtml", model);
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.ex = e.Message + " & " + e.Data;
                return View("~/Views/Error/Exception.cshtml");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Control(string c = "", string v = "", int page = 1)
        {
            if (c.Equals(""))
                return View("~/Views/Error/Httpnotfound.cshtml");

            if (v.Equals(""))
                return View("~/Views/Error/Httpnotfound.cshtml");

            string cat = c;
            string ville = v;


            setCat(cat);

            ViewBag.cat = cat;
            if (ville.Equals("all"))
            {
                ViewBag.ville = ville;

                //if (cat.Equals("Ammeublements"))
                //{
                //    List<Ammeublement> _model = db.Ammeublements.ToList();
                //    return View("~/Views/Ammeublement/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("ArtTables"))
                //{
                //    List<ArtTable> _model = db.ArtTables.ToList();
                //    return View("~/Views/ArtTable/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("BureauCommerces"))
                //{
                //    List<BureauCommerce> _model = db.BureauCommerces.ToList();
                //    return View("~/Views/BureauCommerce/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Chameaux"))
                //{
                //    List<Chameau> _model = db.Chameaux.ToList();
                //    return View("~/Views/Chameau/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Chevres"))
                //{
                //    List<Chevre> _model = db.Chevres.ToList();
                //    return View("~/Views/Chevre/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("CommerceMarches"))
                //{
                //    List<CommerceMarche> _model = db.CommerceMarches.ToList();
                //    return View("~/Views/CommerceMarche/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("CourParticuliers"))
                //{
                //    List<CourParticulier> _model = db.CourParticuliers.ToList();
                //    return View("~/Views/CourParticulier/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Decorations"))
                //{
                //    List<Decoration> _model = db.Decorations.ToList();
                //    return View("~/Views/Decoration/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("EcoleAuto"))
                //{
                //    List<EcoleAuto> _model = db.EcoleAutoes.ToList();
                //    return View("~/Views/EcoleAuto/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Electromenagers"))
                //{
                //    List<Electromenager> _model = db.Electromenagers.ToList();
                //    return View("~/Views/Electromenager/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("EquipementAuto"))
                //{
                //    List<EquipementAuto> _model = db.EquipementAutoes.ToList();
                //    return View("~/Views/EquipementAuto/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("EquipementIndustriels"))
                //{
                //    List<EquipementIndustriel> _model = db.EquipementIndustriels.ToList();
                //    return View("~/Views/EquipementIndustriel/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("FournitureBureaux"))
                //{
                //    List<FournitureBureau> _model = db.FournitureBureaux.ToList();
                //    return View("~/Views/FournitureBureau/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Informatiques"))
                //{
                //    List<Informatique> _model = db.Informatiques.ToList();
                //    return View("~/Views/Informatique/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Jardinages"))
                //{
                //    List<Jardinage> _model = db.Jardinages.ToList();
                //    return View("~/Views/Jardinage/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Jeux"))
                //{
                //    List<Jeu> _model = db.Jeus.ToList();
                //    return View("~/Views/Jeu/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("LocationImmobiliers"))
                //{
                //    List<LocationImmobilier> _model = db.LocationImmobiliers.ToList();
                //    return View("~/Views/LocationImmobilier/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("MaterielMedicals"))
                //{
                //    List<MaterielMedical> _model = db.MaterielMedicals.ToList();
                //    return View("~/Views/MaterielMedical/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("MGrosOeuvres"))
                //{
                //    List<MGrosOeuvre> _model = db.MGrosOeuvres.ToList();
                //    return View("~/Views/MGrosOeuvre/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Moto"))
                //{
                //    List<Moto> _model = db.Motoes.ToList();
                //    return View("~/Views/Moto/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Mtransports"))
                //{
                //    List<Mtransport> _model = db.Mtransports.ToList();
                //    return View("~/Views/Mtransport/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Ordinateurs"))
                //{
                //    List<Ordinateur> _model = db.Ordinateurs.ToList();
                //    return View("~/Views/Ordinateur/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("RestaurantHotelleries"))
                //{
                //    List<RestaurantHotellerie> _model = db.RestaurantHotelleries.ToList();
                //    return View("~/Views/RestaurantHotellerie/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("ServiceMaisons"))
                //{
                //    List<ServiceMaison> _model = db.ServiceMaisons.ToList();
                //    return View("~/Views/ServiceMaison/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Telephones"))
                //{
                //    List<Telephone> _model = db.Telephones.ToList();
                //    return View("~/Views/Telephone/Ads.cshtml", _model);
                //}

                //else if (cat.Equals("Televisions"))
                //{
                //    List<Television> _model = db.Televisions.ToList();
                //    return View("~/Views/Television/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Vaches"))
                //{
                //    List<Vache> _model = db.Vaches.ToList();
                //    return View("~/Views/Vache/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("VenteImmobiliers"))
                //{
                //    List<VenteImmobilier> _model = db.VenteImmobiliers.ToList();
                //    return View("~/Views/VenteImmobilier/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Vetements"))
                if (cat.Equals("Vetements"))
                {
                    List<Vetement> _model = db.Vetements.ToList();
                    return View("~/Views/Vetement/Ads.cshtml", _model);
                }
                else if (cat.Equals("Voitures"))
                {

                    //string sql = "SELECT * FROM Voitures;";
                    //VoitureHelp.last_query = sql;
                    List<Voiture> listVoitures;
                    if (AdHelper.trie == 1)
                        listVoitures = db.Voitures.OrderByDescending(a => a.temps).ThenBy(a => a.Id).ToList();
                    else listVoitures = db.Voitures.OrderBy(a => a.prix).ThenBy(a => a.Id).ToList();
                    
                    VoitureHelp.lastResult = listVoitures;
                    PagedList<Voiture> model = new PagedList<Voiture>(listVoitures, page, PageSize);
                    return PartialView("~/Views/Voiture/_CarsList.cshtml", model);
                }
            }
            else
            {
                ViewBag.ville = ville;
                //if (cat.Equals("Ammeublements"))
                //{
                //    List<Ammeublement> _model = db.Ammeublements.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/Ammeublement/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("ArtTables"))
                //{
                //    List<ArtTable> _model = db.ArtTables.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/ArtTable/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("BureauCommerces"))
                //{
                //    List<BureauCommerce> _model = db.BureauCommerces.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/BureauCommerce/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Chameaux"))
                //{
                //    List<Chameau> _model = db.Chameaux.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/Chameau/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Chevres"))
                //{
                //    List<Chevre> _model = db.Chevres.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/Chevre/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("CommerceMarches"))
                //{
                //    List<CommerceMarche> _model = db.CommerceMarches.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/CommerceMarche/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("CourParticuliers"))
                //{
                //    List<CourParticulier> _model = db.CourParticuliers.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/CourParticulier/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Decorations"))
                //{
                //    List<Decoration> _model = db.Decorations.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/Decoration/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("EcoleAuto"))
                //{
                //    List<EcoleAuto> _model = db.EcoleAutoes.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/EcoleAuto/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Electromenagers"))
                //{
                //    List<Electromenager> _model = db.Electromenagers.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/Electromenager/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("EquipementAuto"))
                //{
                //    List<EquipementAuto> _model = db.EquipementAutoes.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/EquipementAuto/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("EquipementIndustriels"))
                //{
                //    List<EquipementIndustriel> _model = db.EquipementIndustriels.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/EquipementIndustriel/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("FournitureBureaux"))
                //{
                //    List<FournitureBureau> _model = db.FournitureBureaux.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/FournitureBureau/Ads.cshtml", _model);
                //}


                //else if (cat.Equals("Informatiques"))
                //{
                //    List<Informatique> _model = db.Informatiques.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/Informatique/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Jardinages"))
                //{
                //    List<Jardinage> _model = db.Jardinages.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/Jardinage/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Jeux"))
                //{
                //    List<Jeu> _model = db.Jeus.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/Jeu/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("LocationImmobiliers"))
                //{
                //    List<LocationImmobilier> _model = db.LocationImmobiliers.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/LocationImmobilier/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("MaterielMedicals"))
                //{
                //    List<MaterielMedical> _model = db.MaterielMedicals.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/MaterielMedical/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("MGrosOeuvres"))
                //{
                //    List<MGrosOeuvre> _model = db.MGrosOeuvres.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/MGrosOeuvre/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Moto"))
                //{
                //    List<Moto> _model = db.Motoes.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/Moto/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Mtransports"))
                //{
                //    List<Mtransport> _model = db.Mtransports.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/Mtransport/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Ordinateurs"))
                //{
                //    List<Ordinateur> _model = db.Ordinateurs.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/Ordinateur/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("RestaurantHotelleries"))
                //{
                //    List<RestaurantHotellerie> _model = db.RestaurantHotelleries.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/RestaurantHotellerie/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("ServiceMaisons"))
                //{
                //    List<ServiceMaison> _model = db.ServiceMaisons.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/ServiceMaison/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Telephones"))
                //{
                //    List<Telephone> _model = db.Telephones.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/Telephone/Ads.cshtml", _model);
                //}

                //else if (cat.Equals("Televisions"))
                //{
                //    List<Television> _model = db.Televisions.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/Television/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Vaches"))
                //{
                //    List<Vache> _model = db.Vaches.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/Vache/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("VenteImmobiliers"))
                //{
                //    List<VenteImmobilier> _model = db.VenteImmobiliers.Where(s => s.ville == ville).ToList();
                //    return View("~/Views/VenteImmobilier/Ads.cshtml", _model);
                //}
                //else if (cat.Equals("Vetements"))
                if (cat.Equals("Vetements"))
                {
                    List<Vetement> _model = db.Vetements.Where(s => s.ville == ville).ToList();
                    return View("~/Views/Vetement/Ads.cshtml", _model);
                }
                else if (cat.Equals("Voitures"))
                {
                    //string sql = "SELECT * FROM Voitures WHERE ville = '" + ville + "';";
                    //VoitureHelp.last_query = sql;

                    List<Voiture> listVoitures;
                    if (AdHelper.trie == 1)
                        listVoitures = db.Voitures.Where(s => s.ville == ville).OrderByDescending(a => a.temps).ThenBy(a => a.Id).ToList();
                    else listVoitures = db.Voitures.Where(s => s.ville == ville).OrderBy(a => a.prix).ThenBy(a => a.Id).ToList();
                    
                    PagedList<Voiture> model = new PagedList<Voiture>(listVoitures, page, PageSize);
                    return PartialView("~/Views/Voiture/_CarsList.cshtml", model);
                }
            }

            return View();
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

        public ActionResult ChangeLanguage(string lang)
        {
            GererLang.currentLang = lang;
            new GererLang().setLang(lang);
            return RedirectToAction("Create", "Voiture");
        }
    }
}
