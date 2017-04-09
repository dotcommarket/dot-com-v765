using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class LocationImmobilier : Ware
    {
        


        [Required]
        [Display(Name = "LabelTypeDeBien", ResourceType = typeof(Resource))]
        public string type { set; get; }


        [Display(Name = "LabelEstMeuble", ResourceType = typeof(Resource))]
        public string EstMeuble { set; get; }

        [Required]
        [Display(Name = "LabelSurface", ResourceType = typeof(Resource))]
        public int surface { set; get; }


        [Display(Name = "LabelPieces", ResourceType = typeof(Resource))]
        public int pieces { set; get; }

        [Required]
        [Display(Name = "LabelCartier", ResourceType = typeof(Resource))]
        public string cartier { set; get; }

    }
}