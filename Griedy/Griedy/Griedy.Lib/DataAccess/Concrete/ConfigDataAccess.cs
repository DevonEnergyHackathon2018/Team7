using Griedy.Lib.Models;
using System.Configuration;

namespace Griedy.Lib.DataAccess
{
    public class ConfigDataAccess : IConfigDataAccess
    {
        private static Config _config = null;

        public Config GetConfig()
        {
            if (_config == null)
            {
                _config = new Config()
                {
                    AADInstance = ConfigurationManager.AppSettings["ida:AADInstance"],
                    Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
                    Audience = ConfigurationManager.AppSettings["ida:Audience"],
                    ClientId = ConfigurationManager.AppSettings["ida:ClientId"],
                    ClientSecret = ConfigurationManager.AppSettings["ida:ClientSecret"],

                    OnPremisesGatewayClientId = ConfigurationManager.AppSettings["opg:ClientId"],
                    OnPremisesGatewayUrl = ConfigurationManager.AppSettings["opg:Url"],
                };
            }

            return _config;
        }
    }
}
