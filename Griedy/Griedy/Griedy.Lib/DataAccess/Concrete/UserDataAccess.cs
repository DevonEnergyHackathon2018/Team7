using Griedy.Lib.Models;

using System.Linq;
using System.Security.Principal;

namespace Griedy.Lib.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        public User GetUser()
        {
            var identity = WindowsIdentity.GetCurrent();
            var user = new User()
            {
                Username = identity.Name,
                FullName = identity.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value,
                Roles = identity.Claims.Where(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/groupsid").Select(x => x.Value).ToArray()
            };

            return user;
        }
    }
}
