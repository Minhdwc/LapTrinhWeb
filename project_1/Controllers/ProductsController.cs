using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using project_1.Models;

namespace project_1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        DBContext db = new DBContext();
        
        public ActionResult Index(string search = "", string nameSort = "", int page = 1, int cate = 0, int brand = 0)
        {
            List<Products> pro = db.Products.Where(t=>t.ProductName.Contains(search)).ToList();
            ViewBag.search = search;
            if(cate != 0)
            {
                pro = pro.Where(t=>t.CategoryID==cate).ToList();
            }
            ViewBag.Cate = cate;
            if(brand != 0)
            {
                pro = pro.Where(t=>t.BrandID==brand).ToList();
            }
            ViewBag.brand = brand;
            if (brand != 0)
                pro = pro.Where(t => t.Brands.BrandId == brand).ToList();
            ViewBag.cat = brand;
            if (nameSort == "ProName")
                pro = pro.OrderBy(t => t.ProductName).ToList();
            else if (nameSort == "Brand")
                pro = pro.OrderBy(t => t.Brands.BrandId).ToList();
            else if (nameSort == "PriceUp")
                pro = pro.OrderBy(t => t.ProductPrice).ToList();
            else if (nameSort == "PriceDown")
                pro = pro.OrderByDescending(t => t.ProductPrice).ToList();
            ViewBag.NameSort = nameSort;
            int n = 8;
            int NoOfPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pro.Count) / Convert.ToDouble(n)));
            int NoOfRecordToSkip = (page - 1) * n;
            ViewBag.Page = page;
            ViewBag.NoOfPage = NoOfPage;
            pro = pro.Skip(NoOfRecordToSkip).Take(n).ToList();
            return View(pro);
        }
        public ActionResult ProductsByCate(int? id, int page = 1)
        {
            var pro = db.Products.Where(p => p.CategoryID == id).ToList();
            int n = 8;
            int NoOfPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pro.Count) / Convert.ToDouble(n)));
            int NoOfRecordToSkip = (page - 1) * n;
            ViewBag.Page = page;
            ViewBag.NoOfPage = NoOfPage;
            pro = pro.Skip(NoOfRecordToSkip).Take(n).ToList();
            ViewBag.id = id;
            return View(pro);
        }
        public ActionResult Detail(int ?id)
        {
            Products pro = db.Products.Where(t=>t.ProductId == id).FirstOrDefault();
            return View(pro);
        }
    }
}