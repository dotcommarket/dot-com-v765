using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class Ware 
    {
        [Key]
        public long Id { set; get; }
        // trader Informations
        [Display(Name = "LabelTraderName", ResourceType = typeof(Resource))]
        [MaxLength(50)]
        public string trader_name { set; get; }

        [Display(Name = "LabelEmail", ResourceType = typeof(Resource))]
        public string email { set; get; }

        [Display(Name = "LabelFacebook", ResourceType = typeof(Resource))]
        public string trader_facebook { set; get; }

        [Display(Name = "LabelInstagram", ResourceType = typeof(Resource))]
        public string trader_instagram { set; get; }

        [Required]
        [Display(Name = "LabelPhone", ResourceType = typeof(Resource))]
        [MaxLength(13)]
        public string phone { set; get; }


        [Required]
        [Display(Name = "LabelVille", ResourceType = typeof(Resource))]
        [MaxLength(50)]
        public string ville { set; get; }

        [Display(Name = "LabelPrix", ResourceType = typeof(Resource))]
        public long prix { set; get; }
        
        public DateTime temps { set; get; }

        public byte[] image1 { set; get; }
        public byte[] image2 { set; get; }
        public byte[] image3 { set; get; }
        public byte[] image4 { set; get; }


        public int img_count { set; get; }

        [Display(Name = "LabelPassword", ResourceType = typeof(Resource))]
        [MaxLength(50)]
        public string password { set; get; }
        
        public string model_name { set; get; }

    }
}