using project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project_1.Filters;
using System.Drawing.Drawing2D;


namespace project_1.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class BrandsController : Controller
    {
        // GET: Admin/Brands

        DBContext db = new DBContext();
        public ActionResult Index()
        {
            List<Brands> brands = db.Brands.ToList();
            return View(brands);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Brands b)
        {
            if (b.BrandId != null)
            {
                db.Brands.Add(b);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Brands", "Admin");
        }
        public ActionResult Update(int? id)
        {
            DBContext db = new DBContext();
            Brands brand = db.Brands.Where(t => t.BrandId == id).FirstOrDefault();
            ViewBag.Id = id;
            return View(brand);
        }
        [HttpPost]
        public ActionResult Update(Brands b, int? id)
        {
            Brands brand = db.Brands.Where(t => t.BrandId == id).FirstOrDefault();
            brand.BrandName = b.BrandName;
            db.SaveChanges();
            return RedirectToAction("Index", "Brands", "Admin");
        }
        public ActionResult Delete(int? id)
        {
            List<Brands> pro = db.Brands.ToList();
            if (id != null && pro.Any(t => t.BrandId == id))
            {
                ViewBag.Id = id;
                return View();
            }
            return RedirectToAction("Index", "brands", "Admin");
        }
        [HttpPost]
        public ActionResult Delete(Brands b, int?id)
        {
            DBContext db = new DBContext();
            if (b != null)
            {
                Brands brand = db.Brands.Where(t => t.BrandId == id).FirstOrDefault();
                db.Brands.Remove(brand);
                db.SaveChanges();
                return RedirectToAction("Index", "brands", "Admin");
            }
            return View();
        }
    }
}