using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class Jeu : Ware
    {
        
        
        [Required]
        [Display(Name = "Nom du jeu")]
        public string titre { set; get; }

        [Required]
        [Display(Name = "Texte de l'annonce")]
        public string description { set; get; }
    }
}