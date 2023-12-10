using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace project_1.Identity
{
    public class WebDBContext : IdentityDbContext<WebUser>
    {
        public WebDBContext() : base("MyConnectString") { }
    }
}