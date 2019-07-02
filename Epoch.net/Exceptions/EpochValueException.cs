using System;

namespace Epoch.net.Exceptions
{
    public class EpochValueException : Exception
    {
        public EpochValueException(string message)
            : base(message){}
    }
}