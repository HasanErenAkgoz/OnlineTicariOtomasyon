using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class Department : IEntity
    {
        public int Id { get; set; }
        [StringLength(50)]

        public string Name { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Personel> Personels { get; set; }


    }
}
