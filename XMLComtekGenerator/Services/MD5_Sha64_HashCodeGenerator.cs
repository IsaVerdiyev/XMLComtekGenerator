using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XMLComtekGenerator.Interfaces;

namespace XMLComtekGenerator.Services
{
    class MD5_Sha64_HashCodeGenerator : IHashCodeGenerator
    {
        public string GenerateHash(IEnumerable<string> words)
        {
            
            using(MD5 md5 = MD5.Create())
            {
                byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(string.Join("",words)));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
