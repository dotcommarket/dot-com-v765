using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class EcoleAuto : Ware
    {
        
        [Required]
        [Display(Name = "titre")]
        public string titre { set; get; }

        [Required]
        [Display(Name = "Description")]
        public string description { set; get; }
    }
}