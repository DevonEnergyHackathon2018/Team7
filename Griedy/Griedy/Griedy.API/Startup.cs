using Autofac;
using Autofac.Integration.WebApi;
using Griedy.Lib;
using Griedy.Lib.DataAccess;
using Griedy.Lib.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.SignalR;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.ActiveDirectory;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(Griedy.API.Startup))]
namespace Griedy.API
{
    public class Startup
    {
        private void ConfigureAuth(IAppBuilder appBuilder, HttpConfiguration httpConfig, Config appConfig)
        {
            //appBuilder.UseWindowsAzureActiveDirectoryBearerAuthentication(
            //    new WindowsAzureActiveDirectoryBearerAuthenticationOptions
            //    {
            //        Tenant = appConfig.Tenant,
            //        TokenValidationParameters = new TokenValidationParameters
            //        {
            //            /*
            //             * Allow both Client ID and App ID URI Audiences.
            //             * Clients will send the Client ID as the Audience.  Resources running in
            //             * Azure will send the App ID URI as the Audience.
            //             */
            //            ValidAudiences = new string[] { appConfig.Audience, appConfig.ClientId }
            //        },
            //        Provider = new OAuthBearerAuthenticationProvider()
            //    });

            /* Make all controllers require an OAuth token. */
            //httpConfig.Filters.Add(new System.Web.Http.AuthorizeAttribute());
        }

        private void ConfigureCors(IAppBuilder appBuilder)
        {
            appBuilder.UseCors(CorsOptions.AllowAll);
        }

        private void ConfigureDI(IAppBuilder appBuilder, HttpConfiguration httpConfig)
        {
            var builder = new ContainerBuilder();

            /* Register Types */
            LibModule.RegisterTypes(builder);
            builder.RegisterType<UserDataAccess>().As<IUserDataAccess>();

            /* Register Web API Controllers */
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            /* Set the Dependency Resolver to be Autofac */
            var container = builder.Build();
            httpConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(httpConfig);
        }

        private void ConfigureRouting(IAppBuilder appBuilder, HttpConfiguration httpConfig)
        {
            /* Web API Routes */
            httpConfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            /* Allow OData Queries */
            httpConfig
                .Select(QueryOptionSetting.Allowed)
                .Filter(QueryOptionSetting.Allowed)
                .OrderBy(QueryOptionSetting.Allowed)
                .Count(QueryOptionSetting.Allowed)
                .Expand(QueryOptionSetting.Allowed)
                .MaxTop(100);

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "Griedy";

            /* Register EF Entities */
            /* builder.EntitySet<Lib.DataContext.Entity>("Entity"); */

            /* OData Routes */

            appBuilder.UseWebApi(httpConfig);
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            var httpConfig = new HttpConfiguration();

            var configData = new ConfigDataAccess();
            var appConfig = configData.GetConfig();

            // ConfigureAuth(appBuilder, httpConfig, appConfig);
            ConfigureCors(appBuilder);
            ConfigureDI(appBuilder, httpConfig);
            ConfigureRouting(appBuilder, httpConfig);

            appBuilder.MapSignalR("/signalr", new HubConfiguration());
        }
    }
}