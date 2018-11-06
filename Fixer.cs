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
        static string GetFixedPath(string path, int variant)
        {
            return path.Remove(path.Length - 4) + $"_fixed_v{variant}.txt";
        }
        static void WritePhrase(StreamWriter sw, ref string phrase)
        {
            if (phrase != string.Empty)
            {
                sw.Write(FixPhrase(phrase));
                phrase = string.Empty;
            }
        }
        ///// <summary>
        ///// Returns the next string from the stream containing only
        ///// letters and spaces without the spaces. If the stream doesn't
        ///// end with a phrase (but e.g. the series of dots or brackets)
        ///// returns null.
        ///// </summary>
        ///// <param name="sr">Stream reader with the stream to read.</param>
        ///// <returns>The string with letters only
        ///// or null if there is no more phrases in the stream.</returns>
        //static string GetNextPhrase(StreamReader sr)
        //{
        //    string phrase = string.Empty;
        //    for (int c = sr.Peek(); c > -1;)
        //    {
        //        c = sr.Peek();
        //        //If the character is a letter then advance the position
        //        //in the stream and then write the letter
        //        if (char.IsLetter((char)c))
        //            phrase += (char)sr.Read();
        //        //If the character is a space then advance the position
        //        //in the stream and don't write the space
        //        else if ((char)c == ' ')
        //            sr.Read();
        //        //If the character is not a letter or a space
        //        //and the phrase is not empty, return the phrase
        //        else if (phrase != string.Empty)
        //            return phrase;
        //    }
        //    //If the stream is over and there was no more phrases found
        //    return null;
        //}
    }
}
