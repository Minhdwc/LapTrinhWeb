using project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_1.Controllers
{
    
    public class CartController : Controller
    {
        // GET: Cart
        DBContext db = new DBContext();
        public ActionResult Index()
        {
            List<Cart> cart = db.Carts.ToList();
            return View(cart);
        }
        [HttpGet]
        public ActionResult UpdateQuantity(int productid, int quantity)
        {
            Cart cart = db.Carts.Where(t=>t.ProductId == productid).FirstOrDefault();
            cart.quantity = quantity;
            cart.total = (int)(cart.quantity * cart.product.ProductPrice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create(int id)
        {
            Products pro = db.Products.Where(t=>t.ProductId == id).FirstOrDefault();
            Cart cart = new Cart();
            cart.product = pro;
            cart.quantity = 1;
            cart.total = (int)(cart.quantity * cart.product.ProductPrice);
            db.Carts.Add(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Pay()
        {
            List<Cart> listCart = db.Carts.ToList();
            foreach(var cart in listCart)
                db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}