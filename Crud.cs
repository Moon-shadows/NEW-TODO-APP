using NEW_TODO_APP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Todo_App;

namespace NEW_TODO_APP
{
    public class Crud
    {
          


        public static void CrudMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n   CRUDMENU\n\n " +
            "  Enter the number of edit option and press enter:\n\n " +
            "  1. Delete list\n\n " +
            "  2. Rename list\n\n " +
            "  3. Go back to StartMenu \n\n " +
            "  4. Exit the Program");
        }

        public static void Delete<T>(List<T> todoList, FileManager filemanager, int inputs)  // <T> skrivs när man är osäker på datatyp
        {
            Console.WriteLine("This list has been deleted.");
            todoList.RemoveAt(inputs);
            filemanager.SaveData(todoList);
            Console.Clear();
        }

       


    }

}


