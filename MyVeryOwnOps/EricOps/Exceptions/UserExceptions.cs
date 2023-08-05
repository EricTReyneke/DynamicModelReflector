using System;

namespace EricOps.Exceptions
{
    public class UserExceptions : Exception
    {
        public UserExceptions(string message)
        : base(message)
        {

        }
    }
}
