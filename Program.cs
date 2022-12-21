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
using System.Data;

var filemanager = new FileManager();
var todoList = filemanager.GetJson<TodoList>(@"./../../../todo.json");

//Startpoint for program:
bool running = true;  //Program is running till running = false.
while (running)  //Loop, with curly around the whole program.
{
    Console.WriteLine("Welcome to: MyToDo App! ");
    Menu.MenyOption();  //Ange först klass och sen metod.
    var userInput = Console.ReadLine();
    switch (userInput)
    {
        case "1":
            Console.WriteLine("\n Enter the Name for your new list or press 'Q' to close the Program.");
            var listname = Console.ReadLine().ToUpper() .Trim();

            if (listname == "Q")
            {
                Console.WriteLine("\n\n CLOSING THE PROGRAM...");

                {
                    running = false;
                    break;
                }
            }
            if (string.IsNullOrEmpty(listname))
            {
                Console.WriteLine("Listname can not be empty. Press enter to restart.");
                Console.ReadLine();
                Menu.MenyOption();
                continue;
            }

            Console.WriteLine("\nEnter tasks for your list (with a comma between each task).\n" +
            "Press enter when ready.");
            var task = Console.ReadLine();
            todoList.Add(new TodoList(listname, task));  // Using constructor Todolist & var todoList = filemanager.GetJson<TodoList>(@"./../../../todo.json");.
            Console.WriteLine($"Todo list: {JsonConvert.SerializeObject(todoList, Formatting.Indented)}");
            filemanager.SaveData(todoList);
            Console.Clear();

            if (!string.IsNullOrEmpty(listname))
                {
                    Console.WriteLine("\n\nYour new list was succesfully created. Press enter to continue. ");
                    Console.ReadLine();
                    Menu.MenyOption();
                    continue;
                }
            Menu.MenyOption();
            break;


        case "2":
            foreach(var todo in todoList )
                {

                    Console.WriteLine($"{todoList.IndexOf(todo)}: {todo.Name}"); //view all listname with index
                }
            Console.WriteLine("\n\n Write the number for the listname you want to acces.\n ");
            int command = int.Parse(Console.ReadLine()); //index = command, console.readline är alltid string, görs om till int.

            if (command == 0)
                {
                    Console.WriteLine("Listnumber can not be empty. Press enter to restart.");
                    Console.ReadLine();
                    Menu.MenyOption();
                    continue;
                }

            Console.WriteLine($"List: {todoList[command].Name}");  // Use $ for mixing text with properties.
            foreach(var t in todoList[command].Tasks)   //write all task for a list depending on the index number.
                {
                    Console.WriteLine($" {t.Name} \n");
                }

            Console.WriteLine("\nPress 'S' for Startmenu or 'Q' to close the Program: ");
            string input = Console.ReadLine().ToUpper();

            if (input == "Q")
                {
                    Console.WriteLine("\n\n CLOSING THE PROGRAM...");
                    {
                        running = false;
                        break;
                    }
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
            Console.WriteLine(todoList[todoList.Count - 1].Name);
            Console.ReadLine();
            break;


        case "4":
            foreach (var todo in todoList)
                {
                    Console.WriteLine($"{todoList.IndexOf(todo)}: {todo.Name}"); //view all listname with index
                }
            Console.WriteLine("\n\n Write the number of the list you want to edit \n ");
            int UInput = int.Parse(Console.ReadLine()); //index = int.
            Console.WriteLine($"List: {todoList[UInput].Name}");  // Use $ for mixing text with properties.
            foreach (var t in todoList[UInput].Tasks)   //write all task for a list depending on the index number.
                {
                    Console.WriteLine($" {t.Name} \n");
                }

            Crud.CrudMenu();
            var UseInput = Console.ReadLine();
                switch (UseInput)
                {
                    case "1":
                   
                        Crud.Delete(todoList, filemanager, UInput);  //Inga datatyper skrivs i parametrarna tillbaka, endast i själva metoden.
                        Console.WriteLine("\n The list has been deleted. Press 'S' for Startmenu, 'Q' to close the Program: ");
                        string Input = Console.ReadLine();

                        if (Input == "Q")
                        {
                            Console.WriteLine("\n\n CLOSING THE PROGRAM...");

                            {
                                running = false;
                                break;
                            }
                        }

                        if (string.IsNullOrEmpty(Input))
                        {
                            Console.WriteLine("Listname can not be empty");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            Menu.MenyOption();
                            continue;
                        }
                        Menu.MenyOption();
                        break;


                    case "2":
                         //Inga datatyper skrivs i parametrarna tillbaka, endast i själva metoden.
                        todoList.RemoveAt(UInput);
                        filemanager.SaveData(todoList);
                        Console.Clear();

                        Console.WriteLine("\n Write the new listname.");
                        var newname = Console.ReadLine().ToUpper().Trim();
                        todoList.Insert(UInput, new TodoList(newname));
                        Console.WriteLine("The listname is renamed.");


                        Console.WriteLine($"Todo list: {JsonConvert.SerializeObject(todoList, Formatting.Indented)}");
                        filemanager.SaveData(todoList);
                        Console.Clear();

                        Console.WriteLine("\n The listname is updated. Press 'S' for Startmenu, 'Q' to close the Program: ");
                        Console.ReadLine();   
                        break;


                    case "3":
                        Menu.MenyOption();
                        break;

                case "4":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"List: {todoList[UInput].Name} is ready!");  // Use $ for mixing text with properties.
                    Console.ReadLine();
                    filemanager.SaveData(todoList);
                    Console.Clear();
                  
                    break;

                case "5":
                        {
                            Console.WriteLine("\n\n CLOSING THE PROGRAM..." +
                                "  ");

                            {
                                running = false;
                                break;
                            }
                        }
                }
                break;
            

            case "5":

                {
                    Console.WriteLine("\n\n CLOSING THE PROGRAM..." +
                        "  ");
                
                    {
                        running = false;
                        break;
                    }
                }
    }
}






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
- Öppna senaste listan ⇒  (Meny för lista) 
- Se alla listor ⇒  (Meny för lista) /
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

