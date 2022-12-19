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
          public static void Delete<T>(List<T> todoList,  FileManager filemanager, int inputs)
          {
             Console.WriteLine("This list has been delited.");
             todoList.RemoveAt(inputs);
             filemanager.SaveData(todoList);
             Console.Clear();
          }

    }
}


