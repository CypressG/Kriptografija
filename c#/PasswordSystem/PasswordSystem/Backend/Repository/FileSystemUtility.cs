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
            AesEcnryption aesEcnryption = new AesEcnryption();
            string filepath = "F:/SAUGUMO TEST CHAMBER4/PasswordSystemFiles/AccountList.txt";            
            string fileInput = registratrionFormConstruct.name +
                "," + registratrionFormConstruct.passwordHash;
            FileInfo fileInfo = new FileInfo(filepath);
            if (File.Exists(fileInfo.FullName + ".aes"))
            {
                FileInfo accountList = new FileInfo(fileInfo.FullName + ".aes");
                aesEcnryption.FileDecryption(accountList);
                foreach(string s in File.ReadAllLines(fileInfo.FullName))
                {
                    string[] comparison = s.Split(',');
                    if (comparison[0].Equals(registratrionFormConstruct.name, StringComparison.Ordinal))
                    {
                        MessageBox.Show("Such user allready exists");
                        aesEcnryption.FileEncryption(fileInfo);
                        return;
                    }    
                }
            }
            string dirPath = "F://SAUGUMO TEST CHAMBER4//PasswordSystemFiles";
            Directory.CreateDirectory(dirPath);
            File.Create("F:/SAUGUMO TEST CHAMBER4/PasswordSystemFiles/" + registratrionFormConstruct.name + ".txt").Dispose();
            string inputStr = registratrionFormConstruct.name + "," + registratrionFormConstruct.password +
                "," + registratrionFormConstruct.application + "," + registratrionFormConstruct.comment;
            File.WriteAllLines("F:/SAUGUMO TEST CHAMBER4/PasswordSystemFiles/" + registratrionFormConstruct.name + ".txt", new[] { inputStr });
            FileInfo userFile = new FileInfo("F:/SAUGUMO TEST CHAMBER4/PasswordSystemFiles/" + registratrionFormConstruct.name + ".txt");
            aesEcnryption.FileEncryption(userFile);

            File.AppendAllLines(filepath,new[] { fileInput });          
            
            aesEcnryption.FileEncryption(fileInfo);
        }

        public bool LoginDecryptionAndValidation(string username, string password)
        {
            FileInfo fileInfo = new FileInfo("F:/SAUGUMO TEST CHAMBER4/PasswordSystemFiles/AccountList.txt.aes");
            AesEcnryption aesEcnryption = new AesEcnryption();
            if (File.Exists("F:/SAUGUMO TEST CHAMBER4/PasswordSystemFiles/AccountList.txt.aes"))
            {                
                aesEcnryption.FileDecryption(fileInfo);
                List<LoginValidationConstructcs> validationConstructcs = new List<LoginValidationConstructcs>();
                foreach(string line in File.ReadAllLines(fileInfo.FullName.Replace(".aes", "")))
                    {
                     string[] array = line.Split(',');
                    validationConstructcs.Add(new LoginValidationConstructcs(array[0], array[1]));
                    }
                foreach (LoginValidationConstructcs loginValidationConstructcs in validationConstructcs)
                {
                    if (loginValidationConstructcs.username.Equals(username))
                    {
                        Argon2 argon2 = new Argon2();
                        string encryptedPSW = aesEcnryption.PasswordEncryption(password);
                        string inputHash = argon2.Argon2Impl(encryptedPSW);
                        if (inputHash.Equals(loginValidationConstructcs.hashValue, StringComparison.Ordinal))
                        {
                            FileInfo accountList = new FileInfo(fileInfo.FullName.Replace(".aes", ""));
                            aesEcnryption.FileEncryption(accountList);
                            MessageBox.Show("Login Succesfull");
                            return true;
                        }
                    }
                }
            }

            MessageBox.Show("Wrong password provided");
            FileInfo decryptedFile = new FileInfo(fileInfo.FullName.Replace(".aes", ""));
            aesEcnryption.FileEncryption(decryptedFile);
            return false;
        }
    }
}
