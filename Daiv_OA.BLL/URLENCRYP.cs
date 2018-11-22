using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;//引用加密空间
using System.IO;
using System.Web.Security;
namespace Daiv_OA.BLL
{
    public  class URLENCRYP
    {
        #region dec 字符加密与解密
        public byte[] iv = { 34, 56, 76, 86, 98, 234, 8, 87 };
        public byte[] key = { 54, 66, 64, 40, 30, 69, 34, 73 };
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="strValue">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public string Encryp(string strValue)
        {
            string encryp;
            if (strValue != "")
            {
                try
                {
                    DESCryptoServiceProvider dsp = new DESCryptoServiceProvider();
                    MemoryStream memStrem = new MemoryStream();
                    using (memStrem)
                    {
                        CryptoStream crypstream = new CryptoStream(memStrem, dsp.CreateEncryptor(key, iv), CryptoStreamMode.Write);
                        StreamWriter sWriter = new StreamWriter(crypstream);
                        sWriter.Write(strValue);
                        sWriter.Flush();
                        crypstream.FlushFinalBlock();
                        encryp = Convert.ToBase64String(memStrem.GetBuffer(), 0, (int)memStrem.Length);

                    }
                }
                catch (ArgumentException)
                {
                    encryp = "";
                }
                catch (CryptographicException)
                {
                    encryp = "";
                }

            }
            else
            {
                encryp = "";
            }
            return encryp;
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="EncValue">加密后的字符串</param>
        /// <returns>解密后的字符串</returns>
        public  string Decryp(string EncValue)
        {
            string strvalue;
            if (EncValue != "")
            {
                try
                {
                    DESCryptoServiceProvider dsp = new DESCryptoServiceProvider();
                    byte[] buffer = Convert.FromBase64String(EncValue);
                    MemoryStream memStream = new MemoryStream();
                    using (memStream)
                    {
                        CryptoStream crypstream = new CryptoStream(memStream,
                        dsp.CreateDecryptor(key, iv), CryptoStreamMode.Write);
                        crypstream.Write(buffer, 0, buffer.Length);
                        crypstream.FlushFinalBlock();
                        strvalue = ASCIIEncoding.UTF8.GetString(memStream.ToArray());
                    }
                }
                catch (ArgumentException) { strvalue = null; }
            }
            else
            {
                strvalue = "";

            }

            return strvalue;
        }
        #endregion
        
    }
}

