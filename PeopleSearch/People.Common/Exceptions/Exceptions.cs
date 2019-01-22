using System;

namespace People.Common.Exceptions
{
    public class Exceptions : Exception
    {
        public Exceptions(string message)
            : base(message)
        {
        }

        public Exceptions(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class FailedValidationException : Exception
    {
        public FailedValidationException(string message)
            : base(message)
        {
        }

        public FailedValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class ErrorException : Exception
    {
        public ErrorException(string message)
            : base(message)
        {
        }

        public ErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }

    public class InformativeException : Exception
    {
        public InformativeException(string message)
            : base(message)
        {
        }

        public InformativeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
