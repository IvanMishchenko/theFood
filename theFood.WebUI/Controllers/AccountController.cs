using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theFood.WebUI.Abstract.Concrete;
using theFood.WebUI.Abstract.Infrastructure;
using theFood.WebUI.Models;

namespace theFood.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationProvider _authenticationProvider;
        //
        // GET: /Account/
        public AccountController()
        {
            
        }
        public AccountController(IAuthenticationProvider authenticationProvider)
        {
            _authenticationProvider = authenticationProvider;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Equals(_authenticationProvider.Authenticate(model.Login,model.Password), StatusPerson.Admin))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    if (Equals(_authenticationProvider.Authenticate(model.Login, model.Password), StatusPerson.User))
                    {
                        return Redirect(returnUrl ?? Url.Action("Index", "Trouble"));
                    }
                }

                ModelState.AddModelError("", "Incorrect login or password");
                return View();
            }
                return View();
        
        }
    }
}
