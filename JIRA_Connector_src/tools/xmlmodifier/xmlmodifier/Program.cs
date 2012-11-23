using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace xmlmodifier {
    class Program {
        static void Main(string[] args) {
            if (args.Length == 3)
            {
                try
                {
                    string file = args[0];
                    string nodeName = args[1];
                    string newValue = args[2];

                    if (!File.Exists(file)) { throw new FileNotFoundException(); }
                    XmlTextReader reader = new XmlTextReader(file);
                    XmlDocument doc = new XmlDocument();
                    doc.Load(reader);
                    reader.Close();

                    //Select the cd node with the matching title
                    XmlNode node;
                    XmlElement root = doc.DocumentElement;
                    node = root.GetElementsByTagName(nodeName)[0];
                    if (node == null) { throw new InvalidOperationException("Node not found."); }

                    node.InnerText = newValue;

                    //save the output to a file
                    doc.Save(file);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else {
                Console.WriteLine("Error. Usage: xmlmodifier <file> <nodeName> <newValue>");
            }
        }
    }
}
