using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class ServiceMaison : Ware
    {
        
        [Required]
        [Display(Name = "Service")]
        public string titre { set; get; }

        [Required]
        [Display(Name = "Description")]
        public string description { set; get; }
    }
}