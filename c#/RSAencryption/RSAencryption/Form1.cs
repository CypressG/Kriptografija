using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSAencryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            if (PrimeNumberCheck(int.Parse(textBox1.Text)) && PrimeNumberCheck(int.Parse(textBox2.Text))){


            }
        }


        bool PrimeNumberCheck(int a)
        {
            if (a == 1) return false;
            if (a == 2) return true;

            var limit = Math.Ceiling(Math.Sqrt(a)); //hoisting the loop limit

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

            
    }
}
