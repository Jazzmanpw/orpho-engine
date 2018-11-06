using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFix
{
    class Dictionary
    {
        //Fields
        static KeyTrie words;

        //Properties
        public static bool IsEmpty => words == null;
        public static string[] Words => words.Keys;

        //Methods
        public static bool? Valuable(string key) => words.Valuable(key);
        public static void CreateFromFile(string path)
        {
            words = new KeyTrie();
            using (StreamReader sr = new StreamReader(path))
            {
                string word = string.Empty;
                int c = 0;
                do
                {
                    c = sr.Read();
                    if (char.IsLetter((char)c))
                        word += char.ToLowerInvariant((char)c);
                    else
                    {
                        if (word != string.Empty)
                        {
                            words.Add(word);
                            word = string.Empty;
                        }
                    }
                } while (c > -1);
            }
        }
        public static string[][] SeparateWords(string concatenatedWords)
        {
            return words.SeparateKeys(concatenatedWords);
        }
    }
}
