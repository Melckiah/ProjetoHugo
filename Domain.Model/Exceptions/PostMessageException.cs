using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model.Exceptions
{
    public class PostMessageException : Exception
    {
        public PostMessageException(string message): base(message) { }
    }
}
