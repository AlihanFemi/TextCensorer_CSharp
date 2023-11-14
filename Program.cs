using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextCensorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\DELL\source\repos\HR\TextCensorer\Text.txt";
            string text = File.ReadAllText(filePath);
            string result = ReplaceBannedWords(text);
            File.WriteAllText(filePath, result);
        }
        static string ReplaceBannedWords(string text)
        {
            List<string> bannedWords = new List<string>() {"bannedWord1", "bannedWord2"};
            foreach(string word in bannedWords)
            {
                string pattern = "\\b" + Regex.Escape(word) + "\\b";
                string replacement = new string('#', word.Length - 1);
                text = Regex.Replace(text, pattern, replacement, RegexOptions.IgnoreCase);
            }
            return text;
        }
    }
}
