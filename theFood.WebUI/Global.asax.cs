using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using theFood.Domain.Abstract;
using theFood.Domain.Concrete;
using theFood.Domain.DbModel;
using theFood.WebUI.Infrastructure;

namespace theFood.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly UserRepository _user = new UserRepository();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            CreateAdmin();
        }

        private void CreateAdmin()
        {
            var person = _user.Users.FirstOrDefault(x => x.Status.ToLower() == "admin");
            if (person==null)
            {
                var admin = new User
                {
                    Id = 0,
                    FirstName ="admin",
                    SecondName = "admin",
                    Status = "admin",
                    Age = 0,
                    Mobile = "000000000",
                    ConfirmPerson = true,
                    Email = "admin@admin.com",
                    Login = "admin",
                    Password = "admin12345"

                };

                _user.AddUser(admin);

            }
        }
    }
}