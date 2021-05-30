using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class Cargo : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Content { get; set; }
        [Column(TypeName = "char")]
        [StringLength(10)]
        public string TrackingCode { get; set; }
        [StringLength(50)]

        public string PersonelName { get; set; }
        [StringLength(50)]

        public string AlıcıName  { get; set; }
        public DateTime Time { get; set; }

    }
}