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
using System.IO;

namespace PasswordSystem
{
    public partial class LogedInScreen : Form
    {
        public DirectoryInfo directoryInfo;
        string currentUser;
       public RegistratrionFormConstruct construct;
        public LogedInScreen(DirectoryInfo currentDir, string user)
        {
            InitializeComponent();            
            directoryInfo = currentDir;
            button2.Visible = false;
            changePasswordButton.Visible = false;
            currentUser = user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            bool status = false;
            foreach(FileInfo fileInfo in directoryInfo.GetFiles())
            {
                string[] filename = fileInfo.Name.Split('.');
                if (filename[0].Equals(inputBox.Text, StringComparison.Ordinal))
                {
                    MessageBox.Show($"user : {filename[0].ToString()} has been deleted");
                    File.Delete(fileInfo.FullName);
                    status = true;
                    break;
                }
                
            }
            if (!status)
            {
                MessageBox.Show($"Could not find  user {inputBox.Text}");
            }

        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            newPasswordBox.Text = PasswordControls.GenerateToken(16);
        }

        private void searchOptionButton_Click(object sender, EventArgs e)
        {
            bool status = false;
            string[] fileDataString = new string[4];
            AesEcnryption aesEcnryption = new AesEcnryption();
            FileInfo foundFile = null;
            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                string[] filename = fileInfo.Name.Split('.');
                if (filename[0].Equals(inputBox.Text, StringComparison.Ordinal))
                {
                    if (fileInfo.Name.Contains("aes"))
                    {
                        aesEcnryption.FileDecryption(fileInfo);
                        foundFile = fileInfo;
                        fileDataString = File.ReadAllText(fileInfo.FullName.Substring(0, fileInfo.FullName.Length - 3)).Split(',');
                        status = true;
                        break;
                    }
                    else
                    {
                        //  MessageBox.Show($"user : {filename[0].ToString()} has been deleted");
                        fileDataString = File.ReadAllText(fileInfo.FullName).Split(',');
                        foundFile = fileInfo;
                        status = true;
                        break;
                    }
                }

            }
            if (!status)
            {
                MessageBox.Show($"Could not find  user {inputBox.Text}");
            }
            else
            {
                RegistratrionFormConstruct registratrionFormConstruct = new RegistratrionFormConstruct();
                registratrionFormConstruct.name = fileDataString[0];
                registratrionFormConstruct.password = fileDataString[1];
                registratrionFormConstruct.application = fileDataString[2];
                registratrionFormConstruct.comment = fileDataString[3];
                registratrionFormConstruct.passwordHash = fileDataString[4];
                FileInfo fileInfo = new FileInfo(directoryInfo.FullName + "/" + inputBox.Text + ".txt");
                construct = registratrionFormConstruct;
                aesEcnryption.FileEncryption(fileInfo);
                button2.Visible = true;
                passwordBox.Text = registratrionFormConstruct.password;
                argon2TextBox.Text = registratrionFormConstruct.passwordHash;
                changePasswordButton.Visible = true;
            }
        }

        private void LogedInScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!File.Exists(directoryInfo.FullName + "/" + currentUser + ".txt.aes"))
            {
                FileInfo fileInfo = new FileInfo(directoryInfo.FullName + "/" + currentUser + ".txt");
                AesEcnryption aesEcnryption = new AesEcnryption();
                aesEcnryption.FileEncryption(fileInfo);
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            AesEcnryption aesEcnryption = new AesEcnryption();
            passwordBox.Text = aesEcnryption.PasswordDecryption(Convert.FromBase64String(passwordBox.Text));
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            AesEcnryption aesEcnryption = new AesEcnryption();
            Argon2 argon2 = new Argon2();
            construct.password = aesEcnryption.PasswordEncryption(newPasswordBox.Text);
            construct.passwordHash = argon2.Argon2Impl(construct.password);
            FileSystemUtility fileSystemUtility = new FileSystemUtility();
            fileSystemUtility.RegistrationAndEncryption(construct);
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordBox.Text);
        }
    }
}
