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

namespace RSAencryption
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            
            InitializeComponent();
            richTextBox2.LanguageOption = RichTextBoxLanguageOptions.DualFont;            
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            if (PrimeNumberCheck(int.Parse(textBox1.Text)) && PrimeNumberCheck(int.Parse(textBox2.Text))){

                RSAEncryption encrypt = new RSAEncryption();
                byte[] b;
                b= encrypt.RsaTextEncryption(int.Parse(textBox1.Text), int.Parse(textBox2.Text), richTextBox1.Text);
                richTextBox2.Text = Convert.ToBase64String(b);
                var localLink = "F:/SAUGUMO TEST CHAMBER 2/encrypted.txt";
                File.WriteAllText(localLink, Convert.ToBase64String(b));
                var localLink2 = "F:/SAUGUMO TEST CHAMBER 2/public_key.txt";
                string pubkey = $"{RSAEncryption.publicKey} {RSAEncryption.n}";
                File.WriteAllText(localLink2, pubkey);

                // byte[] test1 = Convert.FromBase64String(richTextBox2.Text);*/

            }
        }


        bool PrimeNumberCheck(int a)
        {
            if (a == 1) return false;
            if (a == 2) return true;

            var limit = Math.Ceiling(Math.Sqrt(a)); 

            for (int i = 2; i <= limit; ++i)
            {
                if (a % i == 0)
                {
                    MessageBox.Show($"Number : { a} is not a prime number");
                    return false;
                   // MessageBox.Show($"Number : { a} is not a prime number");
                }
            }
            return true;
        }
        
        private void Decrypt_Button_Click(object sender, EventArgs e)
        {
            var localLink = "F:/SAUGUMO TEST CHAMBER 2/encrypted.txt";
            string encryptedText = File.ReadAllText(localLink);

            var localLink2 = "F:/SAUGUMO TEST CHAMBER 2/public_key.txt";

            string keys = File.ReadAllText(localLink2);
            int[] arr = keys.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            RSAEncryption decrypt = new RSAEncryption();
            richTextBox4.Text = decrypt.RsaTextDecryption(arr[0], arr[1], encryptedText);

            
            //MessageBox.Show("vsio");


        }
    }
}
