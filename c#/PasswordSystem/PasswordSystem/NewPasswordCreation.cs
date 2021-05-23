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

namespace PasswordSystem
{
    public partial class NewPasswordCreation : Form
    {
        public NewPasswordCreation()
        {
            InitializeComponent();
        }

        private void addButton1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(nameBox.Text) && !String.IsNullOrWhiteSpace(pswBox.Text) &&
               !String.IsNullOrWhiteSpace(appBox.Text) && !String.IsNullOrWhiteSpace(commBox.Text))
            {
                                
                RegistratrionFormConstruct registratrionFormConstruct = new RegistratrionFormConstruct(nameBox.Text, pswBox.Text, appBox.Text, commBox.Text);
                AesEcnryption ecnryption = new AesEcnryption();
                registratrionFormConstruct.password = ecnryption.PasswordEncryption(registratrionFormConstruct.password);
                LogedInScreen.userPasswordList.Add(registratrionFormConstruct);              
                
                
            }
            else MessageBox.Show("Please Fill out the form properly");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pswBox.Text =PasswordControls.GenerateToken(16);
        }
    }
}
