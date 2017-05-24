using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace QuiXoT.DA_Raw
{
    public class Mgfutils
    {

        public static string getFirstTitle(string mgfFolder)
        {
            string title = "No title";
            string titleID= "TITLE";

            FileInfo[] filesInFolder;

            try
            {
                filesInFolder = new DirectoryInfo(mgfFolder).GetFiles();
            }
            catch { return title; }

            foreach(FileInfo file in filesInFolder)
            {
                if (file.Extension.ToUpper() == ".MGF" || file.Extension.ToUpper() == ".TXT")
                {
                    StreamReader sr = new StreamReader(File.OpenRead(file.FullName));
                    //ArrayList fileAl = new ArrayList();
                    string line="";

                    try 
                    {
                        while (sr.Peek() != -1)
                        {
                            line = sr.ReadLine();
                            if (line.ToUpper().Contains(titleID))
                            {
                                title = line;
                                return title;
                            }

                        }

                    }
                    catch { }
                }
            }

            return title;             
        }

        //public static string getScanNumber(string title, 
        //                                    char[] split_chars,
        //                                    int[] scanFields,
        //                                    string separationString)
        //{

        //    string[] title_split = title.Split(split_chars);
        //    string scanNumber="";

        //    for (int i = 0; i <= scanFields.GetUpperBound(0); i++)
        //    {
        //        scanNumber += title_split[scanFields[i]];
                 
        //    }


        //    return scanNumber;
        //}

        public static int getScanNumber(string title,
                                        char[] split_chars,
                                        int scanField) 
        {
            int scanNumber = 0;

            string[] title_split = title.Split(split_chars);

            bool tryscanNumber = int.TryParse(title_split[scanField], out scanNumber);

            if (!tryscanNumber) scanNumber = 0;

            return scanNumber;
        }

    }
}
