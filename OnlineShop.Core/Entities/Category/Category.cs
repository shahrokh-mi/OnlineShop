﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
