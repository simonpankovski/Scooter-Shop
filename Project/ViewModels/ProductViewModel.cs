using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
namespace Project.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Brand> Brands { get; set; }
        public Product Product { get; set; }
    }
}