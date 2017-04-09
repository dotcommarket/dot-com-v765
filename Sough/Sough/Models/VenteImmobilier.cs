using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class VenteImmobilier : Ware
    {
        
        [Required]
        [Display(Name = "Type de bien")]
        public string type { set; get; }


        [Display(Name = "Meublé /Non meublé")]
        public string EstMeuble { set; get; }

        [Required]
        [Display(Name = "Surface")]
        public int surface { set; get; }


        [Display(Name = "Pieces")]
        public int pieces { set; get; }

        [Required]
        [Display(Name = "Cartier")]
        public string cartier { set; get; }

    }
}