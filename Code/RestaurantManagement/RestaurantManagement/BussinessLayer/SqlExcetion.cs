using System;
using System.Runtime.Serialization;

namespace RestaurantManagement.BussinessLayer
{
    [Serializable]
    internal class SqlExcetion : Exception
    {
        public SqlExcetion()
        {
        }

        public SqlExcetion(string message) : base(message)
        {
        }

        public SqlExcetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SqlExcetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}