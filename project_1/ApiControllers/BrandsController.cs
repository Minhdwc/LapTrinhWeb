using project_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace project_1.ApiControllers
{
    public class BrandsController : ApiController
    {
        public List<Brands> Get()
        {
            DBContext db = new DBContext();
            List<Brands> brands = db.Brands.ToList();
            return brands;
        }
    }
}
