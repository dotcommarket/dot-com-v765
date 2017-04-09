using Sough.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sough.Helpers
{
    public class LocatingModal
    {
        //private SoughDB db = new SoughDB();
        //public Tbackenddata() { }

       
        //public List<> GetModele(string cat = "", string ville = "all")
        //{
        //    SoughDB db = new SoughDB();
             
        //        if (cat.Equals("Ammeublements"))
        //        {
        //            List<Ammeublement> _model2 = db.Ammeublements.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("ArtTables"))
        //        {
        //            List<ArtTable> _model2 = db.ArtTables.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("BureauCommerces"))
        //        {
        //            List<BureauCommerce> _model2 = db.BureauCommerces.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("Chameaux"))
        //        {
        //            List<Chameau> _model2 = db.Chameaux.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("Chevres"))
        //        {
        //            List<Chevre> _model2 = db.Chevres.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("CommerceMarches"))
        //        {
        //            List<CommerceMarche> _model2 = db.CommerceMarches.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("CourParticuliers"))
        //        {
        //            List<CourParticulier> _model2 = db.CourParticuliers.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("Decorations"))
        //        {
        //            List<Decoration> _model2 = db.Decorations.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("EcoleAuto"))
        //        {
        //            List<EcoleAuto> _model2 = db.EcoleAutoes.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("Electromenagers"))
        //        {
        //            List<Electromenager> _model2 = db.Electromenagers.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("EquipementAuto"))
        //        {
        //            List<EquipementAuto> _model2 = db.EquipementAutoes.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("EquipementIndustriels"))
        //        {
        //            List<EquipementIndustriel> _model2 = db.EquipementIndustriels.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("FournitureBureaux"))
        //        {
        //            List<FournitureBureau> _model2 = db.FournitureBureaux.ToList();
        //            return _model2;
        //        }


        //        else if (cat.Equals("Informatiques"))
        //        {
        //            List<Informatique> _model2 = db.Informatiques.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("Jardinages"))
        //        {
        //            List<Jardinage> _model2 = db.Jardinages.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("Jeux"))
        //        {
        //            List<Jeu> _model2 = db.Jeus.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("LocationImmobiliers"))
        //        {
        //            List<LocationImmobilier> _model2 = db.LocationImmobiliers.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("MaterielMedicals"))
        //        {
        //            List<MaterielMedical> _model2 = db.MaterielMedicals.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("MGrosOeuvres"))
        //        {
        //            List<MGrosOeuvre> _model2 = db.MGrosOeuvres.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("Moto"))
        //        {
        //            List<Moto> _model2 = db.Motoes.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("Mtransports"))
        //        {
        //            List<Mtransport> _model2 = db.Mtransports.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("Ordinateurs"))
        //        {
        //            List<Ordinateur> _model2 = db.Ordinateurs.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("RestaurantHotelleries"))
        //        {
        //            List<RestaurantHotellerie> _model2 = db.RestaurantHotelleries.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("ServiceMaisons"))
        //        {
        //            List<ServiceMaison> _model2 = db.ServiceMaisons.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("Telephones"))
        //        {
        //            List<Telephone> _model2 = db.Telephones.ToList();
        //            return _model2;
        //        }

        //        else if (cat.Equals("Televisions"))
        //        {
        //            List<Television> _model2 = db.Televisions.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("Vaches"))
        //        {
        //            List<Vache> _model2 = db.Vaches.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("VenteImmobiliers"))
        //        {
        //            List<VenteImmobilier> _model2 = db.VenteImmobiliers.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("Vetements"))
        //        {
        //            List<Vetement> _model2 = db.Vetements.ToList();
        //            return _model2;
        //        }
        //        else if (cat.Equals("Voitures"))
        //        {
        //            List<Voiture> _model2;
        //            if (VoitureSCH.trier.Equals("prix"))
        //            {
        //                _model2 = db.Voitures.OrderBy(a => a.prix).ThenBy(a => a.IdVoiture).ToList();
        //                return _model2;
        //            }
        //            else
        //            {
        //                _model2 = db.Voitures.OrderByDescending(a => a.temps).ThenBy(a => a.IdVoiture).ToList();
        //                return _model2;
        //            }
        //        }
        //}
        public string GetViewUrl(string cat = "")
        {

            if (cat.Equals("Ammeublements"))
                return "~/Views/Ammeublement/Ads.cshtml";

            else if (cat.Equals("ArtTables"))
                return "~/Views/ArtTable/Ads.cshtml";

            else if (cat.Equals("BureauCommerces"))
                return "~/Views/BureauCommerce/Ads.cshtml";
            
            else if (cat.Equals("Chameaux"))
                return "~/Views/Chameau/Ads.cshtml";
            
            else if (cat.Equals("Chevres"))
                return "~/Views/Chevre/Ads.cshtml";
            
            else if (cat.Equals("CommerceMarches"))
                return "~/Views/CommerceMarche/Ads.cshtml";
            
            else if (cat.Equals("CourParticuliers"))
                return "~/Views/CourParticulier/Ads.cshtml";
            
            else if (cat.Equals("Decorations"))
                return "~/Views/Decoration/Ads.cshtml";
            
            else if (cat.Equals("EcoleAuto"))
                return "~/Views/EcoleAuto/Ads.cshtml";
            
            else if (cat.Equals("Electromenagers"))
                return "~/Views/Electromenager/Ads.cshtml";
            
            else if (cat.Equals("EquipementAuto"))
                return "~/Views/EquipementAuto/Ads.cshtml";
            
            else if (cat.Equals("EquipementIndustriels"))
                return "~/Views/EquipementIndustriel/Ads.cshtml";
            
            else if (cat.Equals("FournitureBureaux"))
                return "~/Views/FournitureBureau/Ads.cshtml";
            
            else if (cat.Equals("Informatiques"))
                return "~/Views/Informatique/Ads.cshtml";
            
            else if (cat.Equals("Jardinages"))
                return "~/Views/Jardinage/Ads.cshtml";
            
            else if (cat.Equals("Jeux"))
                return "~/Views/Jeu/Ads.cshtml";
            
            else if (cat.Equals("LocationImmobiliers"))
                return "~/Views/LocationImmobilier/Ads.cshtml";
            
            else if (cat.Equals("MaterielMedicals"))
                return "~/Views/MaterielMedical/Ads.cshtml";
            
            else if (cat.Equals("MGrosOeuvres"))
                return "~/Views/MGrosOeuvre/Ads.cshtml";
            
            else if (cat.Equals("Moto"))
                return "~/Views/Moto/Ads.cshtml";
            
            else if (cat.Equals("Mtransports"))
                return "~/Views/Mtransport/Ads.cshtml";
            
            else if (cat.Equals("Ordinateurs"))
                return "~/Views/Ordinateur/Ads.cshtml";
            
            else if (cat.Equals("RestaurantHotelleries"))
                return "~/Views/RestaurantHotellerie/Ads.cshtml";
            
            else if (cat.Equals("ServiceMaisons"))
                return "~/Views/ServiceMaison/Ads.cshtml";
            
            else if (cat.Equals("Telephones"))
                return "~/Views/Telephone/Ads.cshtml";
            
            else if (cat.Equals("Televisions"))
                return "~/Views/Television/Ads.cshtml";
            
            else if (cat.Equals("Vaches"))
                return "~/Views/Vache/Ads.cshtml";
            
            else if (cat.Equals("VenteImmobiliers"))
                return "~/Views/VenteImmobilier/Ads.cshtml";
            
            else if (cat.Equals("Vetements"))
                return "~/Views/Vetement/Ads.cshtml";
            
            else if (cat.Equals("Voitures"))
               return "~/Views/Voiture/Ads.cshtml"; 
            
            return "";

        }

    }
}