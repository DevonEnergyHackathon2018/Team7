using Griedy.Lib.DataAccess;
using Griedy.Lib.Models;

using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Griedy.API
{
    public class UserDataAccess : IUserDataAccess
    {
        public User GetUser()
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var user = new User()
            {
                Username = identity.Name,
                FullName = identity.Claims.FirstOrDefault(x => x.Type == "name")?.Value,
                Roles = identity.Claims.Where(x => x.Type == identity.RoleClaimType).Select(x => x.Value).ToArray()
            };

            return user;
        }
    }
}
