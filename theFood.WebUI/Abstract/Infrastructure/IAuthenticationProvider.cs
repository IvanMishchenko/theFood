using System;

namespace theFood.WebUI.Abstract.Infrastructure
{
    public interface IAuthenticationProvider
    {
        Enum Authenticate(string login, string password);
    }
}
