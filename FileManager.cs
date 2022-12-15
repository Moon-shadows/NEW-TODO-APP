using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_TODO_APP
{
    public class FileManager
    {
        public List<T> GetJson<T>(string path) where T : class
        {
            StreamReader listnamereader = new StreamReader(path);
            string content = listnamereader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

    }
}
