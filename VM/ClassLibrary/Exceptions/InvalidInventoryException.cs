using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneProject
{
    public class InvalidInventoryException : Exception
    {
        public InvalidInventoryException() : base() { }
        public InvalidInventoryException(string message) : base(message) { }
        public InvalidInventoryException(string message, Exception inner) : base(message, inner) { }
    }
}
