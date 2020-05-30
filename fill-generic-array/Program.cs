using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace fill_generic_array
{
    class Program
    {
        static Random Random { get; } = new Random();
        const int LENGTH = 10;
        static void Main(string[] args)
        {
            
            Console.WriteLine();
            Console.WriteLine("With a generic you could do this...");


            SomeClass[] arrayOfT;
            arrayOfT = new SomeClass[LENGTH];
            fillGenericArray<SomeClass>(arrayOfT);
            Console.WriteLine(string.Join(Environment.NewLine, arrayOfT.Select(field=>field.Value)));


            Console.WriteLine();
            Console.WriteLine("But perhaps it's redundant, because Enumerable is already Generic!");

            arrayOfT = Enumerable.Range(1, LENGTH).Select(i => new SomeClass(Random.Next(1, 501))).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, arrayOfT.Select(field => field.Value)));

            // Pause
            Console.WriteLine(Environment.NewLine + "Any key to exit");
            Console.ReadKey();
        }
        public static void fillGenericArray<T>(T[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = (T)Activator.CreateInstance(typeof(T), Random.Next(1, 501));
            }
        }
        class SomeClass
        {
            public SomeClass(int value)
            {
                Value = value;
            }
            public int Value { get; set; }
        }
    }
}
