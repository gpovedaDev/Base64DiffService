using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64DiffService.Model
{
    /// <summary>
    /// Difference details when two base64 values are compared.
    /// </summary>
    public class DiffEdDetails
    {
        /// <summary>
        /// Gets or sets the off set.
        /// </summary>
        /// <value>The off set.</value>
        public int OffSet { get; set; }
        /// <summary>
        /// Gets or sets the difference length.
        /// </summary>
        /// <value>The length.</value>
        public int Length { get; set; }
    }
}
