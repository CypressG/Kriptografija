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
    public partial class Form1 : Form
    {
        // F:/SAUGUMO TEST CHAMBER4

        private string testFileName = "F:/SAUGUMO TEST CHAMBER4/TestFileFromRequirements.txt";
        public Form1()
        {
            InitializeComponent();
            string testFile = "Paleidus sistemą " +
                    "pirmą kartą sukuriamas .csv arba .txt failas. " +
                    "Išjungiant sistemą šis failas turi būti užšifruojamas AES algoritmu. " +
                    "Kitą kartą paleidus sistemą failas yra dešifruojamas. (4 taškai)";            
            DirectoryInfo initial = new DirectoryInfo("F:/SAUGUMO TEST CHAMBER4");
            bool testFileExistance = false;
            FileInfo testFileInfo = null;

            foreach(FileInfo fileInfo in initial.GetFiles())
            {
                if (fileInfo.Name.Contains(testFileName))
                {
                    testFileExistance = true;
                    testFileInfo = fileInfo;
                }
            }
            if (testFileExistance)
            {
                AesEcnryption aesEcnryption = new AesEcnryption();

                aesEcnryption.FileDecryption(testFileInfo);
            }
            else
            {
                File.Create(testFileName).Dispose();
                File.WriteAllBytes(testFileName, Encoding.UTF8.GetBytes(testFile));

            }

            if(initial.GetFiles().Length == 0)
            {
                
                RegiterScreen regiterScreen = new RegiterScreen();
                regiterScreen.Show();      
                
            }


        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("F:/SAUGUMO TEST CHAMBER4");




            FileInfo testFile = new FileInfo("F:/SAUGUMO TEST CHAMBER4/admin.txt");
            AesEcnryption aesEcnryption = new AesEcnryption();

            aesEcnryption.FileEncryption(testFile);
            aesEcnryption.PasswordEncryption("admin");
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            FileInfo testFile = new FileInfo("F:/SAUGUMO TEST CHAMBER4/admin.txt" +".aes");
            AesEcnryption aesEcnryption = new AesEcnryption();
            aesEcnryption.FileDecryption(testFile);


        }
    }
}
