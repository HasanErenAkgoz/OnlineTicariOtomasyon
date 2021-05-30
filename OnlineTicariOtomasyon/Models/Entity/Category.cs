﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicariOtomasyon.Models.Entity
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [StringLength(50)]

        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
