using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class InvoiceOperation:IEntity
    {
        public IEnumerable<Invoice> Value { get; set; }
        public IEnumerable<InvoicesItem> Value2 { get; set; }
    }
}