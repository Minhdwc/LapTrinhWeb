using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project_1.Models;

namespace project_1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DBContext db = new DBContext();
            List<Products> pro = db.Products.ToList();
            return View(pro);
        }
    }
}