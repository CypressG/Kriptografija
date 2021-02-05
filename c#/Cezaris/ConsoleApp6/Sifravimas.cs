using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    public class Sifravimas
    {
        string Notencoded { get; set; }

        string Cezencoded { get; set; }

        byte[] Baitaienc { get; set; }

        string Decoded { get; set; }

        int CypherKey { get; set; }

        public Sifravimas()
        {

        }

        public Sifravimas(string motencoded)
        {
            Notencoded = motencoded;

        }

        public void cezaris(Sifravimas normtext, int key)
        {
            Queue<Byte> baitas = new Queue<Byte>();
            byte[] bytas = System.Text.Encoding.UTF8.GetBytes(normtext.Notencoded);
            byte suds = Convert.ToByte(key);
            
            foreach (byte c in bytas)
            {
                 baitas.Enqueue((byte)(c + suds));

            }
            foreach (byte c in baitas)
            {
                Console.WriteLine($"pirmas :{ c} ");
            }

            //foreach (byte c in baitas)
            //  {
            // normtext.Decoded = System.Text.Encoding.UTF8.GetString(baitas);
            //}
            bytas = baitas.ToArray();
            normtext.Decoded = System.Text.Encoding.UTF8.GetString(bytas);
            baitas.Clear();
            foreach (byte c in baitas)
            {

            }
            foreach (byte c in bytas)
            {
                baitas.Enqueue((byte)(c - suds));

            }
            bytas = baitas.ToArray();
            normtext.Cezencoded = System.Text.Encoding.UTF8.GetString(bytas);
            Console.WriteLine($", 213213213pawkepawodpasnjdmponas,,, {normtext.Decoded} ,,,,,,,,,,,,, {normtext.Cezencoded} ");

        }

    }
}
