﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFix
{
    static class Dictionary
    {
        //Fields
        static Trie<uint> words;
        static List<char> alphabet;

        //Delegates
        delegate void ReadForTrie(StreamReader sr);

        //Properties
        public static bool IsEmpty => words == null;
        public static string[] Words => words.Keys;
        public static uint TotalWordsCount { get; private set; }
        public static double Dispersion { get; set; } = 1.1;
        public static bool IfCompare { get; set; } = true;

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
        public static uint Frequency(string word) => words.GetValue(word);
        public static double Expectation(string word) =>
            (double)Frequency(word) / TotalWordsCount;
        //If case sencitivity will be added, the property must be redisigned!
        public static double Expectation(string[] phrase)
        {
            double result = 1;
            foreach (string word in phrase)
                result *= Expectation(word.ToLowerInvariant());
            return result;
        }
        public static double Expectation(List<string> phrase)
        {
            return Expectation(phrase.ToArray());
        }
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
            words = new Trie<uint>(alphabet.ToArray(), "frequency");
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
                        TotalWordsCount += 1;
                        if (!words.TryAdd(word, 1))
                            words.Add(word, Frequency(word) + 1);
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
        public static bool PhraseIsCorrect(string phrase)
        {
            foreach (string word in
                phrase.Split(
                    new char[1] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries))
                if (!Valuable(word) ?? true)
                    return false;
            return true;
        }
        public static string[][] SeparateWords(string concatenatedWords) =>
            IfCompare ?
                words.SeparateKeys(concatenatedWords, 
                    new PreprocessComparer<List<string>, double>(
                        Expectation, CompareExpectations, 
                        Comparer<double>.Default.Compare)) :
                words.SeparateKeys(concatenatedWords);
        static int CompareExpectations(double x, double y)
        {
            if (x < 0 || y < 0) throw
                    new InvalidOperationException("Expectations must be nonnegative.");
            if (x > y * (Dispersion == 0 ? 1 : TotalWordsCount * Dispersion)) return 1;
            if (y > x * (Dispersion == 0 ? 1 : TotalWordsCount * Dispersion)) return -1;
            return 0;
        }
    }
}
