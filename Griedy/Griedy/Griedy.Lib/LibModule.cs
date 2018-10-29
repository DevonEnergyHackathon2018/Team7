using Griedy.Lib.Business;
using Griedy.Lib.DataAccess;
using Griedy.Lib.DataContext;

using Autofac;
using Autofac.Extras.DynamicProxy;
using System.Net.Http;

namespace Griedy.Lib
{
    public static class LibModule
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            /* Register an HttpClient singleton. */
            var handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            var httpClient = new HttpClient(handler);
            builder.RegisterInstance(httpClient);

            builder.RegisterType<LogInterceptor>();

            /* Data Context */
            builder.RegisterType<GriedyDataContext>().As<IDataContext>().InstancePerLifetimeScope();

            /* Business */
            builder.RegisterType<ConfigBusiness>().As<IConfigBusiness>().EnableInterfaceInterceptors().InterceptedBy(typeof(LogInterceptor)).InstancePerLifetimeScope();

            /* Data Access */
            builder.RegisterType<ConfigDataAccess>().As<IConfigDataAccess>().EnableInterfaceInterceptors().InterceptedBy(typeof(LogInterceptor)).InstancePerLifetimeScope();
            builder.RegisterType<UserDataAccess>().As<IUserDataAccess>();

            /* External Data Access */
            builder.RegisterType<DataAccess.External.AkanaDataAccess>().As<DataAccess.External.IOnPremisesGatewayDataAccess>().EnableInterfaceInterceptors().InterceptedBy(typeof(LogInterceptor)).InstancePerLifetimeScope();
        }
    }
}
