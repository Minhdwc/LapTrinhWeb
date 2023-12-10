using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace project_1.Identity
{
    public class WebUser : IdentityUser
    {
        public DateTime? birth {  get; set; }
        public string address {  get; set; }
        public string City {  get; set; }
    }
}