﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret_API.Application.ViewModels.Products
{
    public class WM_Update_Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int stock { get; set; }
        public float Price { get; set; }

    }
}
