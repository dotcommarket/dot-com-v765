using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;


namespace Sough.Models
{
    public class Voiture : Ware
    {
        
        [Required]
        [Display(Name = "LabelMarque", ResourceType = typeof(Resource))]
        [MaxLength(50)]
        public string marque { set; get; }


        [Required]
        [Display(Name = "LabelModele", ResourceType = typeof(Resource))]
        [MaxLength(30)]
        public string Modele { set; get; }

        [Required]
        [Display(Name = "LabelKilometrage", ResourceType = typeof(Resource))]
        public long kilometrage { set; get; }

        [Required]
        [Display(Name = "LabelCarburant", ResourceType = typeof(Resource))]
        [MaxLength(20)]
        public string carburant { set; get; }


        [Required]
        [Display(Name = "LabelBoiteDeVitesse", ResourceType = typeof(Resource))]
        [MaxLength(30)]
        public string BoiteDeVitesse { set; get; }

       
        [Display(Name = "label_couleur_et_type", ResourceType = typeof(Resource))]
        [MaxLength(30)]
        public string color { set; get; }

        [MaxLength(30)]
        public string car_shape { set; get; }

        [Required]
        [MaxLength(15)]
        public string EstNeuf { set; get; }
    }
}