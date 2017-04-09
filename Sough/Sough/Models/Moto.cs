using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class Moto : Ware
    {
        

        [Required]
        [Display(Name = "LabelKilometrage", ResourceType = typeof(Resource))]
        public long kilometrage { set; get; }


        [Required]
        [Display(Name="Annee de la model")]
        public string AnneeModel { set; get; }


        [Required]
        [Display(Name="cylindrée")]
        public string cylindre { set; get; }



        
        
    }
}