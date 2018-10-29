using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Griedy.Lib.Exceptions
{
    [Serializable]
    public class SecurityException : Exception
    {
        public SecurityException()
            : base("You do not have permission to perform this operation.")
        {
        }

        protected SecurityException(SerializationInfo info, StreamingContext context)
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
