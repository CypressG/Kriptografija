using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AESencrypt
{
    class AesEncry
    {
        private static readonly byte[] Salt =
        new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 };
        private static byte[] raktas;
        private static byte[] romenas;
        public static string  AesEncryptas(string textas)
        {
            byte[] textbytes = ASCIIEncoding.ASCII.GetBytes(textas);
            AesCryptoServiceProvider encdec = new AesCryptoServiceProvider();
            encdec.BlockSize = 128;
            encdec.KeySize = 256;
            var keygenerator = new Rfc2898DeriveBytes(Form1.paswordas, Salt,300);
            encdec.Key = keygenerator.GetBytes(encdec.KeySize / 8);
            raktas = encdec.Key;
            encdec.IV = keygenerator.GetBytes(encdec.BlockSize / 8);
            romenas = encdec.IV;
            encdec.Padding = PaddingMode.PKCS7;
            if (Form1.mode == false)
            {
                encdec.Mode = CipherMode.CBC;
            }
            else
            {
                encdec.Mode = CipherMode.ECB;
            }

            ICryptoTransform icrypt = encdec.CreateEncryptor(encdec.Key, encdec.IV);
            byte[] enc = icrypt.TransformFinalBlock(textbytes, 0, textbytes.Length);
            icrypt.Dispose();
            return Convert.ToBase64String(enc);
        }


        public static string AesDecryptas(string textas)
        {
            byte[] encbytes = Convert.FromBase64String(textas);
            AesCryptoServiceProvider encdec = new AesCryptoServiceProvider();
            encdec.BlockSize = 128;
            encdec.KeySize = 256;          
            encdec.Padding = PaddingMode.PKCS7;
            if (Form1.mode == false)
            {
                encdec.Mode = CipherMode.CBC;
            }
            else
            {
                encdec.Mode = CipherMode.ECB;
            }

            ICryptoTransform icrypt = encdec.CreateDecryptor(raktas, romenas);
            byte[] decrytu = icrypt.TransformFinalBlock(encbytes, 0, encbytes.Length);
            icrypt.Dispose();
            return ASCIIEncoding.ASCII.GetString(decrytu);
        }
       
    }
}
