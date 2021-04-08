using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;

namespace RSAencryption
{
    class RSAEncryption
    {
        private int n;
        private int privateKey;
        private int publicKey;

       public void CalculatingKeys(int q, int p)
        {
            n = FindingN(q, p);


        }

       
        
      /* private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
       private RSAParameters privateKey;
       private RSAParameters publicKey;
        public void RSAencrypting()
        {
            privateKey = csp.ExportParameters(true);
            publicKey = csp.ExportParameters(false);
            csp.
        }
        
        public string PublicKeyString()
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, publicKey);
            return sw.ToString();            
            
            

        }
*/
        int FindingN(int q, int p)
        {
            return q * p;
        }

    }

}
