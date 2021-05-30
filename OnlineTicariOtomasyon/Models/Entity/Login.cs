using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class Login : IEntity
    {
        public int Id { get; set; }
        [StringLength(50)]

        public string Epasta { get; set; }
        [StringLength(50)]

        public string Password { get; set; }
        [StringLength(50)]

        public string Authorized { get; set; }
    }
}
