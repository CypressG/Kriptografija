using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Hello World!");
            Sifravimas naujas = new Sifravimas("Gaidys ąūžčč");

            naujas.cezaris(naujas, 255);
        }
    }
}
