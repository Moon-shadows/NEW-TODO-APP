

namespace Todo_App;

public class TodoList
{
    public TodoList()
    {
    }

    public TodoList(string name)
    {
        Name = name;
    }
    public TodoList(string name, string task) 
    {
        Name = name;
        Tasks.Add(new Task(task));
    }
    public string Name  { get; set; }
    public List<Task> Tasks { get; set; } = new();

}

public class Task
{
    public Task()
    {
    }
    public Task(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
    public int Id  { get; set; }

}





