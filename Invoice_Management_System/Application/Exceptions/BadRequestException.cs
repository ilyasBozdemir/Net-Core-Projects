﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base("My error occured")
        {

        }
        public BadRequestException(string message) : base(message)
        {

        }
        public BadRequestException(Exception exception) : this(exception.Message)
        {

        }
    }
}
