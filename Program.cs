// See https://aka.ms/new-console-template for more informa
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Transactions;
using System.IO;
using Todo_App;

//Create variables of lists:
var Todolist = new List<string>();
var Tasklist = new List<string>();

//Startpoint for program:
Menu.MenyOption();
var userInput = Console.ReadLine();
switch (userInput)
{
    case "1":
        Console.WriteLine("Enter a name for new list: ");
        var listname = Console.ReadLine();
        Todolist.Add(listname);
        Tasklist.Add(listname);
        StreamWriter listnamewriter = new StreamWriter(@"C:\Demos\testinglist.txt", true);
        listnamewriter.WriteLine(listname); //using streamwriter to add text to file
        listnamewriter.Close();
        Addtesk();
        Menu.MenyOption();
        break;

    case "2":
        StreamReader listnamereader = new StreamReader(@"C:\Demos\testinglist.txt");
        string content = listnamereader.ReadToEnd();
        Console.WriteLine(content);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Write a listname or 'H' for home or 'Q' for quit program ");

        string command = Console.ReadLine();
        Console.WriteLine("");


        Menu.MenyOption();
        Console.ReadLine();
        break;

    case "3":
        ShowList.ShowTheContent();
        Console.ReadLine();
        break;

    case "4":
        Console.WriteLine("Enter listnumber to edit:\n ");
        ShowList.ShowTheContent();
        var editlistname = Console.ReadLine();
        Menu.CrudMenu();
        Console.ReadLine();
        break;

    default:
        Console.WriteLine("Enter a number: ");
        break;
}

void Addtesk()
{
    Console.WriteLine("Add a task");
    var userInputTask = Console.ReadLine();
    Tasklist.Add(userInputTask);
}


/*
 * for (int i = 0; i < Todolist.Count; i++)
        {
            ShowTheContent();
            Addtesk();
        }
       

*/



/*
 * Projekt 1:Todo-lista
Beskrivning0 :
- En lokal Todo-lista konsol-applikation, där man via menyval 
* lägger nya listor och kan lägga till en ny task i listan, 
* * Todo-listan ska lagras lokalt på datorn i valfritt läsbart format (ex: json/txt format)
* Har möjlighet att ta bort
* /klar markera, 
* ändra,
* Visa en översikt av alla todos/task och todo-listor.
* * Todo-listan ska lagras och uppdateras lokalt på datorn i valfritt läsbart format (ex: json/txt format)

Bas funktionalitet1 :CRUD
- Listor/Lista/Task
- Borde finnas möjlighet att kunna (skapa/uppdatera/ta bort) på alla tre
nivåer.

Menyer2: Meny påListor/Lista/Task
- Meny alla listor/Översikt
- Öppna senaste listan ⇒  (Meny för lista) lastindex..
- Se alla listor ⇒  (Meny för lista) /foreach array
- Skapa ny lista
- Ta bort specifik lista (bekräftelse y/n)
- Avsluta programmet (bekräftelse y/n)
- Meny för lista
- Gå tillbaka till översikt ⇒  (Meny alla listor/Översikt)
- Redigera namn på lista (bekräftelse y/n)
- Lägg till task
- Klar-markera
- Redigera task ⇒  (Meny för task)
- Ta bort task (bekräftelse y/n)
- Meny för task
- Redigera namn på lista (bekräftelse y/n)
- Optional (Arkivera task)

//////////////////////////////////////////////////////////
Optional3 :Extra funktionalitet (Kommer du på merså kör)
- Sub-tasks
- Rangordna alla tasks, (ex: prio 1-5)
- Skapa kategorier på listorna
- Färglägg listorna i olika färger
- Sortera listan/listorna
- Namn
- Datum
- Prio
- Kategori
*/

