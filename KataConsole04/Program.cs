using System;
using System.Collections.Generic;
using System.Linq;

namespace KataConsole04
{
    public class Program
    {
        static void Main(string[] args)
        {
            var str = "C:/Users/diego.vanegaszuniga/Desktop/Kata04/football.dat";
            var str2 = "C:/Users/diego.vanegaszuniga/Desktop/Kata04/weather.dat";

            var res = GetResult(GetLines(str), 1, 2, 7, 9);
            var res2 = GetResult(GetLines(str2), 1, 1, 2, 3);

            Console.WriteLine("Index: " + res.Index + "  Spread: " + res.Spread);
            Console.WriteLine("Index: " + res2.Index + "  Spread: " + res2.Spread);

        }

        public static List<string> GetLines(string pathToData)
        {
            string text = readFile(pathToData);
            return text.Split('\n').ToList();
        }
        public static Result GetResult(List<string> lines, int weirdIndex,int idIndex, int max, int min)
        {
            int minDifference = int.MaxValue;
            var newResult = new Result();
            var listOfStrings = new List<List<string>>() { };

            for (int i = 2; i < lines.Count; i++)
            {
                //Splitting all spaces
                listOfStrings.Add(System.Text.RegularExpressions.Regex.Split(lines.ElementAt(i), @"\s{1,}").ToList());
            }

            foreach (var list in listOfStrings)
            {
                if (list.Count < 5 || list.ElementAt(weirdIndex) == "mo")
                {
                    continue;
                }
                var firstValue = int.Parse(list.ElementAt(max).Replace("*", ""));
                var secondValue = int.Parse(list.ElementAt(min).Replace("*", ""));

                if (Math.Abs(firstValue - secondValue) < minDifference)
                {
                    newResult.Index = list.ElementAt(idIndex).Replace("*", "");
                    newResult.Spread = Math.Abs(firstValue - secondValue);
                    minDifference = Math.Abs(firstValue - secondValue);
                }
            }

            return newResult;

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
