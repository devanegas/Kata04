using System;

namespace Kata04
{
    public class Kata04
    {

        public string readFile()
        {
            string text = System.IO.File.ReadAllText("C:/Users/diego.vanegaszuniga/Desktop/Kata04/weather.dat");
            return text;

        }

        public void writeToFile()
        {
            string lines = readFile();
            System.IO.File.WriteAllText(@"C:/Users/diego.vanegaszuniga/Desktop/Kata04/newData.txt", lines);

        }
    }
}
