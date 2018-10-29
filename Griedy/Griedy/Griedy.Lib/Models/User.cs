using System.Linq;

namespace Griedy.Lib.Models
{
    public class User
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string[] Roles { get; set; }

        public bool IsAdmin
        {
            get
            {
                if (Roles == null) { return false; }
                return Roles.Contains("admin");
            }
        }

        public bool IsContributor
        {
            get
            {
                if (Roles == null) { return false; }
                return Roles.Contains("contributor");
            }
        }
    }
}
