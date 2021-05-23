using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PasswordSystem.Backend.Models;
using PasswordSystem.Backend.Repository;
using System.IO.Compression;

namespace PasswordSystem
{
    public partial class LogInPagecs : Form
    {        
        
        public LogInPagecs()
        {
            InitializeComponent();
            InitialCheck();
            

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("F:/SAUGUMO TEST CHAMBER4/PasswordSystemFiles");
            bool found = false;
            
            bool login = false;

            if (!String.IsNullOrWhiteSpace(nameBox.Text) && !String.IsNullOrWhiteSpace(passwordBox.Text))
            {
                foreach(FileInfo fileInfo in directoryInfo.GetFiles())
                {
                    string comparison = fileInfo.Name.Substring(0,fileInfo.Name.Length-8);
                    if (comparison.Equals(nameBox.Text,StringComparison.Ordinal))
                    {                        
                        found = true;
                        FileSystemUtility fileSystemUtility = new FileSystemUtility();
                        login = fileSystemUtility.LoginDecryptionAndValidation(nameBox.Text, passwordBox.Text);
                        
                    }

                }
                if (!found)
                {
                    MessageBox.Show("Such user does not exist");
                }
                if (login)
                {
                    LogedInScreen logedInScreen = new LogedInScreen(directoryInfo,nameBox.Text);
                    logedInScreen.Show();
                }
            }
            else MessageBox.Show("Please input proper login credentials");


           
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegiterScreen register = new RegiterScreen();
            register.Show();

        }

        private void InitialCheck()
        {
           
            DirectoryInfo initial = new DirectoryInfo("F:/SAUGUMO TEST CHAMBER4/");            
            FileInfo testFileInfo = null;
            AesEcnryption aesEcnryption = new AesEcnryption();

            if(File.Exists("F:/SAUGUMO TEST CHAMBER4/Area51.zip.aes"))
            {
                testFileInfo = new FileInfo("F:/SAUGUMO TEST CHAMBER4/Area51.zip.aes");
                aesEcnryption.FileDecryption(testFileInfo);
                ZipFile.ExtractToDirectory(testFileInfo.FullName.Replace(".aes",""), initial.FullName + "PasswordSystemFiles");
                File.Delete(testFileInfo.FullName.Replace(".aes",""));
            }
            else
            {
                RegiterScreen regiterScreen = new RegiterScreen();
                regiterScreen.Show();
            }
        }

        private void LogInPagecs_FormClosing(object sender, FormClosingEventArgs e)
        {
            AesEcnryption aesEcnryption = new AesEcnryption();
            string zipFileOutput = "F:/SAUGUMO TEST CHAMBER4/Area51.zip";
            string directoryZip = @"F:\SAUGUMO TEST CHAMBER4\PasswordSystemFiles\";
            ZipFile.CreateFromDirectory(directoryZip, zipFileOutput);
            FileInfo file = new FileInfo(zipFileOutput);
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryZip);
            foreach(FileInfo fileInfo in directoryInfo.GetFiles())
            {
                File.Delete(fileInfo.FullName);
            }
            Directory.Delete("F:/SAUGUMO TEST CHAMBER4/PasswordSystemFiles");
            
            aesEcnryption.FileEncryption(file);          
        }
    }
}
