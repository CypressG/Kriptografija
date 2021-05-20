using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using PasswordSystem.Backend.Models;
using System.Windows.Forms;
using Konscious.Security.Cryptography;

namespace PasswordSystem.Backend.Repository
{
    public class Argon2
    {

        // SALT - fjH!wa+OAC#P*Avu
        public RegistratrionFormConstruct PassowrdHashing(RegistratrionFormConstruct registratrionFormConstruct)
        {
            string hash = Argon2Impl(registratrionFormConstruct.password);            
            registratrionFormConstruct.passwordHash = hash;
            return registratrionFormConstruct;
         
        }

        private string Argon2Impl(string password)
        {
            byte[] salt = new byte[16];
            salt = Encoding.UTF8.GetBytes("fjH!wa+OAC#P*Avu");
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
            argon2.DegreeOfParallelism = 8;
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 1024;
            string hash = Convert.ToBase64String(argon2.GetBytes(16));

            return hash;
        }



    }
}
