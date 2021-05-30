using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class Messages:IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Gonderici { get; set; }
        [StringLength(50)]
        public string Alıcı { get; set; }
        [StringLength(50)]
        public string Konu { get; set; }
        public string icerik { get; set; }
        public DateTime Tarih { get; set; }
    }
}