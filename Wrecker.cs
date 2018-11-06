using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFix
{
    class Wrecker
    {
        //Fields
        ////Parts of spaces to be removed or added
        //static readonly double
        //    removedSpacesPart = .5,
        //    addedSpacesPart = .2;

        //Methods
        public static string WreckSpaces(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                using (StreamWriter sw = new StreamWriter(GetWreckedPath(path)))
                {
                    for (int c = sr.Read(), doom = 0; c > -1; c = sr.Read())
                    {
                        #region Why don't the code work???
                        ////The code in the region behave very strangely.
                        ////It only make things as it was ment to during debugging session,
                        ////but if I run the application not step-by-step, it just
                        ////delete all the spaces and don't add any by random.
                        ////Don't you know why could it be?
                        ////
                        //Random rnd = new Random();
                        ////The variable to see the read character as a char, not as an int
                        //char debug = (char)c;
                        //if (c == ' ')
                        //{
                        //    //Write the space only if random number
                        //    //is more then the part of spaces to be removed
                        //    if (rnd.NextDouble() > removedSpacesPart)
                        //        sw.Write((char)c);
                        //}
                        //else
                        //{
                        //    //Write an additional space if random number
                        //    //is lower then the part of spaces to be added
                        //    if (rnd.NextDouble() < addedSpacesPart)
                        //        sw.Write(' ');
                        //    sw.Write((char)c);
                        //}
                        #endregion
                        if (c == ' ')
                        {
                            if (doom++ % 2 == 0)
                                sw.Write((char)c);
                        }
                        else
                        {
                            if (doom++ % 4 == 0)
                                sw.Write(' ');
                            sw.Write((char)c);
                        }
                    }
                }
            }
            return GetWreckedPath(path);
        }
        static string GetWreckedPath(string path)
        {
            return path.Remove(path.Length - 4) + "_wrecked.txt";
        }
    }
}
