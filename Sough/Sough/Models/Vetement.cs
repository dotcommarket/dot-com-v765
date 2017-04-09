using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class Vetement : Ware
    {
        
       
        [Required]
        [Display(Name="Type")]
        public string type { set; get; }

       
        public string description { set; get; }

    }
}