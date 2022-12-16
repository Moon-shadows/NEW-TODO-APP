// See https://aka.ms/new-console-template for more informa
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Transactions;
using System.IO;
using Todo_App;
using NEW_TODO_APP;
using Newtonsoft.Json;
using Task = Todo_App.Task;




var filemanager = new FileManager();
var todoList = filemanager.GetJson<TodoList>(@"./../../../todo.json");


//Startpoint for program:

bool running = true;  //Program is running till running = false.
while (running)  //Loop, with curly around the whole program.
{
    Console.WriteLine("Welcome to: MyToDo App! ");
    Menu.MenyOption();
    var userInput = Console.ReadLine();
    switch (userInput)
    {
        case "1":
            Console.WriteLine("Enter name for a new list or press 'Q' to quit.:  ");
            var listname = Console.ReadLine().ToUpper() .Trim();

            if (listname == "Q")
            { 
                running = false;
                break;
            }
            if(string.IsNullOrEmpty(listname))
            {
                Console.WriteLine("Listname can not be empty");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Menu.MenyOption();
                continue;
            }

            
                //Addtesk();
                Console.WriteLine("Enter the items for your list with a comma between each item or press 'Q' to quit.:  ");
            var task = Console.ReadLine();
         
          ;
            todoList.Add(new TodoList(listname, task));  // Using constructor Todolist & var todoList = filemanager.GetJson<TodoList>(@"./../../../todo.json");.


            Console.WriteLine($"Todo list: {JsonConvert.SerializeObject(todoList, Formatting.Indented)}");
            
            StreamWriter listnamewriter = new StreamWriter(@"./../../../todo.json"); // . = Här är vi nu (där projektet är på datorn) .. = Hoppa ett steg bakåt.
            listnamewriter.WriteLine(JsonConvert.SerializeObject(todoList, Formatting.Indented)); //using streamwriter to add todoList to Json file.
            listnamewriter.Close();

            
                




            // StreamWriter listnamewriter = new StreamWriter(@"C:\Demos\testinglist.txt", true);
            //listnamewriter.WriteLine(listname); //using streamwriter to add text to file
            // listnamewriter.Close();
            //if(listname == Q)
            //{
            //    Console.WriteLine("hej")
            //}


            Menu.MenyOption();
            break;

        case "2":
            //StreamReader listnamereader = new StreamReader(@"C:\Demos\testinglist.txt");
            //string content = listnamereader.ReadToEnd();
            //Console.WriteLine(content);

            foreach(var todo in todoList )
            {

                Console.WriteLine($"{todoList.IndexOf(todo)}: {todo.Name}"); //view all listname with index
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Write the number for the listname you want to acces / press '111' to quit the program.");
            int command = int.Parse(Console.ReadLine()); //index = int.

           

            if (command == 111)
            {
                running = false;
                break;
            }


            Console.WriteLine($"List: {todoList[command].Name}");  // Use $ for mixing text with properties.


            foreach(var t in todoList[command].Tasks)   //write all task for a list depending on the index number.
            {
                Console.WriteLine($" {t.Name} \n");
            }

            Console.WriteLine("\nPress 'S' for Startmenu, 'Q' to quit the program: ");
            string input = Console.ReadLine();

            if (input == "Q")
            {
                running = false;
                break;
            }
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Listname can not be empty");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Menu.MenyOption();
                continue;
            }
            break;

        case "3":
            Console.WriteLine("skriv något här ");

            Console.ReadLine();
            break;

        case "4":

            ShowList.ShowTheContent();
            Console.WriteLine("\n\nEnter number for list to edit.\n ");
            var listNameIndex = Console.ReadLine();

            ShowList.CrudMenu();
            var editchoise = Console.ReadLine();

            switch (editchoise)
            {
                case "1":
                    string filePath = @"C:\Demos\testinglist.txt";
                    List<string> lines = File.ReadAllLines(filePath).ToList();

                    int index = 0;
                    foreach (string line in lines)
                    {

                        index++;
                    }
                    Console.WriteLine($"{listNameIndex}: {lines}");
                    lines.RemoveAt(7);
                    Console.ReadLine();
                    break;

                case "2":
                    Console.WriteLine("You have succesfully deleted the list from the list.");

                    //lines.RemoveAt( 7 );

                    Console.ReadLine();
                    break;




            }
            break;

            case "5":
            {
                Console.WriteLine("\n\n CLOSING THE PROGRAM  ");
                
                {
                    running = false;
                    break;
                }
            }
    }
}
void Addtesk()
{
    Console.WriteLine("Add a task");
    var userInputTask = Console.ReadLine();
   
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

