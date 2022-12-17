using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_App;

namespace Todo_App
{
    internal class ShowList
    {
        public static void ShowTheContent()
        {
            string filePath = @"C:\Demos\testinglist.txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();  

            int index = 0;
            foreach (string line in lines)
            {
                Console.WriteLine($"{index}: {line}");
                index++;
            }

        }



       



        public static void CrudMenu()
        {
            Console.WriteLine("\n Enter number for edit option:\n " +
            "  1. Rename:\n\n " +
            "  2. Delete:\n\n " +
            "  3. Update:\n\n  ");
        }



        

    }
}
