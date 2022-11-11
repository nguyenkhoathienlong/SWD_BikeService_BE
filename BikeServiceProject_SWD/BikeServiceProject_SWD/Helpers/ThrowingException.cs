﻿using System.Globalization;

namespace BikeServiceProject_SWD.Helpers
{
    public class ThrowingException : Exception
    {
        public ThrowingException() : base() { }

        public ThrowingException(string message) : base(message) { }

        public ThrowingException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
