using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using JIRAConnector.Common;

namespace JIRAConnector.Communication{
    public class JiraXMLHelper{
        public static List<Issue> GetIssueListFromXmlStream(Stream stream) {
            List<Issue> issues = new List<Issue>();
            XmlTextReader reader = new XmlTextReader(stream);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlNodeList list = doc.DocumentElement.GetElementsByTagName("item");
            XmlSerializer s = new XmlSerializer(typeof(Issue));
            //Create the XmlNamespaceManager.
            NameTable nt = new NameTable();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
            nsmgr.AddNamespace("jc", "urn:jiraconn");

            //Create the XmlParserContext.
            XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);

            foreach (XmlNode item in list)
            {
                //Create the reader. 
                XmlTextReader itemReader = new XmlTextReader(item.OuterXml, XmlNodeType.Element, context);
                Issue issue = (Issue)s.Deserialize(itemReader);
                issues.Add(issue);
            }

            return issues;
            
        }
    }
}
