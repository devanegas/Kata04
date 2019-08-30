using System;
using System.Collections.Generic;
using System.Linq;

namespace KataConsole04
{
    public class Program
    {
        static void Main(string[] args)
        {
            string text = readFile("C:/Users/diego.vanegaszuniga/Desktop/Kata04/weather.dat");

            List<string> lines = text.Split('\n').ToList();
            var splitLine = new List<List<string>>();

            int index = -1;
            int minSpread = 1000000;

            int max = 0;
            int min = 0;


            for(int i=2; i<lines.Count; i++)
            {
                //Splitting all spaces
                splitLine.Add(System.Text.RegularExpressions.Regex.Split(lines.ElementAt(i), @"\s{1,}").ToList());
            }

            foreach(var list in splitLine)
            {
                if (list.ElementAt(1) == "mo")
                {
                    break;
                }
               max=int.Parse(list.ElementAt(2).Replace("*", ""));
                min = int.Parse(list.ElementAt(3).Replace("*",""));

                if((max-min) < minSpread)
                {
                    index = int.Parse(list.ElementAt(1).Replace("*", ""));
                    minSpread = max - min;
                }
            }


            Console.WriteLine("Index: " + index + "  Spread: " + minSpread);





            /****************************************************/




            string text2 = readFile("C:/Users/diego.vanegaszuniga/Desktop/Kata04/football.dat");

            List<string> lines2 = text2.Split('\n').ToList();
            var splitLine2 = new List<List<string>>();

            string team = "FC Barcelona";
            int minDifference = 1000000;

            int max2 = 0;
            int min2 = 0;


            for (int i = 2; i < lines2.Count; i++)
            {
                //Splitting all spaces
                splitLine2.Add(System.Text.RegularExpressions.Regex.Split(lines2.ElementAt(i).Trim(), @"\s{1,}").ToList());
            }

            foreach (var list in splitLine2)
            {
                if (list.Count<5)
                {
                    continue;
                }
                max2 = int.Parse(list.ElementAt(6).Replace("*", ""));
                min2 = int.Parse(list.ElementAt(8).Replace("*", ""));

                if (Math.Abs(max2 - min2) < minDifference)
                {
                    team = list.ElementAt(1).Replace("*", "");
                    minDifference = Math.Abs(max2 - min2);
                }
            }


            Console.WriteLine("Index: " + team + "  Spread: " + minDifference);



        }

        public  static string readFile(string path)
        {
            string text = System.IO.File.ReadAllText(path);
            return text;

        }

        //public static void writeToFile()
        //{
        //    string lines = readFile();
        //    System.IO.File.WriteAllText(@"C:/Users/diego.vanegaszuniga/Desktop/Kata04/newData.txt", lines);

        //}
    }

}
