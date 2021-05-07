namespace Common.ExceptionHandler.Exceptions
{
    using System;
    using System.Globalization;

    public class NotImplementedException : Exception
    {
        public NotImplementedException() : base()
        {
        }

        public NotImplementedException(string message) : base(message)
        {
        }

        public NotImplementedException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
