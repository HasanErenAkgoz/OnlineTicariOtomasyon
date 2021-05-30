using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class Cari : IEntity
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]

        public string Surname { get; set; }
        [StringLength(50)]

        public string City { get; set; }

        public bool Status { get; set; }
        [StringLength(50)]

        public string Email { get; set; }
        [StringLength(60)]

        public string Password { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }


    }
}
