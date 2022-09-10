using System;
using System.Text;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string value = "9quali52ty3";

            // Convert the string into a byte[].
            byte[] asciiBytes = Encoding.ASCII.GetBytes(value);
            int sumaByte = 0;
            foreach (byte item in asciiBytes)
            {
                Console.WriteLine(item);
                sumaByte += item;
            }
            Console.WriteLine(sumaByte);

        }
    }
}
