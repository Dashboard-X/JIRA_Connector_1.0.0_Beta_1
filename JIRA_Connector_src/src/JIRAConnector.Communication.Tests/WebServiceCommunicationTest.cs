using System;
using JIRAConnector.Communication.JiraWebService;
using NUnit.Framework;

namespace JIRAConnector.Communication.Tests{
    [TestFixture]
    public class WebServiceCommunicationTest{
        [Test]
        public void TestJIRAWebService() {
            JiraSoapServiceService jiraSoapService = new JiraSoapServiceService();
            //Asi cambiaria dinamicamente la URL del web service
            //jiraSoapService.Url = "http://jira.atlassian.com/rpc/soap/jirasoapservice-v2";

            
            String token = jiraSoapService.login("testjconn", "testjconn");
            //String token = jiraSoapService.login("soaptester", "soaptester");
            
            string[] projects = new string[1];
            projects[0] = "SACTA";
           
            //Esto trae todos los issues de Sacta
            RemoteIssue[] issuesFromTextSearch = jiraSoapService.getIssuesFromTextSearchWithProject(token, projects, "", 100);

            //foreach (RemoteIssue r in issuesFromTextSearch)
            //{
            //    //Hacer algo
            //}

            Assert.IsTrue(issuesFromTextSearch.Length > 0);
        }
    }
}
