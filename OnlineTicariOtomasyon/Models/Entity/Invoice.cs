using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class Invoice : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string InvoiceNo { get; set; }
        public DateTime DateTime { get; set; }
        [StringLength(50)]
        public string TaxAdministration { get; set; }
        public int PersonelId { get; set; }
        public virtual Personel Personel { get; set; }
        public int CariId { get; set; }
        public virtual Cari Cari { get; set; }
        public virtual ICollection<InvoicesItem> InvoicesItems { get; set; }

    }
}