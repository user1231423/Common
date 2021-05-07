namespace Common.ExceptionHandler.Exceptions
{
    using System;
    using System.Globalization;

    public class InternalException : Exception
    {
        public InternalException() : base()
        {
        }

        public InternalException(string message) : base(message)
        {
        }

        public InternalException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
