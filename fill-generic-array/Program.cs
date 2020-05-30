using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fill_generic_array
{
    class Program
    {
        static Random Random { get; } = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("With a generic you could do this...");

            SomeClass[] arrayOfT = new SomeClass[10];
            fillGenericArray<SomeClass>(arrayOfT);
            Console.WriteLine(string.Join(Environment.NewLine, arrayOfT.Select(field=>field.Value)));


            Console.WriteLine();
            Console.WriteLine("But perhaps it's redundant, because Enumerable is already Generic!");

            SomeClass[] arrayOfT_2 = Enumerable.Repeat<SomeClass>(new SomeClass(Random.Next(1, 501)), 10).ToArray();
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
