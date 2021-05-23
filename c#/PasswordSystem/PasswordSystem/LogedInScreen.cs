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
        FileInfo userFileS;
      public static  List<RegistratrionFormConstruct> userPasswordList = new List<RegistratrionFormConstruct>();
       public RegistratrionFormConstruct construct;
        public LogedInScreen(DirectoryInfo currentDir, string user)
        {
            InitializeComponent();            
            directoryInfo = currentDir;
            FileInfo userInfo = new FileInfo(currentDir.FullName + "/" + user + ".txt.aes");
            AesEcnryption aesEcnryption = new AesEcnryption();
            aesEcnryption.FileDecryption(userInfo);
            FileInfo userFile = new FileInfo(currentDir.FullName + "/" + user + ".txt");
            foreach(string line in File.ReadAllLines(userFile.FullName))
            {
                string[] afterSplit = line.Split(",");
                userPasswordList.Add(new RegistratrionFormConstruct(afterSplit[0], afterSplit[1], afterSplit[2], afterSplit[3]));
                passwordNameBox.Items.Add(afterSplit[0]);
            }
            userFileS = userFile;
            currentUser = user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            bool status = false;
            foreach(RegistratrionFormConstruct formConstruct in userPasswordList)
            {
                if (formConstruct.name.Equals(inputBox.Text, StringComparison.Ordinal))
                {
                    userPasswordList.Remove(formConstruct);
                    status = true;
                    break;
                }
                
            }
            if (!status)
            {
                MessageBox.Show($"Could not find password with that name :{inputBox.Text}");
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
            
            foreach (RegistratrionFormConstruct construct in userPasswordList)
            {             
                
                if (construct.name.Equals(inputBox.Text, StringComparison.Ordinal))
                {
                    passwordNameBox.Text = construct.name;
                    passwordBox.Text = construct.password;
                    status = true;
                }

            }
            if (!status)
            {
                MessageBox.Show($"Could not find  such password {inputBox.Text}");
            }
            
        }

        private void LogedInScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Create(userFileS.FullName).Dispose();
            using (StreamWriter streamWriter = new StreamWriter(userFileS.FullName))
            {
                foreach(RegistratrionFormConstruct registratrionFormConstruct in userPasswordList)
                {
                    string inputStr = registratrionFormConstruct.name + "," + registratrionFormConstruct.password +
                "," + registratrionFormConstruct.application + "," + registratrionFormConstruct.comment;
                    streamWriter.WriteLine(inputStr);
                }
            }

            AesEcnryption aesEcnryption = new AesEcnryption();
            aesEcnryption.FileEncryption(userFileS);

        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            AesEcnryption aesEcnryption = new AesEcnryption();
            passwordBox.Text = aesEcnryption.PasswordDecryption(Convert.FromBase64String(passwordBox.Text));
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            if (inputBox.Text.Equals(currentUser, StringComparison.Ordinal))
            {
                foreach (RegistratrionFormConstruct registratrion in userPasswordList)
                {
                    if (registratrion.name.Equals(inputBox.Text, StringComparison.Ordinal))
                    {
                        AesEcnryption aesEcnryption = new AesEcnryption();
                        registratrion.password = aesEcnryption.PasswordEncryption(newPasswordBox.Text);
                        PasswordControls.ChangeAccountPassword(registratrion);

                    }
                }
            }
            else
            {
                foreach (RegistratrionFormConstruct registratrion in userPasswordList)
                {
                    if (registratrion.name.Equals(inputBox.Text, StringComparison.Ordinal))
                    {
                        AesEcnryption aesEcnryption = new AesEcnryption();
                        registratrion.password = aesEcnryption.PasswordEncryption(newPasswordBox.Text);

                    }
                }
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordBox.Text);
        }

        private void passwordNameBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < passwordNameBox.Items.Count; ++ix)
            {
                if (ix != e.Index) passwordNameBox.SetItemChecked(ix, false);
            }
            foreach(object itemChecked in passwordNameBox.CheckedItems)
            {
                inputBox.Text = itemChecked.ToString();
            }
        }

        private void addNewPSWbutton_Click(object sender, EventArgs e)
        {
            NewPasswordCreation newPasswordCreation = new NewPasswordCreation();
            newPasswordCreation.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            passwordNameBox.Items.Clear();
            foreach(RegistratrionFormConstruct registratrionFormConstruct in userPasswordList)
            {
                passwordNameBox.Items.Add(registratrionFormConstruct.name);
            }
        }
    }
}
