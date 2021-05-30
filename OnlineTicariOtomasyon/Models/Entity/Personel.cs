using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class Personel : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]

        public string TcKimlik { get; set; }
        [StringLength(50)]

        public string Name { get; set; }
        [StringLength(50)]

        public string Surname { get; set; }

        public string PersonelImagePath { get; set; }


        public virtual ICollection<Sales> Sales { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }



    }
}
