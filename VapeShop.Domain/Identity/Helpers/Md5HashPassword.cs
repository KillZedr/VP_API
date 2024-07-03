using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.Identity.Helpers
{
    public class Md5HashPassword
    {
        public static string HashPassvord(string password)
        {
            MD5 mD5 = MD5.Create();

            byte[] b = Encoding.ASCII.GetBytes(password);
            byte[] hash = mD5.ComputeHash(b);

            StringBuilder sb = new StringBuilder();
            foreach (var a in hash)
                sb.Append(a.ToString("X2"));
            
            return Convert.ToString(sb);

        }
    }
}
