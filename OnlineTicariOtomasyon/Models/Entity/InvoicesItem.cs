using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class InvoicesItem:IEntity
    {
        public int Id { get; set; }
        public string Explanation { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }

    }
}