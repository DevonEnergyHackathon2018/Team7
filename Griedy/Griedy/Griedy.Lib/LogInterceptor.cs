using Griedy.Lib.DataAccess;

using Castle.DynamicProxy;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System;
using System.Linq;
using System.Security.Claims;

namespace Griedy.Lib
{
    public class LogInterceptor : IInterceptor
    {
        private readonly IUserDataAccess _userData;
        private readonly TelemetryClient _client;

        public LogInterceptor(IUserDataAccess userData)
        {
            _userData = userData;
            _client = new TelemetryClient();
        }

        public void Intercept(IInvocation invocation)
        {
            var user = _userData.GetUser();
            var target = $"{invocation.InvocationTarget.ToString()}.{invocation.Method.Name}";

            var beginInvoke = new TraceTelemetry($"Begin Invoke: {target}", SeverityLevel.Verbose);
            beginInvoke.Properties.Add("user", user.Username);
            beginInvoke.Properties.Add("parameters", string.Join(", ", invocation.Arguments.Select(a => (a ?? string.Empty).ToString())));
            _client.TrackTrace(beginInvoke);

            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                _client.TrackException(ex);
                throw;
            }

            var endInvoke = new TraceTelemetry($"End Invoke: {target}", SeverityLevel.Verbose);
            endInvoke.Properties.Add("user", user.Username);
            endInvoke.Properties.Add("result", invocation.ReturnValue == null ? string.Empty : invocation.ReturnValue.ToString());

            _client.TrackTrace(endInvoke);
        }
    }
}
