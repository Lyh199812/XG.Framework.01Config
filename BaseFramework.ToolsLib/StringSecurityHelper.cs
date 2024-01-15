











using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ToolsLib
{
    /// <summary>
    /// �ַ������ܽ�����
    /// </summary>
    public class StringSecurityHelper
    {

        private static string md5Begin = "Hello";
        private static string md5End = "World";

        #region SHA1 ����

        /// <summary>
        /// ʹ��SHA1�����ַ�����
        /// </summary>
        /// <param name="inputString">�����ַ�����</param>
        /// <returns>���ܺ���ַ�������40���ַ���</returns>
        public static string SHA1Encrypt(string inputString)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] encryptedBytes = sha1.ComputeHash(Encoding.ASCII.GetBytes(inputString));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", encryptedBytes[i]);
            }
            return sb.ToString();
        }

        #endregion

        #region DES ����/����

        private static byte[] key = Encoding.ASCII.GetBytes("uiertysd");
        private static byte[] iv = Encoding.ASCII.GetBytes("99008855");

        /// <summary>
        /// DES���ܡ�
        /// </summary>
        /// <param name="inputString">�����ַ�����</param>
        /// <returns>���ܺ���ַ�����</returns>
        public static string DESEncrypt(string inputString)
        {
            MemoryStream ms = null;
            CryptoStream cs = null;
            StreamWriter sw = null;

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateEncryptor(key, iv), CryptoStreamMode.Write);
                sw = new StreamWriter(cs);
                sw.Write(inputString);
                sw.Flush();
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            }
            finally
            {
                if (sw != null) sw.Close();
                if (cs != null) cs.Close();
                if (ms != null) ms.Close();
            }
        }

        /// <summary>
        /// DES���ܡ�
        /// </summary>
        /// <param name="inputString">�����ַ�����</param>
        /// <returns>���ܺ���ַ�����</returns>
        public static string DESDecrypt(string inputString)
        {
            MemoryStream ms = null;
            CryptoStream cs = null;
            StreamReader sr = null;

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                ms = new MemoryStream(Convert.FromBase64String(inputString));
                cs = new CryptoStream(ms, des.CreateDecryptor(key, iv), CryptoStreamMode.Read);
                sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                if (sr != null) sr.Close();
                if (cs != null) cs.Close();
                if (ms != null) ms.Close();
            }
        }

        #endregion


        /// <summary>
        /// MD5����
        /// </summary>
        /// <param name="str">MD5����ǰ�ַ���</param>
        /// <returns>MD5���ܺ��ַ���</returns>
        public static string MD5Encrypt(string str)
        {
            str = string.Concat(md5Begin, str, md5End);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.Unicode.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string md5String = string.Empty;
            foreach (var b in targetData)
                md5String += b.ToString("x2");
            return md5String;
        }
    }
}
