using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
namespace NnerSoft.Bas.DBUtility
{
	public class DESEncrypt
	{
		public static string Encrypt(string Text)
		{
			return DESEncrypt.Encrypt(Text, "NNERSOFT");
		}
        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string Md5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }


        //public static string Encrypt(string Text, string sKey)
        //{
        //    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        //    byte[] inputByteArray;
        //    inputByteArray = Encoding.Default.GetBytes(Text);
        //    des.Key = ASCIIEncoding.ASCII.GetBytes(MD5(sKey).Substring(0, 8));
        //    des.IV = ASCIIEncoding.ASCII.GetBytes(MD5(sKey.Substring(0, 8));
        //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
        //    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
        //    cs.Write(inputByteArray, 0, inputByteArray.Length);
        //    cs.FlushFinalBlock();
        //    StringBuilder ret = new StringBuilder();
        //    foreach (byte b in ms.ToArray())
        //    {
        //        ret.AppendFormat("{0:X2}", b);
        //    }
        //    return ret.ToString();
        //}

        //public static string MD5(string str)
        //{
        //    //微软md5方法参考return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
        //    byte[] b = Encoding.Default.GetBytes(str);
        //    b = new MD5CryptoServiceProvider().ComputeHash(b);
        //    string ret = "";
        //    for (int i = 0; i < b.Length; i++)
        //        ret += b[i].ToString("x").PadLeft(2, '0');
        //    return ret;
        //}


        public static string Encrypt(string Text, string sKey)
		{
			System.Security.Cryptography.DESCryptoServiceProvider dESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
			byte[] bytes = System.Text.Encoding.Default.GetBytes(Text);
            dESCryptoServiceProvider.Key = System.Text.Encoding.ASCII.GetBytes(Md5Hash(sKey).Substring(0, 8));
            dESCryptoServiceProvider.IV = System.Text.Encoding.ASCII.GetBytes(Md5Hash(sKey).Substring(0, 8));
            //dESCryptoServiceProvider.Key = System.Text.Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            //dESCryptoServiceProvider.IV = System.Text.Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
			System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			byte[] array = memoryStream.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				byte b = array[i];
				stringBuilder.AppendFormat("{0:X2}", b);
			}
			return stringBuilder.ToString();
		}
		public static string Decrypt(string Text)
		{
			return DESEncrypt.Decrypt(Text, "NNERSOFT");
		}
		public static string Decrypt(string Text, string sKey)
		{
			System.Security.Cryptography.DESCryptoServiceProvider dESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
			int num = Text.Length / 2;
			byte[] array = new byte[num];
			for (int i = 0; i < num; i++)
			{
				int num2 = System.Convert.ToInt32(Text.Substring(i * 2, 2), 16);
				array[i] = (byte)num2;
			}
            dESCryptoServiceProvider.Key = System.Text.Encoding.ASCII.GetBytes(Md5Hash(sKey).Substring(0, 8));
            dESCryptoServiceProvider.IV = System.Text.Encoding.ASCII.GetBytes(Md5Hash(sKey).Substring(0, 8));
            //dESCryptoServiceProvider.Key = System.Text.Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            //dESCryptoServiceProvider.IV = System.Text.Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
			System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			return System.Text.Encoding.Default.GetString(memoryStream.ToArray());
		}
	}
}
