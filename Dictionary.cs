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
        static List<char> alphabet;

        //Delegates
        delegate void ReadForTrie(StreamReader sr);

        //Properties
        public static bool IsEmpty => words == null;
        public static string[] Words => words.Keys;

        //Methods
        public static void Delete()
        {
            words = null;
        }
        public static void Delete(string word)
        {
            words.Delete(word);
        }
        public static bool? Valuable(string word) => words.Valuable(word);
        static void CheckPaths(params string[] paths)
        {
            if (paths.Length == 0) throw new ArgumentException(
                "There have to be at least one path " +
                "from which to read.", "paths");
        }
        public static void CreateFromFile(int encoding = -1, params string[] paths)
        {
            CheckPaths(paths);
            alphabet = new List<char>();
            ReadForDictionary(encoding, PullLetters, paths);
            words = new KeyTrie(alphabet.ToArray());
            ReadForDictionary(encoding, AddWords, paths);
        }
        public static void Expand(int encoding = -1, params string[] paths)
        {
            throw new NotImplementedException(
                "The method has to be updated because of " +
                "restructurization of the dictionary.");
            //if (words == null) throw new InvalidOperationException(
            //    "The dictionary must be created first.");
            //CheckPaths(paths);
            //ReadForDictionary(encoding, AddWords, paths);
        }
        static void PullLetters(StreamReader sr)
        {
            int charNum = 0;
            do
            {
                charNum = sr.Read();
                char c = char.ToLowerInvariant((char)charNum);
                if (char.IsLetter(c) &&
                    !alphabet.Contains(c))
                    alphabet.Add(c);
            } while (charNum > -1);
            alphabet.Sort();
        }
        static void AddWords(StreamReader sr)
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
        static void ReadForDictionary(int encoding, ReadForTrie ReadNDo, params string[] paths)
        {
            foreach (string path in paths)
                using (StreamReader sr =
                        encoding < 0 ?
                            new StreamReader(path) :
                            new StreamReader(path,
                                Encoding.GetEncoding(encoding)))
                { ReadNDo(sr); }
        }
        public static string[][] SeparateWords(string concatenatedWords)
        {
            return words.SeparateKeys(concatenatedWords);
        }
    }
}
