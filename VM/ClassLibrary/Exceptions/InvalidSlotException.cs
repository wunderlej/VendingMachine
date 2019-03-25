using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneProject
{
    public class InvalidSlotException : Exception
    {
        public InvalidSlotException() : base() { }
        public InvalidSlotException(string message) : base(message) { }
        public InvalidSlotException(string message, Exception inner) : base(message, inner) { }
    }
}
