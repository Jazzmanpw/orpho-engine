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

        //Methods
        public static string WreckSpaces(string path, int encoding = -1)
        {
            using (
                StreamReader sr =
                encoding < 0 ?
                new StreamReader(path) :
                new StreamReader(path, Encoding.GetEncoding(encoding)))
            {
                using (
                    StreamWriter sw =
                    encoding < 0 ?
                    new StreamWriter(GetWreckedPath(path)) :
                    new StreamWriter(
                        new FileStream(GetWreckedPath(path), FileMode.Create),
                        Encoding.GetEncoding(encoding)))
                {
                    for (int c = sr.Read(), doom = 0; c > -1; c = sr.Read())
                    {
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
