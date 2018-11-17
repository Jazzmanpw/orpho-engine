using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFix
{
    static class Fixer
    {
        //Fields
        static string separator = "|__OR__|";

        //Properties
        static public bool IfShowExpectations { get; set; }

        //Methods
        static string FixPhrase(string phrase)
        {
            //Get fixed variants
            string[][] fixVariants = Dictionary.SeparateWords(phrase);

            //Build result string
            bool isOneVariant = fixVariants.GetLength(0) == 1;
            string fixedPhrase = isOneVariant ? string.Empty : "[";
            foreach (string[] variant in fixVariants)
            {
                foreach (string word in variant)
                    fixedPhrase += word + " ";
                fixedPhrase =
                    fixedPhrase.Remove(fixedPhrase.Length - 1) +
                    (IfShowExpectations && !isOneVariant ?
                        string.Format("({0:E3})", Dictionary.Expectation(variant)) :
                        string.Empty) +
                    separator;
            }
            return
                fixedPhrase.Remove(fixedPhrase.Length - separator.Length) +
                (isOneVariant ? string.Empty : "]");
        }
        public static void FixSpaces(params string[] paths)
        {
            foreach (string path in paths)
                using (StreamReader sr = new StreamReader(path))
                {
                    using (StreamWriter sw = new StreamWriter(GetFixedPath(path)))
                    { sw.Write(FixString(sr.ReadToEnd())); }
                }
        }
        public static void FixSpaces(out string[] fixedPaths, params string[] paths)
        {
            FixSpaces(paths);
            fixedPaths = GetFixedPath(paths);
        }
        public static string FixString(string str)
        {
            string
                concatenatedPhrase = string.Empty,
                originalPhrase = string.Empty,
                result = string.Empty;
            foreach (char c in str)
                if (char.IsLetter(c))
                {
                    concatenatedPhrase += c;
                    originalPhrase += c;
                }
                else if (c == ' ')
                    originalPhrase += c;
                else
                {
                    if (concatenatedPhrase != string.Empty)
                    {
                        result +=
                            Dictionary.PhraseIsCorrect(originalPhrase.ToLowerInvariant()) ?
                            originalPhrase :
                            FixPhrase(concatenatedPhrase);
                        concatenatedPhrase =
                            originalPhrase = string.Empty;
                    }
                    result += c;
                }
            if (concatenatedPhrase != string.Empty)
                result +=
                    Dictionary.PhraseIsCorrect(originalPhrase) ?
                    originalPhrase :
                    FixPhrase(concatenatedPhrase);
            return result;
        }
        static string GetFixedPath(string path)
        {
            return Path.ChangeExtension(path, "fixed.txt");// path.Remove(path.Length - 4) + $"_fixed.txt";
        }
        static string[] GetFixedPath(string[] paths)
        {
            int length = paths.GetLength(0);
            string[] result = new string[length];
            for (int i = 0; i < length; i++)
                result[i] = GetFixedPath(paths[i]);
            return result;
        }
        static void WritePhrase(StreamWriter sw, ref string phrase)
        {
            if (phrase != string.Empty)
            {
                sw.Write(FixPhrase(phrase));
                phrase = string.Empty;
            }
        }
    }
}
