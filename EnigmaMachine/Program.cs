using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachine
{
    class Program
    {
        public static bool Debug = false;

        public static string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        public static string Key = "MNBVCXZLKJHGFDSAPOIUYTREWQmnbvcxzlkjhgfdsapoiuytrewq0987654321";

        public static void DebugOutput(string output)
        {
            if (Debug)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(output);
                Console.ResetColor();
            }
        }

        public static string Encode(string input)
        {
            string result = "";
            int pos = 0; // The position of the letter in the key

            DebugOutput("input.Length = " + input.Length);
            if (Debug) Console.ReadKey();

            // Break up the input into small bits
            // Then put it into an array
            string[] inputArray = new string[input.Length];
            for (int x = 0; x < input.Length; x++)
            {
                DebugOutput("inputArray[" + x + "] = " + input.Substring(x, 1));
                inputArray[x] = input.Substring(x, 1);
            }

            if (Debug) Console.ReadKey();

            // After that, do the same to the character set and key
            string[] characterArray = new string[Characters.Length];
            for (int x = 0; x < Characters.Length; x++)
            {
                DebugOutput("characterArray[" + x + "] = " + Characters.Substring(x, 1));
                characterArray[x] = Characters.Substring(x, 1);
            }

            if (Debug) Console.ReadKey();

            string[] keyArray = new string[Key.Length];
            for (int x = 0; x < Key.Length; x++)
            {
                DebugOutput("keyArray[" + x + "] = " + Key.Substring(x, 1));
                keyArray[x] = Key.Substring(x, 1);
            }

            if (Debug) Console.ReadKey();

            // Find each letter's position on the character set
            // then replace that with the matching letter on the key set
            foreach (string letter in inputArray)
            {
                while (true)
                {
                    if (pos == characterArray.Length)
                    {
                        DebugOutput("pos = " + pos);
                        DebugOutput("pos > " + characterArray.Length);
                        result += letter;
                        pos = 0;
                        break;
                    }

                    else if (letter == characterArray[pos])
                    {
                        DebugOutput(letter + " == " + characterArray[pos] + "(" + keyArray[pos] + ")");
                        DebugOutput("pos = " + pos);

                        result += keyArray[pos];
                        pos = 0;
                        break;
                    }

                    else
                    {
                        DebugOutput(letter + " != " + characterArray[pos] + "(" + keyArray[pos] + ")");
                        DebugOutput("pos = " + pos);
                        pos++;
                        continue;
                    } 
                }
                if (Debug) Console.ReadKey();
            }

            return result;
        }

        public static string Decode(string input)
        {
            string result = "";
            int pos = 0; // the position of the letter in the key

            DebugOutput("input.Length = " + input.Length);
            if (Debug) Console.ReadKey();

            // Break up the input into small bits
            // Then put it into an array
            string[] inputArray = new string[input.Length];
            for (int x = 0; x < input.Length; x++)
            {
                DebugOutput("inputArray[" + x + "] = " + input.Substring(x, 1));
                inputArray[x] = input.Substring(x, 1);
            }

            if (Debug) Console.ReadKey();

            // After that, do the same to the character set and key
            string[] characterArray = new string[Characters.Length];
            for (int x = 0; x < Characters.Length; x++)
            {
                DebugOutput("characterArray[" + x + "] = " + Characters.Substring(x, 1));
                characterArray[x] = Characters.Substring(x, 1);
            }

            if (Debug) Console.ReadKey();

            string[] keyArray = new string[Key.Length];
            for (int x = 0; x < Key.Length; x++)
            {
                DebugOutput("keyArray[" + x + "] = " + Key.Substring(x, 1));
                keyArray[x] = Key.Substring(x, 1);
            }

            if (Debug) Console.ReadKey();

            // Find each letter's position on the character set
            // Then replace that with the matching letter on the key set
            foreach (string letter in inputArray)
            {
                while (true)
                {
                    // Ignore punctuation
                    if (pos == characterArray.Length)
                    {
                        DebugOutput("pos = " + pos);
                        DebugOutput("pos > " + characterArray.Length);
                        result += letter;
                        pos = 0;
                        break;
                    }

                    if (letter == keyArray[pos])
                    {
                        DebugOutput(letter + " == " + keyArray[pos] + "(" + characterArray[pos] + ")");
                        DebugOutput("pos = " + pos);

                        result += characterArray[pos];
                        pos = 0;
                        break;
                    }

                    else
                    {
                        DebugOutput(letter + " != " + keyArray[pos] + "(" + characterArray[pos] + ")");
                        DebugOutput("pos = " + pos);
                        pos++;
                        continue;
                    }
                }
                if (Debug) Console.ReadKey();
            }

            return result;
        }

        static void Main(string[] args)
        {
            if (args.Length >= 1 && args[0] == "/d") Debug = true; // Check for debug flag

            DebugOutput("DEBUG IS ENABLED");
            Console.WriteLine("Enigma Machine");
            Console.WriteLine("(C) Gregory Karastergios 2018");
            Console.WriteLine("v1.0.0");
            Console.WriteLine("\nPress any key to begin");

            Console.ReadKey();
            Console.Clear();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Encode");
                Console.WriteLine("2. Decode");
                Console.WriteLine("3. Exit");

                Console.WriteLine("Enter Selection:");

                // Messy solution to validate input
                string textInput = Console.ReadLine();
                int input = 0;

                Console.Clear();

                try { input = Convert.ToInt32(textInput); }
                catch { Console.WriteLine("Invalid input"); }

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Enter the text to encode");
                        textInput = Console.ReadLine();

                        Console.WriteLine("result: {0}", Encode(textInput));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Enter the text to decode");
                        textInput = Console.ReadLine();

                        Console.WriteLine("result: {0}", Decode(textInput));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
