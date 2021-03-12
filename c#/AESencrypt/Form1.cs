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
        public static string bloks = "oijasd21n";
        public static bool mode;
        //public static byte[] salt;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.DefaultExt = ".txt";
           // bool? result = op.ShowDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                FileNameBox.Text = op.FileName;
                using (StreamReader src = new StreamReader(op.FileName))
                {
                    StartFileTextBox.Text = src.ReadToEnd();
                }

            }
        }
        public byte[] salt = GenerateSalt();
        public static RijndaelManaged aes = new RijndaelManaged();
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
           // FileStream fse = new FileStream(localLink, FileMode.Create);

            File.WriteAllText(localLink, EncryptedTextBox.Text);
           
            //MessageBox.Show(bbz);
           // string krva = AesEncry.AesDecryptas(bbz);
           // MessageBox.Show(krva);


            /*//byte[] salt = GenerateSalt();
            var localLink = FileNameBox.Text;//.Split('.')[0] + ".aes";
            //FileStream fs = new FileStream(localLink, FileMode.Create);
           // byte[] encryptedstring;
           using(StreamReader k = new StreamReader(localLink))
            {
                encryptedstring = k.ReadToEnd();
                MessageBox.Show(encryptedstring);
            }
            byte[] passwordBytes = Encoding.Unicode.GetBytes(PasswordBox.Text);
            //  RijndaelManaged aes = new RijndaelManaged();
           // FileStream fs = new FileStream(localLink, FileMode.Create);
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Padding = PaddingMode.PKCS7;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            if (checkBox1.Checked)
            {
                aes.Mode = CipherMode.ECB;
            }
            else
            {
                aes.Mode = CipherMode.CBC;
            }

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted;

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(encryptedstring);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
            MessageBox.Show(encrypted.ToString());



            *//* fs.Write(salt, 0, salt.Length);
             CryptoStream cs = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write);
             fs.Close();
             FileStream fsIn = new FileStream(FileNameBox.Text, FileMode.Open);
             byte[] buffer = new byte[108576];
             int read;
             try
             {
                 while((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                 {
                     fsIn.Write(buffer, 0, read);
                 }
             }
             catch(CryptographicException exc)
             {
                 MessageBox.Show($"{ exc}");
             }
             catch(Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                 fs.Close();
                 fsIn.Close();
                 using (StreamReader sr = new StreamReader(localLink))
                 {
                     EncryptedTextBox.Text = sr.ReadToEnd();
                 }
                 if (File.Exists(FileNameBox.Text))
                 {
                    // File.Delete(FileNameBox.Text);
                    // FileNameBox.Text = String.Empty;
                 }
             }*/


        }

        public static byte[] GenerateSalt()
        {
            byte[] data = new byte[32];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider()) {
                for (int i = 0; i < 10; i++)
                {
                    rng.GetBytes(data);
                }
                return data;
            }
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
            // bool? result = op.ShowDialog();
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
