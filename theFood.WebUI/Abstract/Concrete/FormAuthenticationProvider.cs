using System;
using System.Linq;
using System.Web.Security;
using theFood.Domain.Concrete;
using theFood.WebUI.Abstract.Infrastructure;

namespace theFood.WebUI.Abstract.Concrete
{
    public class FormAuthenticationProvider:IAuthenticationProvider
    {
        private UserRepository _users;
        public FormAuthenticationProvider()
        {
            _users = new UserRepository();
        }
        public Enum Authenticate(string login, string password)
        {
            var checkAdmin = _users.Users.Where(x => x.Status.ToLower() == "admin").ToList();
            var checkUser = _users.Users.Where(x => x.Status.ToLower() == "user").ToList();
           
            if (checkAdmin.Any(a => a.Login==login&&a.Password==password))
            {
                FormsAuthentication.SetAuthCookie(login, false);
                return StatusPerson.Admin;
            }
            if (checkUser.Any(a => a.Login == login && a.Password == password))
            {
                FormsAuthentication.SetAuthCookie(login, false);
                return StatusPerson.User;
            }

            return null;
        }
    }
}