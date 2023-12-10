using project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(int? id)
        {
            DBContext db = new DBContext();
            List<Categories> cat = db.Categories.ToList();
            //List<Products> pro = db.Products.Where(t=>t.ProductId == id).ToList();
            //ViewBag.id = id;
            return View(cat);
        }
    }
}