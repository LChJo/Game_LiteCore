using System;

namespace LiteFrame.Core
{
    public class ClassException: Exception
    {
        public ClassException() : base()
        {
        }

        public ClassException(string message) : base(message)
        {
        }

        public ClassException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}