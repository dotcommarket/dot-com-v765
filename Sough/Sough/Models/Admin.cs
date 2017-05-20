using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class Admin
    {
        [Required]
        public long Id { set; get;}
        [Required]
        public string username { set; get; }
        [Required]
        public string password { set; get; }
    }
}