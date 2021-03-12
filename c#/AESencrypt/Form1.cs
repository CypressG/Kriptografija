using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;


namespace AESencrypt
{
    public partial class Form1 : Form
    {
        public static string paswordas;
        public static string bloks = "oijasd/21n964";
        public static bool mode;        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.DefaultExt = ".txt";
            if (op.ShowDialog() == DialogResult.OK)
            {
                FileNameBox.Text = op.FileName;
                using (StreamReader src = new StreamReader(op.FileName))
                {
                    StartFileTextBox.Text = src.ReadToEnd();
                }

            }
        }                
        public static string encryptedstring;
        private void EncryptButton_Click(object sender, EventArgs e)
        {
            string filetext;
            var localLink = FileNameBox.Text.Split('.')[0] + ".aes";
            FileStream fs = new FileStream(FileNameBox.Text, FileMode.Open);
            paswordas = PasswordBox.Text;
            if (checkBox1.Checked)
            {
                mode = true;
            }
            using (StreamReader rd = new StreamReader(fs))
            {
               filetext = rd.ReadToEnd();
            }
            fs.Close();
            MessageBox.Show(filetext);
            EncryptedTextBox.Text = AesEncry.AesEncryptas(filetext);
            File.WriteAllText(localLink, EncryptedTextBox.Text);
           
           


        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            var localLink = FileNameBox.Text.Split('.')[0] + "decrypted.txt";
            DecryptedTextBox.Text = AesEncry.AesDecryptas(EncryptedTextBox.Text);
            File.WriteAllText(localLink, DecryptedTextBox.Text);
                     
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.DefaultExt = ".txt";            
            if (op.ShowDialog() == DialogResult.OK)
            {
                FileNameBox.Text = op.FileName;
                using (StreamReader src = new StreamReader(op.FileName))
                {
                    StartFileTextBox.Text = src.ReadToEnd();
                }

            }

            File.WriteAllText(op.FileName, richTextBox1.Text);
            using (StreamReader src = new StreamReader(op.FileName))
            {
                StartFileTextBox.Text = src.ReadToEnd();
            }
        }
    }
}
