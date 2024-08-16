using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    public static partial class Program
    {
        private static int ReadInt(string inputName)
        {
            int retVal;
            string line;

            do
            {
                Console.Write(inputName);
                line = Console.ReadLine() ?? string.Empty;

            } while (!int.TryParse(line, out retVal));

            return retVal;
        }
    }
}
