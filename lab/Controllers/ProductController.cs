using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using lab.Models;
using System.Linq;
namespace lab.Controllers
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
        public ActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);

        }
        public ActionResult Create()
        {

            var friends = new Product();

            return View(friends);

        }
        public ActionResult ManageProducts()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            Product friend = _context.Products.Find(id);
            return View(friend);
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

            Product product= _context.Products.Find(id);
           
            return View(product);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult InsertProduct(Product model)
        {
            if (!ModelState.IsValid)
            {

                return View("Create", model);


            }
            model.timeStamp = DateTime.Now;

            string[] words = model.Title.Split(' ');
            foreach (var word in words)
            {
                model.tags += word + " ";
            }
            model.tags += model.Brand;
            _context.Products.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index", "Products");


        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditProduct(Product model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }
            var updated = _context.Products.Find(model.Id);

            updated.Url = model.Url;
            updated.Title = model.Title;
            
            string[] words = model.Title.Split(' ');
            foreach(var word in words)
            {
                updated.tags += word + " ";
            }
            updated.tags += model.Brand;
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
        
    }
}