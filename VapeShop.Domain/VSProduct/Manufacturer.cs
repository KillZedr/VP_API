﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.VSProduct
{
    public class Manufacturer : Entity<int>
    {
        

        public required string ManufacturerName { get; set; } = null!;

        public virtual IEnumerable<Product>? Products { get; set; } = new List<Product>();
    }
}
