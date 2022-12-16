using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_App;

internal class Menu
{

    public static void MenyOption()
    {


        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\n   STARTMENU\n\n " +
        "  Enter the number of your option:\n\n " +
        "  1. Create new list:\n\n " +
        "  2. View all lists:\n\n " +
        "  3. View previous list:\n\n  " +
        "  4. Edit list: ");
    } 

    
    
    

}
