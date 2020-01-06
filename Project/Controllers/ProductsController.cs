using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.ViewModels;
namespace Project.Controllers
{
    public class ProductsController : Controller
    {
        public ApplicationDbContext _context;
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(string min,string max,string brandId)
        {
            if(min==null || max == null)
            {
                min = "0";
                max = "350";
            }
           
            var products = new List<Product>();
            Console.Write(min);
            if (brandId ==null)
            {
                brandId = "1,2,3,4,5";
                IEnumerable<Product> data = _context.Database.SqlQuery<Product>("SELECT * FROM Products WHERE brandId IN (" + brandId + ") AND Price > " + min + " AND Price < " + max);
                products = data.ToList();
                products = _context.Products.ToList();
            }
            else
            {
                brandId = brandId.Replace(' ',',');
                if (brandId.Length == 0)
                {
                    brandId = "1,2,3,4,5";
                }
                IEnumerable<Product> data = _context.Database.SqlQuery<Product>("SELECT * FROM Products WHERE brandId IN (" + brandId+ ") AND Price > "+min+" AND Price < " + max);
                products = data.ToList();
            }
            var brands = _context.Brands.ToList();
           
            var viewModel = new ProductsBrandsViewModel
            {
                Products = products,
                Brands = brands
            };
            return View("Index",viewModel);

        }
        public ActionResult Create()
        {
            var brands = _context.Brands.ToList();
            var viewModel = new ProductViewModel
            {
                Product = new Product(),
                Brands = brands
               
            };
            

            return View("Create",viewModel);

        }
        public ActionResult ManageProducts()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            Product product = _context.Products.Find(id);
            var viewModel = new ProductViewModel
            {
                Product = product,
                Brands = _context.Brands.ToList()
            };
            return View(viewModel);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {

            _context.Products.Remove(_context.Products.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
        
            public ActionResult Details(int id)
        {
           
            Product product = _context.Products.Find(id);

            return View(product);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult InsertProduct(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductViewModel
                {
                    Product = model.Product,
                    Brands = _context.Brands.ToList()

                };
                return View("Create", viewModel);


            }
            model.Product.timeStamp = DateTime.Now;
            Brand brand = _context.Brands.Find(model.Product.brandId);
            string[] words = model.Product.Title.Split(' ');
            foreach (var word in words)
            {
                if (word.Length > 2)
                {
                    model.Product.tags += word + " ";
                }
            }
            if ( !model.Product.tags.Contains(brand.Name))
            {
                model.Product.tags += brand.Name;
            }
            _context.Products.Add(model.Product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Products");


        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditProduct(ProductViewModel model)
        {
            Console.Write(model);
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductViewModel
                {
                    Product = model.Product,
                    Brands = _context.Brands.ToList()

                };
                return View("Edit", viewModel);
            }
            
            var updated = _context.Products.Find(model.Product.Id);
            if (updated == null) return HttpNotFound();
            updated.Url = model.Product.Url;
            updated.Title = model.Product.Title;
            Brand brand = _context.Brands.Find(model.Product.brandId);
            string[] words = model.Product.Title.Split(' ');
            foreach (var word in words)
            {
                updated.tags += word + " ";
            }
            updated.tags += brand.Name;

            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

        
    }
}