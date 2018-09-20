using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DelPhiCommon
{
   public class Encryption
    {
        /// <summary>
        /// 密码加密 MD5 盐值加密
        /// </summary>
        /// <param name="password">明文</param>
        /// <returns>密文</returns>
        public string MD5Encrypt(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.UTF8.GetBytes(password + "asm"));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("X").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

    }
}
