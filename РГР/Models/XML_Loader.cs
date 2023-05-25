using Avalonia;
using Avalonia.Controls.Shapes;
using DynamicData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace РГР.Models
{
    public class XML_Loader : ICollectionLoader
    {
        public IEnumerable<Full_Elements> Load(string path)
        {
            XDocument xDocument = XDocument.Load(path);
            XElement? collection = xDocument.Element("collection");
            if(collection is not null)
            {
                ObservableCollection<Full_Elements> loadCollection = new ObservableCollection<Full_Elements>();
                foreach (XElement classElement in collection.Elements("class_and"))
                {
                    var point = classElement.Element("start");
                    var nameElement = classElement.Element("name");
                    Class_And classElementCollection = new Class_And
                    {
                        Main_Point = Avalonia.Point.Parse(point.Value),
                        Name = nameElement.Value
                    };
                    loadCollection.Add(classElementCollection);
                }
                foreach (XElement classElement in collection.Elements("class_enter"))
                {
                    var point = classElement.Element("start");
                    var nameElement = classElement.Element("name");
                    Class_Enter classElementCollection = new Class_Enter
                    {
                        Main_Point = Avalonia.Point.Parse(point.Value),
                        Name = nameElement.Value
                    };
                    loadCollection.Add(classElementCollection);
                }
                foreach (XElement classElement in collection.Elements("class_halfsum"))
                {
                    var point = classElement.Element("start");
                    var nameElement = classElement.Element("name");
                    Class_HalfSum classElementCollection = new Class_HalfSum
                    {
                        Main_Point = Avalonia.Point.Parse(point.Value),
                        Name = nameElement.Value
                    };
                    loadCollection.Add(classElementCollection);
                }
                foreach (XElement classElement in collection.Elements("class_not"))
                {
                    var point = classElement.Element("start");
                    var nameElement = classElement.Element("name");
                    Class_Not classElementCollection = new Class_Not
                    {
                        Main_Point = Avalonia.Point.Parse(point.Value),
                        Name = nameElement.Value
                    };
                    loadCollection.Add(classElementCollection);
                }
                foreach (XElement classElement in collection.Elements("class_or"))
                {
                    var point = classElement.Element("start");
                    var nameElement = classElement.Element("name");
                    Class_Or classElementCollection = new Class_Or
                    {
                        Main_Point = Avalonia.Point.Parse(point.Value),
                        Name = nameElement.Value
                    };
                    loadCollection.Add(classElementCollection);
                }
                foreach (XElement classElement in collection.Elements("class_out"))
                {
                    var point = classElement.Element("start");
                    var nameElement = classElement.Element("name");
                    Class_Out classElementCollection = new Class_Out
                    {
                        Main_Point = Avalonia.Point.Parse(point.Value),
                        Name = nameElement.Value
                    };
                    loadCollection.Add(classElementCollection);
                }
                foreach (XElement classElement in collection.Elements("class_xor"))
                {
                    var point = classElement.Element("start");
                    var nameElement = classElement.Element("name");
                    Class_XoR classElementCollection = new Class_XoR
                    {
                        Main_Point = Avalonia.Point.Parse(point.Value),
                        Name = nameElement.Value
                    };
                    loadCollection.Add(classElementCollection);
                }
                foreach (XElement lineElement in collection.Elements("line"))
                {
                    var lineStart = lineElement.Element("start");
                    var lineEnd = lineElement.Element("end");
                    var firstElement = lineElement.Element("firstElement");
                    var secondElement = lineElement.Element("secondElement");
                    var name1 = lineElement.Element("name1");
                    var name2 = lineElement.Element("name2");
                    Full_Elements lineElementCollection = new Class_Line
                    {
                        StartPoint = Avalonia.Point.Parse(lineStart.Value),
                        EndPoint = Avalonia.Point.Parse(lineEnd.Value),
                        Name1 = name1.Value,
                        Name2 = name2.Value
                    };
                    loadCollection.Add(lineElementCollection);
                }
                if (loadCollection != null)
                {
                    return loadCollection;
                }
                else return new List<Full_Elements>();
            }
            return new List<Full_Elements>();
        }
    }
}
