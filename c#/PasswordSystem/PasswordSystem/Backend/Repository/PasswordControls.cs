using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using PasswordSystem.Backend.Models;
using PasswordSystem.Backend.Repository;
using System.IO;

namespace PasswordSystem.Backend.Repository
{
   public class PasswordControls
    {
              


        public static string GenerateToken(int length)
        {
            using (RNGCryptoServiceProvider cryptRNG = new RNGCryptoServiceProvider())
            {
                byte[] tokenBuffer = new byte[length];
                cryptRNG.GetBytes(tokenBuffer);
                return Convert.ToBase64String(tokenBuffer);
            }
        }

        public static void ChangeAccountPassword(RegistratrionFormConstruct registratrionFormConstruct)
        {
            FileInfo fileInfo = new FileInfo("F:/SAUGUMO TEST CHAMBER4/PasswordSystemFiles/AccountList.txt.aes");
            AesEcnryption aesEcnryption = new AesEcnryption();
            
            aesEcnryption.FileDecryption(fileInfo);
            FileInfo info = new FileInfo(fileInfo.FullName.Replace(".aes", ""));
            List<LoginValidationConstructcs> loginValidationConstructcs = new List<LoginValidationConstructcs>();
          //  LoginValidationConstructcs loginValidationConstructcs = new LoginValidationConstructcs();
            foreach(string line in File.ReadAllLines(fileInfo.FullName.Replace(".aes", "")))
            {
                string[] splitString = line.Split(",");
                loginValidationConstructcs.Add(new LoginValidationConstructcs(splitString[0], splitString[1]));
               
            }
            foreach(LoginValidationConstructcs constructcs in loginValidationConstructcs)
            {
                if (constructcs.username.Equals(registratrionFormConstruct.name, StringComparison.Ordinal))
                {
                    Argon2 argon2 = new Argon2();
                    constructcs.hashValue = argon2.Argon2Impl(registratrionFormConstruct.password);
                }
            }
            File.Create(fileInfo.FullName.Replace(".aes", "")).Dispose();
            List<string> inputList = new List<string>();
            foreach(LoginValidationConstructcs login in loginValidationConstructcs)
            {
                string input = login.username + "," + login.hashValue;
                inputList.Add(input);
                
            }
            File.AppendAllLines(info.FullName, inputList);
            aesEcnryption.FileEncryption(info);
        }






    }
}
