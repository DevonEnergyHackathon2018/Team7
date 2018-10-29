using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Griedy.Lib.Models;

namespace Griedy.Lib.Business
{
    public interface IConfigBusiness
    {
        string GetAuthority(Config config);
        AuthenticationContext GetAuthenticationContext(Config config);
        ClientCredential GetClientCredential(Config config);
    }
}