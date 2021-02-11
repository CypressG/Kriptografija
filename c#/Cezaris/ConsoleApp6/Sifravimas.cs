using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    public class Sifravimas
    {
        string Notencoded { get; set; }

        string Cezencoded { get; set; }
                
        string Decoded { get; set; }

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
            byte keyb = Convert.ToByte(key);
            
            foreach (byte c in bytas)
            {
                 baitas.Enqueue((byte)(c + keyb));

            }
               
            bytas = baitas.ToArray();
            normtext.Decoded = System.Text.Encoding.UTF8.GetString(bytas);
            baitas.Clear();
            foreach (byte c in baitas)
            {

            }
            foreach (byte c in bytas)
            {
                baitas.Enqueue((byte)(c - keyb));

            }
            bytas = baitas.ToArray();
            normtext.Cezencoded = System.Text.Encoding.UTF8.GetString(bytas);
            Console.WriteLine($"Pradinis tekstas : {normtext.Notencoded} ");
            Console.WriteLine($"_____________________________________");
            Console.WriteLine($"Užkuoduotas tekstas : {normtext.Decoded}");
            Console.WriteLine($"_____________________________________");
            Console.WriteLine ($"Atkoduotas tekstas : {normtext.Cezencoded} ");
            Console.WriteLine($"_____________________________________");

        }

    }
}
