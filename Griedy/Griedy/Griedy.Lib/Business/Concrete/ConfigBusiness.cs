using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Globalization;
using Griedy.Lib.Models;

namespace Griedy.Lib.Business
{
    public class ConfigBusiness : IConfigBusiness
    {
        public string GetAuthority(Config config)
        {
            if (config == null) { throw new ArgumentNullException(nameof(config)); }
            return string.Format(CultureInfo.InvariantCulture, config.AADInstance, config.Tenant);
        }


        private static AuthenticationContext _authenticationContext;

        public AuthenticationContext GetAuthenticationContext(Config config)
        {
            if (config == null) { throw new ArgumentNullException(nameof(config)); }

            if (_authenticationContext == null)
            {
                var authority = GetAuthority(config);
                _authenticationContext = new AuthenticationContext(authority);
            }

            return _authenticationContext;
        }


        private static ClientCredential _clientCredential;

        public ClientCredential GetClientCredential(Config config)
        {
            if (config == null) { throw new ArgumentNullException(nameof(config)); }

            if (_clientCredential == null)
            {
                _clientCredential = new ClientCredential(config.ClientId, config.ClientSecret);
            }

            return _clientCredential;
        }
    }
}
