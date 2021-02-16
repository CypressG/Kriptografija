using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Console.WriteLine("Hello World!");
            Console.WriteLine("Input text you want to encrypt");
            string a = Console.ReadLine();
            Sifravimas naujas = new Sifravimas(a);
            Console.WriteLine("Input shift");
            string b = Console.ReadLine();
            int c = Convert.ToInt32(b);

            naujas.cezaris(naujas, c);
        }
    }
}
