using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class Expenses : IEntity
    {
        public int Id { get; set; }
        [StringLength(50)]

        public string Explanation { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
