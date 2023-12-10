using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace project_1.Identity
{
    public class WebUserManager : UserManager<WebUser>
    {
        public WebUserManager(IUserStore<WebUser> store) : base(store) { }
    }
    
}