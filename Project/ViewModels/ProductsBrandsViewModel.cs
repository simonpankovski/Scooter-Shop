﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
namespace Project.ViewModels
{
    public class ProductsBrandsViewModel
    {
        public List<Product> Products{ get; set; }
        public List<Brand> Brands { get; set; }

    }
}