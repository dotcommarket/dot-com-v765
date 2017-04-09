using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class Gallerie1 : Ware
    {
        
        [Required]
        public string ModelName { set; get; }
        [Required]
        public long ModelId { get; set; }
    }
}