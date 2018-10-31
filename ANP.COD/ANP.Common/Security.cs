using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANP.Common
{
    public static class SecurityClass
    {
        public static string strCalcMD5(string strItem)
        {
            string _strCalcMD5 = string.Empty;
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] _byte = System.Text.Encoding.UTF8.GetBytes(strItem);
            byte[] _hashedvalue = md5.ComputeHash(_byte);
            _strCalcMD5 = Convert.ToBase64String(_hashedvalue);
            return _strCalcMD5;
        }
        public static string Encode_Hex(string strItem)
        {
            string _strEncode_Hex = string.Empty;
            char[] values = strItem.ToCharArray();
            foreach (char letter in values)
            {
                int value = Convert.ToInt32(letter);
                _strEncode_Hex += String.Format("{0:x}", value);
            }
            return _strEncode_Hex;
        }
        public static string Decode_Hex(string strItem)
        {
            string _Decode_Hex = string.Empty;
            for (int intLoop = 0; intLoop < strItem.Length; intLoop += 2)
            {
                _Decode_Hex += (char)Convert.ToInt32(strItem.Substring(intLoop, 2), 16);
            }
            return _Decode_Hex;
        }
        public static string Base64ToHex(string input)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            foreach (byte b in inputBytes)
            {
                sb.Append(string.Format("{0:x2}", b));
            }
            return sb.ToString();
        }
        
    }
}
