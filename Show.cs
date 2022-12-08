using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_App
{
    internal class ShowList
    {
        public static void ShowTheContent()
        {
            string filePath = @"C:\Demos\testinglist.txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();  //Write (in the console) all the text in the list called lines:

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

        }
    }
}
