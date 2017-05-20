using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class DeleteInfo
    {
        public long Id { set; get; }

        [Required]
        public string why { set; get; }

        [Required]
        public DateTime delete_time { set; get; }

        [Required]
        public DateTime create_time { set; get; }

        [Required]
        public string categorie { set; get; }

        [Required]
        public long prix { set; get; }

        [Required]
        public string ville { set; get; }

        [Required]
        public string phone { set; get; }
    }
}