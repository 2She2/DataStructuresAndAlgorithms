// 03.Write a program that counts how many times each word from given text file words.txt appears in it.
//    The character casing differences should be ignored. The result words should be ordered by
//    their number of occurrences in the text.
//      Example:
//          This is the TEXT. Text, text, text – THIS TEXT! Is this the text?

//	is  2
//	the  2
//	this  3
//	text  6

namespace _03.WordsCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordsCount
    {
        public static void Main(string[] args)
        {
            string text = string.Empty;

            try
            {
                using (StreamReader rd = new StreamReader("../../words.txt"))
                {
                    text = rd.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("File 'words.txt' could not be read:");
                Console.WriteLine(e.Message);
            }
            
            Regex regex = new Regex(@"\b[a-zA-Z]+\b");
            MatchCollection words = regex.Matches(text.ToLower());

            IDictionary<string, int> occurrences = new SortedDictionary<string, int>();

            foreach (Match match in words)
            {
                string currWord = match.ToString();
                if (occurrences.ContainsKey(currWord))
                {
                    occurrences[currWord]++;
                }
                else
                {
                    occurrences[currWord] = 1;
                }
            }

            var sortedWords = occurrences.OrderBy(x => x.Value);

            foreach (var pair in sortedWords)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }
        }
    }
}
