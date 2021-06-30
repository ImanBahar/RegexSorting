using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace testApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // statement
            // printing Hello World!
            Console.WriteLine("Hello World!");
            int x = 0;

            while (x != 10)
            {
                Console.WriteLine("");
                Console.WriteLine("Enter Your Command :");
                String input = Console.ReadLine();

                // String test = "A3B2.C3.";
                // String test2 = "(A3.B2.C1.c5)3";
                // String test3 = "(A3B2C1)5";

                Console.WriteLine("Result : ");
                sortInput(input);
            }

        }

        public static void sortInput(String input)
        {
            string b = string.Empty;
            String parseInput;
            StringBuilder s1 = new StringBuilder();
            Regex reg = new Regex(@"\(([^)]*)\)[0-9]*");
            Regex regDot = new Regex(@"\.");
            Regex regNumber = new Regex(@"\d+");
            Regex regChar = new Regex(@"[A-Za-z]");
            int index = 1;

            if (reg.IsMatch(input))
            {
                parseInput = reg.Match(input).Groups[1].Value;
                char indexNumber = input[input.Length - 1];
                index = indexNumber - '0';
                // Console.WriteLine(Char.IsDigit(indexNumber));
                // Console.WriteLine(indexNumber);

            }
            else
            {
                parseInput = input;
            }

            string[] data = Regex.Split(parseInput, @"([A-Za-z]*[0-9]*\.)|([A-Za-z]*[0-9]*)").Where(s => s != String.Empty).ToArray<string>();

            foreach (var item in data)
            {
                Console.WriteLine(item.ToString());
            }

            //Ops
            Console.WriteLine("Enter Loop...");
            for (int num = 0; num < index; num++)
            {
                for (int x = 0; x < data.Length; x++)
                {
                    String indexData = data[x];
                    string str2 = string.Empty;
                    string str = string.Empty;
                    char character = indexData[0];
                    int value = 0;

                    var matches = regNumber.Matches(indexData);
                    var matchesChar = regChar.Matches(indexData);

                    foreach (var match in matches)
                    {
                        str2 += match;
                    }

                    foreach (var match in matchesChar)
                    {
                        str += match;
                    }

                    value = int.Parse(str2);

                    if (regDot.IsMatch(indexData))
                    {
                        String list = String.Concat(Enumerable.Repeat(str, value));
                        Console.WriteLine(list);
                    }
                    else
                    {
                        String list = String.Concat(Enumerable.Repeat(str, value));
                        Console.Write(list);
                    }
                }
            }
        }
    }
}
