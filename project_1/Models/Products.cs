using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project_1.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductSize {  get; set; }
        public Nullable <int> BrandID { get; set; }
        public virtual Brands Brands { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public virtual Categories Categories { get; set; }
    }
}