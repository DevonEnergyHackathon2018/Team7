using Griedy.Lib.Business;
using Griedy.Lib.Exceptions;

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Griedy.Lib.DataAccess.External
{
    public class AkanaDataAccess : IOnPremisesGatewayDataAccess
    {
        private const string AUTH_SCHEME = "Bearer";
        private const string TELEMETRY_NAME = "Akana API Gateway";

        private readonly IConfigDataAccess _configData;
        private readonly IConfigBusiness _configBiz;
        private readonly HttpClient _httpClient;

        private static void SendTelemetry(HttpRequestMessage request, HttpResponseMessage response, TimeSpan duration)
        {
            TraceTelemetry telemetry;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                telemetry = new TraceTelemetry(TELEMETRY_NAME, SeverityLevel.Information);
                telemetry.Properties.Add("response", $"STATUS: OK");
            }
            else
            {
                telemetry = new TraceTelemetry(TELEMETRY_NAME, SeverityLevel.Error);
                telemetry.Properties.Add("response", $"STATUS: {response.StatusCode}; CONTENT: {response.Content.ReadAsStringAsync().Result}");
            }

            telemetry.Properties.Add("request", $"METHOD: {request.Method.ToString()}; URL: {request.RequestUri.AbsoluteUri}");
            telemetry.Properties.Add("duration", duration.ToString("G"));

            var client = new TelemetryClient();
            client.TrackTrace(telemetry);
        }

        public AkanaDataAccess(IConfigDataAccess configData, IConfigBusiness configBiz, HttpClient httpClient)
        {
            _configData = configData;
            _configBiz = configBiz;
            _httpClient = httpClient;
        }

        private AuthenticationResult GetToken()
        {
            var config = _configData.GetConfig();
            var clientCredential = _configBiz.GetClientCredential(config);
            var authenticationContext = _configBiz.GetAuthenticationContext(config);
            return authenticationContext.AcquireTokenAsync(config.OnPremisesGatewayClientId, clientCredential).Result;
        }

        public T Get<T>(string url)
        {
            var begin = DateTime.Now;
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_configData.GetConfig().OnPremisesGatewayUrl}{url}");
            request.Headers.Authorization = new AuthenticationHeaderValue(AUTH_SCHEME, GetToken().AccessToken);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = _httpClient.SendAsync(request).Result;
            var end = DateTime.Now;

            SendTelemetry(request, response, end.Subtract(begin));

            if (response.StatusCode != HttpStatusCode.OK) { throw new OnPremisesGatewayException(request, response); }
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
