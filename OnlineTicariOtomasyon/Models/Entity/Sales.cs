using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class Sales : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CariId { get; set; }
        public int PersonelId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Cari Cari { get; set; }

        public virtual Personel Personel { get; set; }
        public int TotalProduct { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }




    }
}
