using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PasswordSystem.Backend.Models;
using PasswordSystem.Backend.Repository;
using System.Windows.Forms;

namespace PasswordSystem.Backend.Repository
{

    // F:/SAUGUMO TEST CHAMBER4
    public class FileSystemUtility
    {
       public void RegistrationAndEncryption(RegistratrionFormConstruct registratrionFormConstruct)
        {
            string filepath = "F:/SAUGUMO TEST CHAMBER4/" + registratrionFormConstruct.name + ".txt";
            File.Create(filepath).Dispose();
            string fileInput = registratrionFormConstruct.name + "," + registratrionFormConstruct.password + "," + 
                registratrionFormConstruct.application + "," + 
                registratrionFormConstruct.comment + "," + registratrionFormConstruct.passwordHash;

            File.WriteAllText(filepath, fileInput);
            FileInfo fileInfo = new FileInfo(filepath);
            AesEcnryption aesEcnryption = new AesEcnryption();
            aesEcnryption.FileEncryption(fileInfo);
        }

        public bool LoginDecryptionAndValidation(string username, string password,FileInfo fileInfo)
        {
            AesEcnryption aesEcnryption = new AesEcnryption();
            Argon2 argon2 = new Argon2();
            aesEcnryption.FileDecryption(fileInfo);
            FileInfo decryptedFile = new FileInfo(fileInfo.FullName.Substring(0, fileInfo.FullName.Length - 4));
            string fileString = File.ReadAllText(decryptedFile.FullName);
            string[] stringArray = fileString.Split(',');
            RegistratrionFormConstruct registratrionFormConstruct = new RegistratrionFormConstruct(stringArray[0],stringArray[1], stringArray[2], stringArray[3]);
            registratrionFormConstruct.passwordHash = stringArray[4];
            string hashComparisonString = argon2.Argon2Impl(aesEcnryption.PasswordEncryption(password));
            if (hashComparisonString.Equals(registratrionFormConstruct.passwordHash, StringComparison.Ordinal))
            {
                MessageBox.Show("Login Succesfull");                
                return true;
            }


            MessageBox.Show("Wrong password provided");
            aesEcnryption.FileEncryption(decryptedFile);
            return false;
        }
    }
}
