using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Utilities.Results
{
    public interface IResult
    {
        public bool _success { get; }
        public string _message { get; }
    }
}
