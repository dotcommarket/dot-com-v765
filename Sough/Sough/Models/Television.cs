using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class Television : Ware
    {
        
        
        [Required]
        [Display(Name = "Marque")]
        public string marque { set; get; }

        [Required]
        [Display(Name = "Pouce")]
        public int pouce { set; get; }

        [Required]
        [Display(Name = "Est-il HD ou Non")]
        public string qualite { set; get; }

        [Required]
        [Display(Name = "Est-il avec resepteur")]
        public string AvecRecepteur { set; get; }

        [Required]
        [Display(Name = "Est-il plasma ou classique")]
        public string PlasmaClassique { set; get; }


        [Required]
        [Display(Name = "Est-il neuf ou non")]
        public string EstNeuf { set; get; }

        
    }
}