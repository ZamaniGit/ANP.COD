using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace ANP.Data.BaseData
{
    public class Library
    {
        public class Encryption
        {
            public static string Encrypt(string StrCode)
            {
                return Rijndael.Encrypt(StrCode, "!@#$%^", "XXXXXXXXS", "MD5", 1, "XYZxyzAZSawsTRCE", 128);
            }

            public static string Encrypt(int StrCode)
            {
                return Rijndael.Encrypt(StrCode.ToString(), "!@#$%^", "XXXXXXXXS", "MD5", 1, "XYZxyzAZSawsTRCE", 128);
            }

            public static string Decrypt(string StrCode)
            {
                return Rijndael.Decrypt(StrCode.Replace(' ', '+'), "!@#$%^", "XXXXXXXXS", "MD5", 1, "XYZxyzAZSawsTRCE", 128);
            }
        }
    }
}