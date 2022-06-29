using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool _success { get; }
        public string _message { get; }
        public Result(bool success, string message) : this(success)
        {
            _message = message;
        }
        public Result(bool success)
        {
            _success = success;
        }
    }
}
