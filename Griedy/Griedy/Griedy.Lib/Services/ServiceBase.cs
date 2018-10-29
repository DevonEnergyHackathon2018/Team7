using Griedy.Lib.DataAccess;

namespace Griedy.Lib.Services
{
    public abstract class ServiceBase
    {
        protected IUserDataAccess _userData;

        public ServiceBase(IUserDataAccess userData)
        {
            _userData = userData;
        }

        protected virtual bool CanCreate()
        {
            var user = _userData.GetUser();
            return user.IsAdmin || user.IsContributor;
        }

        protected virtual bool CanUpdate()
        {
            var user = _userData.GetUser();
            return user.IsAdmin || user.IsContributor;
        }

        protected virtual bool CanDelete()
        {
            var user = _userData.GetUser();
            return user.IsAdmin;
        }
    }
}
