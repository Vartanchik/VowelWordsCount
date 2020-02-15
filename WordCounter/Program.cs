using System;
using System.IO;
using System.Text.RegularExpressions;

namespace WordCounter
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = string.Empty;

            bool isPathValid = false;

            do
            {
                Console.WriteLine($"Your current directory is:\n{Directory.GetCurrentDirectory()}");

                Console.WriteLine("Enter relative path to your *.txt file:");

                path = Console.ReadLine();

                // path validation
                isPathValid = IsPathValid(path);

                // checking if file doesn't have extension. If true - add ".txt"
                if (!Path.HasExtension(path))
                {
                    path += ".txt";
                }

                // checking if file doesn't exist
                if (!File.Exists(path))
                {
                    Console.WriteLine($"\nSorry, file by path:\n{path}\n- doesn't exist! Try again.\n");

                    isPathValid = false;
                }

            } while (!isPathValid);

            // reading text from file
            string text = File.ReadAllText(path);

            // vowel words counting method
            int wordCounter = CountVowelWords(text);

            Console.WriteLine($"Count of words in text file that consist of vowels characters only is: {wordCounter}");

            Console.ReadKey();
        }

        public static bool IsPathValid(string path)
        {
            // regular expression for path by such patterns as:
            // D:\folder1\forder2\file.txt
            // D:\file.txt
            // \file.txt
            // folder1\forder2\file.txt
            // ..\..\folder1\forder2\file.txt
            // ..\..\file.txt
            // file.txt
            // file
            // ...
            Regex rgx = new Regex(@"^([a-zA-Z]\:)?\\?(\.\.\\)*([\w]+\\)*[\w\.]+$");

            // path validation
            if (!rgx.IsMatch(path))
            {
                Console.WriteLine($"\nSorry, path:\n{path}\n- isn't valid! Try again.\n");

                return false;
            }

            return true;
        }

        public static int CountVowelWords(string text)
        {
            int counter = 0;

            // split factors by which will separate text string to substrings
            string[] splitFactors = new[] { " ", "\r\n" };

            // text string separating
            string[] stringArray = text.Split(splitFactors, StringSplitOptions.None);

            // regular expression for vowel words
            Regex rgx = new Regex(@"^([aeiouy]+)$", RegexOptions.IgnoreCase);

            // vowel words counting
            foreach (var str in stringArray)
            {
                if (rgx.IsMatch(str))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
