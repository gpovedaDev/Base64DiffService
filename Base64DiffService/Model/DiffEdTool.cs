using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64DiffService.Model
{
    /// <summary>
    /// Set of tools for text manipulation 
    /// </summary>
    public static class DiffEdTool
    {
        /// <summary>
        /// Compare two encoded base64 values. Returns a DiffResult that contains the comparison results
        /// </summary>
        /// <param name="str1">base64 text</param>
        /// <param name="str2">base64 text</param>
        public static DiffEdResult CompareBase64(string str1, string str2)
        {
            DiffEdResult retval = new DiffEdResult();

            try
            {
                byte[] left = Convert.FromBase64String(str1);
                byte[] right = Convert.FromBase64String(str2);
                int diffLength = 0;

                //To start comparing both base64 values should have the same size
                if (left.Length == right.Length)
                {
                    //Go through each byte in left and right variables and check for diffs
                    for (int index = 0; index < left.Length; index++)
                    {
                        if (left[index] != right[index])
                        {
                            diffLength++;

                            if (diffLength > 1)
                            {
                                DiffEdDetails lastDiffDetail = retval.Diffs.Last();
                                lastDiffDetail.Length = diffLength;
                            }
                            else
                                retval.Diffs.Add(new DiffEdDetails() { OffSet = index, Length = diffLength });
                        }
                        else
                            diffLength = 0;
                    }

                    if (retval.Diffs.Count.Equals(0))
                        retval.DiffResultType = DiffEdResultType.Equals;
                    else
                        retval.DiffResultType = DiffEdResultType.ContentDoNotMatch;
                }
                else
                    retval.DiffResultType = DiffEdResultType.SizeDoNotMatch;
            }
            catch (Exception ex)
            {
                retval.DiffResultType = DiffEdResultType.Error;
                System.Console.Out.WriteLine(ex);
            }

            return retval;
        }
    }
}
