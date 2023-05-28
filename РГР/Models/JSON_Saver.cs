using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace РГР.Models
{
    public class JSON_Saver : ICollectionSaveProj
    {
        public void Save_project(IEnumerable<Class_Projects> collection, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, collection, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
        }
    }
}
