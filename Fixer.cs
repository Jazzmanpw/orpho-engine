using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFix
{
    class Fixer
    {
        //Fields
        static string separator = "|__OR__|";

        //Methods
        static string FixPhrase(string phrase)
        {
            string[][] fixVariants = Dictionary.SeparateWords(phrase);
            bool isOneVariant = fixVariants.GetLength(0) == 1;
            string fixedPhrase = isOneVariant ? string.Empty : "[";
            foreach (string[] variant in fixVariants)
            {
                foreach (string word in variant)
                    fixedPhrase += word + " ";
                fixedPhrase =
                    fixedPhrase.Remove(fixedPhrase.Length - 1) +
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
                    {
                        string phrase = string.Empty;
                        for (int c = sr.Read(); c > -1; c = sr.Read())
                        {
                            if (char.IsLetter((char)c))
                                phrase += (char)c;
                            else if (c != ' ')
                            {
                                WritePhrase(sw, ref phrase);
                                sw.Write((char)c);
                            }
                        }
                        WritePhrase(sw, ref phrase);
                    }
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
                phrase = string.Empty,
                result = string.Empty;
            foreach (char c in str)
                if (char.IsLetter(c))
                    phrase += c;
                else if (c != ' ')
                {
                    if (phrase != string.Empty)
                    {
                        result += FixPhrase(phrase);
                        phrase = string.Empty;
                    }
                    result += c;
                }
            if (phrase != string.Empty)
                result += FixPhrase(phrase);
            return result;
        }
        static string GetFixedPath(string path)
        {
            return path.Remove(path.Length - 4) + $"_fixed.txt";
        }
        static string[] GetFixedPath(string[] paths)
        {
            int length = paths.GetLength(0);
            string[] result = new string[length];
            for (int i = 0;i< length; i++)
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
