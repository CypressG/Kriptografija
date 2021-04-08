using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Numerics;


namespace RSAencryption
{
  public class RSAEncryption
    {
        public static Int64 n;
        private Int64 privateKey;
        public static Int64 publicKey;
        public static Int64 coprimesTotal;
        public static Int64[] encryptedString;
        private string decryptedString;

       public byte[] RsaTextEncryption(int p, int q , string text)
        {
            n = FindingN(p, q);
            coprimesTotal = FindingCoprimesTotal(p, q);
            publicKey = PublicKeyGenerator(coprimesTotal, n);          
            encryptedString = EncryptionRsa(publicKey, n, text);                    
                       
            
            byte[] encryptedBytes = encryptedString.Select(i => (byte)i).ToArray();        
         

            return encryptedBytes;
        }

        public string RsaTextDecryption(int pubKey, int bigN,string text)
        {
            
            privateKey = PrivateKeyGenerator(pubKey, coprimesTotal);
            decryptedString = DecryptionRsa(privateKey, bigN, encryptedString);        


            return decryptedString;
        }

        
        public Int64 FindingCoprimesTotal(int p , int q)
        {
            return (p - 1) * (q - 1);
        }


        public Int64 PublicKeyGenerator(Int64 copriTotal, Int64 n2)
        {
            for (int i = 2; i < copriTotal; i++)
            {
                if(!Coprime(i,copriTotal))
                {
                    continue;
                }
                else if (Coprime(i, n2))
                {
                    MessageBox.Show($"my public key :{i}");
                    return i;
                  //  MessageBox.Show($"my public key :{i}");                    
                }
                
            }

            return 0;
        }

        public Int64 PrivateKeyGenerator(Int64 e, Int64 n4)
        {
            int i = 1;
            
            while((e * i) % n4 != 1)
            {
                if (e * i % n4 == 1)
                {
                    
                    MessageBox.Show($"mano rastas D : {i}");
                   
                        return i;                    
                }
                i++;
            }
            MessageBox.Show($"mano rastas D : {i}");

            return i;
        }








        static bool Coprime(Int64 a, Int64 b)
        {

            if (Gcd(a, b) == 1)
                return true;
            else
                return false;
        }

        static Int64 Gcd(Int64 a, Int64 b)
        {
            // Everything divides 0
            if (a == 0 || b == 0)
                return 0;

            // base case
            if (a == b)
                return a;

            // a is greater
            if (a > b)
                return Gcd(a - b, b);

            return Gcd(a, b - a);
        }

        Int64[] EncryptionRsa(Int64 key , Int64 n , string myText)
        {
           // Int64[] pildom;
            byte[] myTextByteArray2 = Encoding.UTF8.GetBytes(myText);
            Int64[] pildom = new Int64[myTextByteArray2.Length];
            int b = 0;
            foreach (byte c in myTextByteArray2) {
                pildom[b] = (Int64)myTextByteArray2[b];
                b++;
                    }
            
            //int i = 0;
            for (int i = 0; i < pildom.Length; i++)
            {
                Int64 position = 1;
               // Int64 value = pildom[i];
                Int64 pt = pildom[i] - 64;

                // Int64 pt = value - 96;
                for (int j = 0; j < key; j++)
                {
                    position *= pt;
                    position = position % n;

                }
                
                pildom[i] = position;
               // myTextByteArray2[i] = (byte)position;

            }
                      
/*
            byte[] textas;
            int jabal = 0;
            foreach(Int64 c in pildom)
            {
               // textas.Append((byte)c);
                textas[jabal] = (byte)c;
                jabal++;
            }*/


            return pildom;




        }



        string DecryptionRsa(Int64 key, Int64 n, Int64[] pildom)
        {




            // Int64[] pildom;            
          
            //int i = 0;
            for (int i = 0; i < pildom.Length; i++)
            {
                Int64 position = 1;
                // Int64 value = pildom[i];
                Int64 pt = pildom[i];

                // Int64 pt = value - 96;
                for (int j = 0; j < key; j++)
                {
                    position *= pt;
                    position = position % n;

                }

                pildom[i] = position+64;

            }


            byte[] bytes = pildom.Select(i => (byte)i).ToArray();
           // MessageBox.Show($"decodinta : {Encoding.UTF8.GetString(bytes)}");
            


            return Encoding.UTF8.GetString(bytes);


        }

        Int64 FindingN(int q, int p)
        {
            return q * p;
        }

    }

}
