using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [StringLength(50)]

        public string Name { get; set; }
        [StringLength(50)]

        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }

        public bool Status { get; set; }

        public string ProductImage { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
      

        public virtual ICollection<Sales> Sales { get; set; }
        public string Explanation { get; set; }


    }
}
