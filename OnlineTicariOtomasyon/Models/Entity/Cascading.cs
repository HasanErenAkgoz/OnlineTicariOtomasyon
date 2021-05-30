using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class Cascading:IEntity
    {
        public IEnumerable<SelectListItem> Categorys { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
    }
}