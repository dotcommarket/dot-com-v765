using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class BureauCommerce : Ware
    {
        
        [Required]
        [Display(Name = "Texte de l'annonce")]
        [MaxLength(200)]
        public string description { set; get; }
    }
}