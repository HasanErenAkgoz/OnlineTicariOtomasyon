using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class CargoTracking
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "char")]
        [StringLength(10)]
        public string TrackingCode { get; set; }
        [StringLength(100)]
        public string Content { get; set; }
        public DateTime Time { get; set; }

    }
}