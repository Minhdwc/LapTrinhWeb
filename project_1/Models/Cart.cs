using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project_1.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public virtual Products product { get; set; }
        public Nullable<int> ProductId { get; set; }
        public int quantity {  get; set; }
        public int total {  get; set; }
    }
}