using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64DiffService
{
    public enum Side { Left = 1, Right = 2}

    public enum DiffEdResultType { Equals, ContentDoNotMatch, SizeDoNotMatch, Error }

    public enum ResponseResult 
    {
        Created = 1,
        Error = -1,
        NotFound = -2
    }
}
