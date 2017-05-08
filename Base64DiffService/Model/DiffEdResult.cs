using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Base64DiffService.Model
{
    /// <summary>
    /// Contains difference details 
    /// </summary>
    public class DiffEdResult
    {
        DiffEdResultType _diffedResultType = DiffEdResultType.Equals;

        [JsonConverter(typeof(StringEnumConverter))]
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>A DiffResultType indicating the comparison state</value>
        public DiffEdResultType DiffResultType
        {
            get { return _diffedResultType; }
            set { _diffedResultType = value; }
        }

        List<DiffEdDetails> _diffs = new List<DiffEdDetails>();
        /// <summary>
        /// Gets or sets the diffs.
        /// </summary>
        /// <value>A list of DiffDetails</value>
        public List<DiffEdDetails> Diffs
        {
            get { return _diffs; }
            set { _diffs = value; }
        }

        /// <summary>
        /// Shoulds the serialize diffs.
        /// </summary>
        /// <returns>If true, include diff property in the JSON message</returns>
        public bool ShouldSerializeDiffs()
        {
            if (_diffs.Count == 0)
                return false;
            else
                return true;
        }
    }
}
