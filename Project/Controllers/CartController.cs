using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.ViewModels;

namespace Project.Controllers
{
    public class CartController : Controller
    {
        public ApplicationDbContext _context;
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public CartController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {

            var products = (List<Product>)HttpContext.Session["cart"];
            
            return View(products);
        }
        [HttpPost]
        public ActionResult Add(string id)
        {
            var product = _context.Products.Find(Int32.Parse(id));
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            if (HttpContext.Session["cart"] == null)
            {
                List<Product> cart = new List<Product>();
                
                
                cart.Add(product );
                HttpContext.Session["cart"] = cart;
            }
            else
            {
                List<Product> cart = (List<Product>)Session["cart"];
                var index = 0;
                foreach(var item in cart)
                {
                    if (item.Id == product.Id)
                    {
                        index = -1;
                        break;
                    }

                }
                if (index != -1)
                {
                    cart.Add(product);
                }
                HttpContext.Session["cart"] = cart;
            }
            
            return null;
        }
    }
}