using project_1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project_1.Filters;

namespace project_1.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        DBContext db = new DBContext();
        [MyAuthenFilter]
        public ActionResult Index(string search = "", string nameSort = "", int page = 1, int cate = 0, int brand = 0)
        {
            List<Products> pro = db.Products.Where(t => t.ProductName.Contains(search)).ToList();
            ViewBag.search = search;
            if (cate != 0)
            {
                pro = pro.Where(t => t.CategoryID == cate).ToList();
            }
            ViewBag.Cate = cate;
            if (brand != 0)
            {
                pro = pro.Where(t => t.BrandID == brand).ToList();
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
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Products sp)
        {
            db.Products.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Index", "Product", "Admin");
        }
        public ActionResult Delete(int?id)
        {
            List<Products> pro = db.Products.ToList();
            if(id!= null && pro.Any(t=>t.ProductId == id))
            {
                ViewBag.Id = id;
                return View();
            }
            return RedirectToAction("Index", "Product", "Admin");
        }
        [HttpPost]
        public ActionResult Delete(Products pro, int id ) 
        {
            if (pro != null)
            {
                Products product = db.Products.Where(t=>t.ProductId ==  id).FirstOrDefault();
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
        public ActionResult Edit(int? id)
        {
            Products pro = db.Products.Where(t => t.ProductId == id).FirstOrDefault();
            ViewBag.Id = id;
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(Products pro)
        {
            Products product = db.Products.Where(t => t.ProductId == pro.ProductId).FirstOrDefault();
            product.ProductName = pro.ProductName;
            product.ProductDescription = pro.ProductDescription;
            product.ProductPrice = pro.ProductPrice;
            product.ProductImage = pro.ProductImage;
            product.BrandID = pro.BrandID;
            product.CategoryID = pro.CategoryID;
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}