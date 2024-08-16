using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Consumer
{
    public static partial class Program
    {
        public static void Main()
        {
            string line;
            do
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("Function: ");                
                line = Console.ReadLine() ?? string.Empty;

                Console.Clear();
                Console.WriteLine();

                switch (line)
                {
                    case "add":
                        TestAddFunction();
                        break;
                    case "say ok":
                        TestSayOKFunction();
                        break;
                    case "randoms":
                        TestRandomsFunction();
                        break;
                    case "info":
                        TestImportantFunction();
                        break;
                    default:
                        break;
                }

            } while (line != "exit");
        }

        private static void TestImportantFunction()
        {
            var info = new ImportantInfo();

            GetImportantInfo(ref info);

            info.Name = new string(' ', info.NameLength);

            GetImportantInfo(ref info);

            Console.WriteLine($"Name: {info.Name} | Date: {(DateTime)info.Date} | Age: {info.Age}");
        }

        private static void TestRandomsFunction()
        {
            var seed = ReadInt("Seed: ");

            var length = GetRandomsLength(seed);

            Console.WriteLine($"Length: {length}");

            var data = new int[length];

            var copy = GetRandoms(data, length, seed);

            Console.WriteLine($"Randoms: {string.Join(", ", data)}");
            Console.WriteLine($"Copy: {copy}");
        }

        private static void TestSayOKFunction()
        {
            var length = GetTextOKLength();

            Console.WriteLine($"Length: {length}");

            var text = new string(' ', length);

            var copy = GetTextOK(text, length);

            Console.WriteLine($"Text: \"{text}\"");
            Console.WriteLine($"Copy: {copy}");
        }

        private static void TestAddFunction()
        {
            var result = Add(5, 7);

            Console.WriteLine($"Add: {result}");
        }
    }
}