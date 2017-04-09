using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sough.Models
{
    public class Chameau : Ware
    {
        public string description { set; get; }
    }
}