using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class UI
    {
        public static void Clear()
        {
            Console.Clear();
        }

        public static void WriteLine()
        {
            Console.WriteLine();
        }

        public static void WriteLine(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }

        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        public static int ChooseNumber(string message, int min = int.MinValue, int max = int.MaxValue)
        {
            Console.WriteLine(message);
            int n;
            if (int.TryParse(Console.ReadLine(), out n) &&
                n >= min && n <= max)
            {
                return n;
            }
            else
            {
                Console.WriteLine("La opción elegida es inválida.");
                return ChooseNumber(message, min, max);
            }
        }

        public static bool ChooseBoolean(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine().Equals("s", StringComparison.OrdinalIgnoreCase);
        }
    }
}
