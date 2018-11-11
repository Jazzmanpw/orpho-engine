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
        static int shWLenUpLim;

        //Properties
        public static double ShortWordsPart { get; set; } = .4;
        public static int ShortWordLength
        {
            get { return shWLenUpLim - 1; }
            set { shWLenUpLim = value + 1; }
        }
        public static int NumOfVars { get; set; }// = 3;

        //Methods
        static string FixPhrase(string phrase)
        {
            //Get fixed variants
            string[][] fixVariants = Dictionary.SeparateWords(phrase);

            //Calculate expectances of phrases.
            //We consider it to be a multiplication of
            //probabilities of words to emerge in the text.
            if (fixVariants.GetLength(0) > NumOfVars)
            {
                double[] phraseExpectances = new double[fixVariants.GetLength(0)];
                for (int i = 0; i < phraseExpectances.Length; i++)
                {
                    phraseExpectances[i] = 1;
                    foreach (string word in fixVariants[i])
                        phraseExpectances[i] *=
                            (double)Dictionary.Frequency(word.ToLowerInvariant()) /
                            Dictionary.TotalWordsCount;
                }
                string[][] mostExpectedVariants = new string[NumOfVars][];
                for (int i = 0; i < NumOfVars; i++)
                {
                    int maxNum = Array.IndexOf(phraseExpectances, phraseExpectances.Max());
                    mostExpectedVariants[i] = fixVariants[maxNum];
                    phraseExpectances[maxNum] = 0;
                }
                fixVariants = mostExpectedVariants;
            }
            ////Try to remove variants with too many short words
            ////throw new NotImplementedException();
            //List<string[]> fixVariants_short = new List<string[]>();
            //foreach (string[] variant in fixVariants)
            //{
            //    int wordsNum = variant.GetLength(0),
            //        shortWorsdNum = 0;
            //    foreach (string word in variant)
            //        if (word.Length < shWLenUpLim) shortWorsdNum++;
            //    if (shortWorsdNum < wordsNum * ShortWordsPart)
            //        fixVariants_short.Add(variant);
            //}
            //if (fixVariants_short.Count != 0)
            //    fixVariants = fixVariants_short.ToArray();

            //Build result string
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
                            Dictionary.PhraseIsCorrect(originalPhrase) ?
                            originalPhrase :
                            FixPhrase(concatenatedPhrase);
                        concatenatedPhrase =
                            originalPhrase = string.Empty;
                    }
                    result += c;
                }
            if (concatenatedPhrase != string.Empty)
                result += FixPhrase(concatenatedPhrase);
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
