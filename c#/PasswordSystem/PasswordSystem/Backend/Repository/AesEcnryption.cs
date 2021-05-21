using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace PasswordSystem.Backend.Repository
{

    
   public class AesEcnryption
    {
        private static byte[] Salt = new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 };
        private static byte[] passwordBytes = Encoding.ASCII.GetBytes("uPzgMwP7BBCAj9t4UkKcAA==");
        private static byte[] key;
        private static byte[] IV;

        /// <summary>
        // uPzgMwP7BBCAj9t4UkKcAA==
        /// </summary>
        public void FileEncryption(FileInfo targetFile)
        {

            RijndaelManaged encdec = new RijndaelManaged();
            encdec.BlockSize = 128;
            encdec.KeySize = 256;
            var keygenerator = new Rfc2898DeriveBytes(passwordBytes, Salt, 3000);
            encdec.Key = keygenerator.GetBytes(encdec.KeySize / 8);
            key = encdec.Key;
            encdec.IV = keygenerator.GetBytes(encdec.BlockSize / 8);
            IV = encdec.IV;
            encdec.Mode = CipherMode.CBC;
            


            FileStream fsCrypt = new FileStream(targetFile.FullName + ".aes", FileMode.Create);
            fsCrypt.Write(Salt, 0, Salt.Length);


            CryptoStream cs = new CryptoStream(fsCrypt, encdec.CreateEncryptor(key, IV), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(targetFile.FullName, FileMode.Open);


            byte[] buffer = new byte[1048576];
            int read;


            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    cs.Write(buffer, 0, read);
                }


                fsIn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
                File.Delete(targetFile.FullName);
            }

        }


        public void FileDecryption(FileInfo targetFile)
        {



            RijndaelManaged encdec = new RijndaelManaged();
            encdec.BlockSize = 128;
            encdec.KeySize = 256;
            var keygenerator = new Rfc2898DeriveBytes(passwordBytes, Salt, 3000);
            encdec.Key = keygenerator.GetBytes(encdec.KeySize / 8);
            key = encdec.Key;
            encdec.IV = keygenerator.GetBytes(encdec.BlockSize / 8);
            IV = encdec.IV;
            encdec.Mode = CipherMode.CBC;

            FileStream fsCrypt = new FileStream(targetFile.FullName, FileMode.Open);
            fsCrypt.Read(Salt, 0, Salt.Length);


            CryptoStream cs = new CryptoStream(fsCrypt, encdec.CreateDecryptor(key, IV), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(targetFile.FullName.Replace(".aes", ""), FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fsOut.Write(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
                File.Delete(targetFile.FullName);
                
            }
        }

        public string PasswordEncryption(string password)
        {
            byte[] encrypted;
            RijndaelManaged encdec = new RijndaelManaged();
            encdec.BlockSize = 128;
            encdec.KeySize = 256;
            var keygenerator = new Rfc2898DeriveBytes(passwordBytes, Salt, 3000);
            encdec.Key = keygenerator.GetBytes(encdec.KeySize / 8);
            key = encdec.Key;
            encdec.IV = keygenerator.GetBytes(encdec.BlockSize / 8);
            IV = encdec.IV;
            encdec.Mode = CipherMode.CBC;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(password);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            string encryptedPassword = Convert.ToBase64String(encrypted);
            
            return encryptedPassword;
        }

        public string PasswordDecryption(byte[] cipherText)
        {

            
            RijndaelManaged encdec = new RijndaelManaged();
            encdec.BlockSize = 128;
            encdec.KeySize = 256;
            var keygenerator = new Rfc2898DeriveBytes(passwordBytes, Salt, 3000);
            encdec.Key = keygenerator.GetBytes(encdec.KeySize / 8);
            key = encdec.Key;
            encdec.IV = keygenerator.GetBytes(encdec.BlockSize / 8);
            IV = encdec.IV;
            encdec.Mode = CipherMode.CBC;

            string plaintext;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            
            return plaintext;
        }
               

    }
}
