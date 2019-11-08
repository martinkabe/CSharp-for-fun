using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reverse_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "The brown dog, jumps in the meadows.";
            Console.WriteLine($"Original Sentence:\n{str}");
            string reversedString = ReverseStringInSentence(str);
            Console.WriteLine($"\nReversed Strings in Sentence:\n{reversedString}");
            Console.WriteLine($"\nBack to Original Sentence:\n{ReverseStringInSentence(reversedString)}");

            Console.ReadKey();
        }

        public static string ReverseStringInSentence(string s)
        {
            StringBuilder sb = new StringBuilder();
            char[] array;
            int ginc = 0;
            string[] str = s.Split(' ');
            foreach (var word in str)
            {
                var match = word[word.Length-1].ToString().IndexOfAny(new char[] { ',', '.', ':', '!', '?' }) != -1; // cannot use any built-in functions
                char tempPunct = match ? word[word.Length - 1] : '\0';
                array = match ? new char[word.Length - 1] : new char[word.Length];
                int inc = 0;
                int wlen = match ? word.Length - 2 : word.Length - 1;

                for (int i = wlen; i >= 0; i--)
                {
                    array[inc++] = (ginc == 0 & i == wlen) ? Char.ToUpper(word[i]) : (ginc == 0 & i == 0) ? Char.ToLower(word[i]) : word[i];
                }
                if (match)
                {
                    if (ginc == str.Length - 1)
                    {
                        sb.Append(array).Append(tempPunct);
                    }
                    else
                    {
                        sb.Append(array).Append(tempPunct).Append(' ');
                    }
                }
                else
                {
                    if (ginc == str.Length - 1)
                    {
                        sb.Append(array);
                    }
                    else
                    {
                        sb.Append(array).Append(' ');
                    }
                }
                ginc++;
            }
            return sb.ToString();
        }
    }
}
