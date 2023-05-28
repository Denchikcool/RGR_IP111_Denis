using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace РГР.Models
{
    public class XML_Saver : ICollectionSaver
    {
        public void Save(IEnumerable<Full_Elements> collection, string path)
        {
            XDocument xDocument = new XDocument();
            XElement xElementColection = new XElement("collection");
            foreach (Full_Elements element in collection)
            {
                if (element is Class_And and_element)
                {
                    XElement xElementClass = new XElement("class_and");
                    XElement xElementStart = new XElement("start", and_element.Main_Point);
                    XElement xElementName = new XElement("name", and_element.Name);
                    xElementClass.Add(xElementStart);
                    xElementClass.Add(xElementName);
                    xElementColection.Add(xElementClass);
                }
                else if (element is Class_Enter enter_element)
                {
                    XElement xElementClass = new XElement("class_enter");
                    XElement xElementStart = new XElement("start", enter_element.Main_Point);
                    XElement xElementName = new XElement("name", enter_element.Name);
                    xElementClass.Add(xElementStart);
                    xElementClass.Add(xElementName);
                    xElementColection.Add(xElementClass);
                }
                else if (element is Class_HalfSum halfsum_element)
                {
                    XElement xElementClass = new XElement("class_halfsum");
                    XElement xElementStart = new XElement("start", halfsum_element.Main_Point);
                    XElement xElementName = new XElement("name", halfsum_element.Name);
                    xElementClass.Add(xElementStart);
                    xElementClass.Add(xElementName);
                    xElementColection.Add(xElementClass);
                }
                else if (element is Class_Not not_element)
                {
                    XElement xElementClass = new XElement("class_not");
                    XElement xElementStart = new XElement("start", not_element.Main_Point);
                    XElement xElementName = new XElement("name", not_element.Name);
                    xElementClass.Add(xElementStart);
                    xElementClass.Add(xElementName);
                    xElementColection.Add(xElementClass);
                }
                else if (element is Class_Or or_element)
                {
                    XElement xElementClass = new XElement("class_or");
                    XElement xElementStart = new XElement("start", or_element.Main_Point);
                    XElement xElementName = new XElement("name", or_element.Name);
                    xElementClass.Add(xElementStart);
                    xElementClass.Add(xElementName);
                    xElementColection.Add(xElementClass);
                }
                else if (element is Class_Out out_element)
                {
                    XElement xElementClass = new XElement("class_out");
                    XElement xElementStart = new XElement("start", out_element.Main_Point);
                    XElement xElementName = new XElement("name", out_element.Name);
                    xElementClass.Add(xElementStart);
                    xElementClass.Add(xElementName);
                    xElementColection.Add(xElementClass);
                }
                else if (element is Class_XoR xor_element)
                {
                    XElement xElementClass = new XElement("class_xor");
                    XElement xElementStart = new XElement("start", xor_element.Main_Point);
                    XElement xElementName = new XElement("name", xor_element.Name);
                    xElementClass.Add(xElementStart);
                    xElementClass.Add(xElementName);
                    xElementColection.Add(xElementClass);
                }
                else if (element is Class_Line line_element)
                {
                    XElement xElementLine = new XElement("line");
                    XElement xElementStart = new XElement("start", line_element.StartPoint);
                    XElement xElementEnd = new XElement("end", line_element.EndPoint);
                    XElement xElement1 = new XElement("firstElement", line_element.FirstElement);
                    XElement xElement2 = new XElement("secondElement", line_element.SecondElement);
                    XElement xElement1_Name = new XElement("name1", line_element.FirstElement.Name);
                    XElement xElement2_Name = new XElement("name2", line_element.SecondElement.Name);
                    xElementLine.Add(xElementStart);
                    xElementLine.Add(xElementEnd);
                    xElementLine.Add(xElement1);
                    xElementLine.Add(xElement2);
                    xElementLine.Add(xElement1_Name);
                    xElementLine.Add(xElement2_Name);
                    xElementColection.Add(xElementLine);
                }
            }
            xDocument.Add(xElementColection);
            xDocument.Save(path);
        }
    }
}
