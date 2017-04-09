using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class Ordinateur : Ware
    {
        
        [Required]
        [Display(Name = "Marque")]
        public string marque { set; get; }

        [Display(Name = "Memoire dusque dur")]
        public int DisqueDur { set; get; }


        [Display(Name = "Ram")]
        public int ram { set; get; }


        [Display(Name = "Processeur")]
        public string cpu { set; get; }

        [Display(Name = "Neuf / Occasion")]
        public string EstNeuf { set; get; }
      

    }
}