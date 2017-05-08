using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64DiffService.Model
{
    /// <summary>
    /// Contains the two base64 values to compare
    /// </summary>
    public class Base64Data
    {
        public string Left { get; set; }

        public string Right { get; set; }

        /// <summary>
        /// Base64Data default constructor
        /// </summary>
        public Base64Data()
        {
        }

        /// <summary>
        /// Base64Data copy constructor
        /// </summary>
        /// <param name="copy">Object to copy</param>
        public Base64Data(Base64Data copy)
        {
            Left = copy.Left;
            Right = copy.Right;
        }
    }
}
