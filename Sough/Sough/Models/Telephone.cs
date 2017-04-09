using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class Telephone : Ware
    {
        
        [Required]
        [Display(Name = "Marque du telephone")]
        public string marque { set; get; }

        [Required]
        [Display(Name = "Modèle du telephone")]
        public string model { set; get; }

        [Required]
        [Display(Name="Mémoire")]
        public int memoire { set; get; }


        [Display(Name = "Camera")]
        public int camera { set; get; }

        [Required]
        [Display(Name = "Couleur")]
        public string couleur { set; get; }


        [Display(Name = "Un seul sim ou deux")]
        public string EstDuos { set; get; }


        [Required]
        [Display(Name = "Neuf / Occasion")]
        public string EstNeuf { set; get; }

    }
}