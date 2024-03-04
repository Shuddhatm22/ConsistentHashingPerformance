using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsistentHashingDemo
{
    /// <summary>
    /// utils class for common helper functions
    /// </summary>
    public static class Utils
    {
        public static int GetMd5HashAsInteger(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                int hashValue = BitConverter.ToInt32(hashBytes, 0);
                return hashValue;
            }
        }
    }
}
