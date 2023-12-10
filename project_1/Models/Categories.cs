using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project_1.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId {  get; set; }
        public string CategoryName {  get; set; }
    }
}