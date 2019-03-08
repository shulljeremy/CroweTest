using System;

namespace SharedApi.Exceptions
{
    public class UnknownTypeException : Exception
    {
        public UnknownTypeException()
        {
        }

        public UnknownTypeException(string message) : base(message)
        {
        }

        public UnknownTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
