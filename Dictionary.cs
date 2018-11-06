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
        public static void Delete()
        {
            words = null;
        }
        public static bool? Valuable(string key) => words.Valuable(key);
        public static void CreateFromFile(params string[] paths)
        {
            CreateFromFile(-1, paths);
        }
        public static void CreateFromFile(int encoding, params string[] paths)
        {
            words = new KeyTrie();
            Expand(encoding, paths);
        }
        public static void Expand(params string[] paths)
        {
            Expand(-1, paths);
        }
        public static void Expand(int encoding, params string[] paths)
        {
            if (words == null) throw new InvalidOperationException(
                "The dictionary must be created first.");
            foreach (string path in paths)
                using (StreamReader sr =
                        encoding < 0 ?
                            new StreamReader(path) :
                            new StreamReader(path,
                                Encoding.GetEncoding(encoding)))
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
