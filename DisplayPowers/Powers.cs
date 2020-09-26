using System;
using System.Text;

namespace RieBi
{
    class Powers
    {
        static void Main(string[] args)
        {
            // Prepare settings.
            Console.WriteLine("Enter how many numbers do you want: ");
            int MaxNum = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter how many powers do you want: ");
            int MaxPower = Int32.Parse(Console.ReadLine());

            Console.BufferWidth = 500;
            Console.BufferHeight = 500;
            Console.Clear();

            int MaxLength = Math.Pow(MaxNum, MaxPower).ToString().Length + 3;
            StringBuilder str = new StringBuilder();

            // Write powers in first line.
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 1; i <= MaxPower; i++)
            {
                str.Append(' ', MaxLength - i.ToString().Length);
                str.Append(i);
            }
            Console.WriteLine(str);
            Console.ResetColor();

            // Write all the numbers.
            for (int i = 1; i <= MaxNum; i++)
            {
                str.Clear();

                for (int j = 1; j <= MaxPower; j++)
                {
                    double num = Math.Pow(i, j);
                    int counter = MaxLength - num.ToString().Length;
                    str.Append(new String(' ', counter));
                    str.Append(num);
                }

                Console.WriteLine(str);
            }

            Console.CursorTop = 0;
            Console.ReadLine();
        }
    }
}
