using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class Informatique : Ware
    {
        
        
        [Required]
        [Display(Name = "Nom du produit")]
        public string titre { set; get; }

        [Required]
        [Display(Name = "texte de l'annonce")]
        public string description { set; get; }
    }
}