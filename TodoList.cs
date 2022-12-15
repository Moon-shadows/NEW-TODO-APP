

namespace Todo_App;

public class TodoList
{
    public TodoList() //Need to have open constructor if using Json & have other constructors in the class.
    {
    }

    public TodoList(string name)  //constructor
    {
        Name = name;
    }
    public TodoList(string name, string task) //Constructor
    {
        Name = name;
        Tasks.Add(new Task(task));
    }
    public string Name  { get; set; }
    public List<Task> Tasks { get; set; } = new();  //  = new();  (initializing the list)

}

public class Task
{
    public Task()  //Need to have open constructor if using Json & have other constructors in the class.
    {
    }
    public Task(string name)  //Constructor
    {
        Name = name;
    }
    public string Name { get; set; }
    public int Id  { get; set; }

}





