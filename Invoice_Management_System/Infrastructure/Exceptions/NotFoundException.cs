using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("My error occured")
        {

        }
        public NotFoundException(string message) : base(message)
        {

        }
        public NotFoundException(Exception exception) : this(exception.Message)
        {

        }
    }
}
