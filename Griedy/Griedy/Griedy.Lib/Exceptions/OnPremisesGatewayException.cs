using System;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Griedy.Lib.Exceptions
{
    [Serializable]
    public class OnPremisesGatewayException : Exception
    {
        public OnPremisesGatewayException(HttpRequestMessage request, HttpResponseMessage response)
            : base($"On Premises Gateway Exception: (Method: {request.Method.ToString()}; Code: {response.StatusCode}; Content: {response.Content.ReadAsStringAsync().Result})")
        {
        }

        protected OnPremisesGatewayException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
