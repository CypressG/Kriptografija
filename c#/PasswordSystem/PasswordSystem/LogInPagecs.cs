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

namespace PasswordSystem
{
    public partial class LogInPagecs : Form
    {
        private string testFileName = "F:/SAUGUMO TEST CHAMBER4/TestFileFromRequirements.txt";
        private string encryptedPSW;
        public LogInPagecs()
        {
            InitializeComponent();
            InitialCheck();
            

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("F:/SAUGUMO TEST CHAMBER4");
            bool found = false;
            FileInfo foundFile =null;
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
                        login = fileSystemUtility.LoginDecryptionAndValidation(nameBox.Text, passwordBox.Text, fileInfo);
                        
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


           /* FileInfo testFile = new FileInfo("F:/SAUGUMO TEST CHAMBER4/admin.txt");
            AesEcnryption aesEcnryption = new AesEcnryption();

            aesEcnryption.FileEncryption(testFile);
            encryptedPSW = aesEcnryption.PasswordEncryption("admin");
            MessageBox.Show(encryptedPSW);*/
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegiterScreen register = new RegiterScreen();
            register.Show();

        }

        private void InitialCheck()
        {
            string testFile = "Paleidus sistemą " +
                    "pirmą kartą sukuriamas .csv arba .txt failas. " +
                    "Išjungiant sistemą šis failas turi būti užšifruojamas AES algoritmu. " +
                    "Kitą kartą paleidus sistemą failas yra dešifruojamas. (4 taškai)";
            DirectoryInfo initial = new DirectoryInfo("F:/SAUGUMO TEST CHAMBER4/");
            bool testFileExistance = false;
            FileInfo testFileInfo = null;

            foreach (FileInfo fileInfo in initial.GetFiles())
            {
                
                string fullname = fileInfo.Name;
                if (fullname.Contains("TestFileFromRequirements.txt"))
                {
                    testFileExistance = true;
                    FileInfo foundFile = new FileInfo(fileInfo.FullName);
                    testFileInfo = foundFile;                    
                }
            }
            if (testFileExistance == true)
            {
                AesEcnryption aesEcnryption = new AesEcnryption();

                aesEcnryption.FileDecryption(testFileInfo);
            }
            else
            {
                File.Create(testFileName).Dispose();
                File.WriteAllBytes(testFileName, Encoding.UTF8.GetBytes(testFile));

            }

            if (initial.GetFiles().Length == 0)
            {

                RegiterScreen regiterScreen = new RegiterScreen();
                regiterScreen.Show();

            }            
        }

        private void LogInPagecs_FormClosing(object sender, FormClosingEventArgs e)
        {
            AesEcnryption aesEcnryption = new AesEcnryption();
            FileInfo file = new FileInfo(testFileName);
            aesEcnryption.FileEncryption(file);          
        }
    }
}
