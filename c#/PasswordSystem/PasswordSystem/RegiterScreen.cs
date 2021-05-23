using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordSystem.Backend.Models;
using PasswordSystem.Backend.Repository;
using System.Web;
using System.Security.Cryptography;

namespace PasswordSystem
{
    public partial class RegiterScreen : Form
    {
        public RegiterScreen()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(nameBox.Text) && !String.IsNullOrWhiteSpace(passwordBox.Text) &&
                !String.IsNullOrWhiteSpace(applicationBox.Text) && !String.IsNullOrWhiteSpace(commentBox.Text))
            {
                RegistratrionFormConstruct registratrionFormConstruct = new RegistratrionFormConstruct(nameBox.Text, passwordBox.Text, applicationBox.Text, commentBox.Text);
                AesEcnryption ecnryption = new AesEcnryption();
                registratrionFormConstruct.password = ecnryption.PasswordEncryption(registratrionFormConstruct.password);
               // MessageBox.Show($"encrypted :{registratrionFormConstruct.password}");
              //  ecnryption.PasswordDecryption(Convert.FromBase64String(registratrionFormConstruct.password));
             //   MessageBox.Show($"Decrypted :{ecnryption.PasswordDecryption(Convert.FromBase64String(registratrionFormConstruct.password))}");
                Argon2 argon2 = new Argon2();
                registratrionFormConstruct = argon2.PassowrdHashing(registratrionFormConstruct);
                FileSystemUtility fileSystemUtility = new FileSystemUtility();
                fileSystemUtility.RegistrationAndEncryption(registratrionFormConstruct);
            }
            else MessageBox.Show("Please Fill out the form properly");
        }

        private void generatePassword_Click(object sender, EventArgs e)
        {
            passwordBox.Text = PasswordControls.GenerateToken(16);
        }

      
    }
}
