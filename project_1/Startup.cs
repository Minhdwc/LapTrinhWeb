using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using project_1.Identity;

[assembly: OwinStartup(typeof(project_1.Startup))]

namespace project_1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            }) ;
            this.CreateRolesAndUser();
        }
        public void CreateRolesAndUser()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new WebDBContext()));
            var appdbcontext = new WebDBContext();
            var appUserStore = new WebUserStore(appdbcontext);
            var userManager = new WebUserManager(appUserStore);
            if (!roleManager.RoleExists("admin"))
            {
                var role = new IdentityRole();
                role.Name = "admin";
                roleManager.Create(role);
            }
            if (userManager.FindByName("admin") == null)
            {
                var user = new WebUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                string userPassword = "admin123";

                var checkUser = userManager.Create(user, userPassword);
                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "admin");
                }
            }
            //manager
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }
            if (userManager.FindByName("Manager") == null)
            {
                var user = new WebUser();
                user.UserName = "Manager";
                user.Email = "manager@gmail.com";
                string userPassword = "manager123";

                var checkUser = userManager.Create(user, userPassword);
                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }

            }
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }

    }
}
