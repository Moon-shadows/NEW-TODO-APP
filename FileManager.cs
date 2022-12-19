using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_App;

namespace NEW_TODO_APP
{
        public class FileManager
        {
            public List<T> GetJson<T>(string path) where T : class
            {
                StreamReader listnamereader = new StreamReader(path);
                string content = listnamereader.ReadToEnd();
                listnamereader.Close();
                return JsonConvert.DeserializeObject<List<T>>(content);
            }

   

      

            public void SaveData<T>(List<T> todoList)
            {
                 StreamWriter listnameWriter = new StreamWriter(@"./../../../todo.json"); // . = Här är vi nu (där projektet är på datorn) .. = Hoppa ett steg bakåt.
                 listnameWriter.WriteLine(JsonConvert.SerializeObject(todoList, Formatting.Indented)); //using streamwriter to add todoList to Json file.
                 listnameWriter.Close();
            }

        }

}


/*static List ConvertJsonToCs()
{
    string fileName = @"C:\Demos\Json.txt";
    string justText = File.ReadAllText(fileName);
    List a = Newtonsoft.Json.JsonConvert.DeserializeObject<List>(justText);
    return (a);

}

static void ConvertCsToJson()
{
    var item = CreateList();
    var jsonFormattedContent = Newtonsoft.Json.JsonConvert.SerializeObject(item);
    string filePath = @"C:\Demos\Json.txt";
    File.WriteAllText(filePath, jsonFormattedContent);
}
*/