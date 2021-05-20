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
    public partial class RegiterScreen : Form
    {
        public RegiterScreen()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegistratrionFormConstruct registratrionFormConstruct = new RegistratrionFormConstruct(nameBox.Text,passwordBox.Text,applicationBox.Text,commentBox.Text);
            Argon2 argon2 = new Argon2();
            registratrionFormConstruct = argon2.PassowrdHashing(registratrionFormConstruct);
            richTextBox1.Text = registratrionFormConstruct.password;
        }
    }
}
