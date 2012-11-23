using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using JIRAConnector.Common;
using JIRAConnector.Common.Enums;
using JIRAConnector.Communication.JiraWebService;
using System.Collections;
using System.Web;

namespace JIRAConnector.Communication{
    /// <summary>
    /// This class represents a gateway to a JIRA Implementation. 
    /// It's methods are intended to be consumed from the JIRAConnector.Core namespace since this class 
    /// is the responsible for deciding how to "talk" to JIRA. Among other things, this class decides wheter an operation
    /// will be performed through JIRA's XML-HTTP interface or throug JIRA's SOAP Client.
    /// </summary>
    public class JiraProvider : IJiraProvider{
        
        private string authenticationToken = String.Empty;

        /// <summary>
        /// Gets the authentication token returned by a Jira Server after a successful login has taken place.
        /// This token is necessary for performing future calls to JIRA using it's SOAP Client interface.
        /// If the authentication token is empty (i.e. the first call), a login is attempted using JiraConnector configuration data.
        /// </summary>
        private string AuthenticationToken {
            get {
                if (String.Equals(this.authenticationToken,String.Empty)) {
                   this.authenticationToken = JiraSoapHelper.GetJiraSoapServiceProxy().login(JiraConfigurationHelper.GetUserName(), JiraConfigurationHelper.GetUserPassword());
                }
                return authenticationToken;
            }
        }

        /// <summary>
        /// Authenticates a user in a JIRA Implementation
        /// </summary>
        /// <param name="userName">The JIRA UserName</param>
        /// <param name="password">The password for that UserName in clear text</param>
        /// <returns>A boolean indicating where the login attempt was successful or not</returns>
        public bool AuthenticateUser(string userName, string password) {
            this.authenticationToken = JiraSoapHelper.GetJiraSoapServiceProxy().login(userName, password);
            return true;
        }
        
        /// <summary>
        /// Uses JIRA SOAP Service in order to obtain a Project ID from a Project Key 
        /// </summary>
        private string GetProjectIdFromProjectKey(string projectKey) {
            string ret = String.Empty;
            RemoteProject[] projects = JiraSoapHelper.GetJiraSoapServiceProxy().getProjects(this.AuthenticationToken);
            foreach (RemoteProject rp in projects ) {
                if (String.Equals(rp.key,projectKey)) {
                    ret = rp.id;
                }
            }
            return ret;
        }

        /// <summary>
        /// Gets all the issues of the selected project assigned to the current user of JiraConnector
        /// </summary>
        /// <param name="projectKey">The project key as stated in the Jira Project Configuration</param>
        /// <returns>A generic list of <c>Issue</c> entities </returns>
        public List<Issue> GetAllIssuesFromProjectAssignedToCurrentUser(string projectKey){
            List<Issue> issues;
            
            //The project id is needed in order to create te query string, so we need to get it from the project key
            string projectId = this.GetProjectIdFromProjectKey(projectKey);
        
            //Creates the appropiate url for use in a XML-HTTP request to JIRA.
            string url = JiraHttpHelper.GetJiraRpcUrlForFilter(projectId, JiraIssueAsignee.CURRENT_USER, JiraIssueStatus.ANY);

            //Create the request and obtain the response for the XML-HTTP query to JIRA.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream resStream = response.GetResponseStream();

            //Parsing of the XML document response containing the list of issues we needed
            issues = JiraXMLHelper.GetIssueListFromXmlStream(resStream);
           
            return issues;
        }

        /// <summary>
        /// Get all te comments associated with a specified issue
        /// </summary>
        /// <param name="issueKey">The Key of the Issue whose comments are to be retrieved </param>
        /// <returns>A generic list of <c>IssueComment</c> entities</returns>
        public List<IssueComment> GetIssueComments(string issueKey) {
            
            List<IssueComment> issueComments = new List<IssueComment>();
            
            //Obtains an array of JIRA's RemoteComment entities and converts each one of them into a IssueComment entity
            RemoteComment[] comments = 
                JiraSoapHelper.GetJiraSoapServiceProxy().getComments(this.AuthenticationToken, issueKey);

            foreach (RemoteComment comment in comments) {
                issueComments.Add(new IssueComment(comment.username,comment.timePerformed,comment.body));
            }
          
            return issueComments;
        }

        /// <summary>
        /// Adds a comment to an Issue
        /// </summary>
        /// <param name="comment">The <c>RemoteComment</c> to add to the issue</param>
        /// <param name="issueKey">The key of the issue to which the comment will be added</param>
        public void AddCommentToIssue(string issueKey, IssueComment comment) {
            RemoteComment rc = new RemoteComment();
            rc.body = comment.Text;
            rc.timePerformed = comment.Date;
            rc.username = comment.Author;
            JiraSoapHelper.GetJiraSoapServiceProxy().addComment(this.AuthenticationToken, issueKey,rc);
        }

        /// <summary>
        /// Progress the workflow of and Issue in order to resolve it or close it
        /// </summary>
        /// <param name="actionId">The string representation of the numeric id corresponding to the workflow action to perform</param>
        /// <param name="issueKey">The key of the Issue to resolve</param>
        /// <param name="resolutionKey">The resolution key of the issue</param>
        /// <param name="resolutionComment">An optional comment related to the action</param>
        /// <param name="fixVersions">A list a list containing all the Issue fix versions' ID's</param>
        /// <param name="affectsVersions">A list a list containing all the Issue affects versions' ID's</param>
        public void ProgressWorkflowForResolution(string actionId, string issueKey, string resolutionKey, string resolutionComment, string[] fixVersions, string[] affectsVersions) {

            RemoteCustomFieldValue[] customFields =  this.GetIssueCustomFields(issueKey);

            List<RemoteFieldValue> actionParams = new List<RemoteFieldValue>();
            
            RemoteFieldValue asigneeParam = new RemoteFieldValue();
            asigneeParam.id = "assignee";
            asigneeParam.values = new string[] { "-1" }; //Automatic
            actionParams.Add(asigneeParam);

            RemoteFieldValue resolutionParam = new RemoteFieldValue();
            resolutionParam.id = "resolution";
            resolutionParam.values = new string[] { resolutionKey };
            actionParams.Add(resolutionParam);

            RemoteFieldValue fixVersionsParam = new RemoteFieldValue();
            fixVersionsParam.id = "fixVersions";
            fixVersionsParam.values = fixVersions;
            actionParams.Add(fixVersionsParam);

            RemoteFieldValue affectsVersionsParam = new RemoteFieldValue();
            affectsVersionsParam.id = "affectsVersions";
            affectsVersionsParam.values = affectsVersions;
            actionParams.Add(affectsVersionsParam);

            foreach (RemoteCustomFieldValue customField in customFields) {
                RemoteFieldValue customFieldParam = new RemoteFieldValue();
                customFieldParam.id = customField.customfieldId;
                //Nasty workaround for the fact that the SOAP API returns the same id for both items in a Cascading Select Custom Field
                foreach (RemoteFieldValue ap in actionParams){
                    if (ap.id.Equals(customFieldParam.id)) {
                        customFieldParam.id += ":1";
                    }
                }
                customFieldParam.values = customField.values;
                actionParams.Add(customFieldParam);
            }

            JiraSoapHelper.GetJiraSoapServiceProxy().progressWorkflowAction(AuthenticationToken, issueKey, actionId, actionParams.ToArray());
        }

        /// <summary>
        /// Gets all the available project keys in a JIRA Server Instance to which the user has access
        /// </summary>
        /// <returns>An array of strings containing the project keys</returns>
        public List<string> GetAllProjectKeysForCurrenUser() {
            RemoteProject[] projects = JiraSoapHelper.GetJiraSoapServiceProxy().getProjects(this.AuthenticationToken);
            List<string> keys = new List<string>();
            foreach (RemoteProject rp in projects){
                keys.Add(rp.key);
            }
            return keys;
        }

        /// <summary>
        /// Authenticates a user in a JIRA Server instance, generating an authentication token
        /// that is saved for future calls between JiraConnector and the server.
        /// </summary>
        /// <param name="url">The URL of the JIRA Server Instance</param>
        /// <param name="port">The corresponding port</param>
        /// <param name="username">The username to authenticate</param>
        /// <param name="password">The password corresponding to the user</param>
        public void AuthenticateUser(string url, string port, string username, string password) {
            JiraSoapServiceService proxy = JiraSoapHelper.GetJiraSoapServiceProxy(url, port);
            this.authenticationToken = proxy.login(username, password);
        }

        /// <summary>
        /// This method allows the user to log work done on an issue.
        /// </summary>
        /// <param name="issueId">The ID of the selected issue to log work to</param>
        /// <param name="workDone">A string representing the ammount of work done as entered by the user</param>
        public void LogWorkDone(string issueId, string workDone, string workDescription) {
            //Creates the appropiate url for use in a XML-HTTP request to JIRA.
            string url = JiraHttpHelper.GetJiraRpcUrlForLoggingWorkDone(issueId, workDone, workDescription);

            //Create the request and obtain the response for the XML-HTTP query to JIRA.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.GetResponse();
        }

        /// <summary>
        /// Gets all the "Open" and "In Progress" issues of the selected project assigned to the current user of JiraConnector
        /// </summary>
        /// <param name="projectKey">The project key as stated in the Jira Project Configuration</param>
        /// <returns>A generic list of <c>Issue</c> entities </returns>
        public List<Issue> GetOpenIssuesFromProjectAssignedToCurrentUser(string projectKey) {
            List<Issue> issues;

            //The project id is needed in order to create te query string, so we need to get it from the project key
            string projectId = this.GetProjectIdFromProjectKey(projectKey);

            //Creates the appropiate url for use in a XML-HTTP request to JIRA.
            string url = JiraHttpHelper.GetJiraRpcUrlForFilter(projectId, JiraIssueAsignee.CURRENT_USER, JiraIssueStatus.UNRESOLVED);

            //Create the request and obtain the response for the XML-HTTP query to JIRA.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream resStream = response.GetResponseStream();

            //Parsing of the XML document response containing the list of issues we needed
            issues = JiraXMLHelper.GetIssueListFromXmlStream(resStream);

            //Some HTML Decoding for the issue description...
            foreach (Issue i in issues) {
                TextWriter output = new StringWriter();
                HttpUtility.HtmlDecode(i.Description, output);
                i.Description = output.ToString();
                if(i.Description.Contains("<br/>")){
                    i.Description = i.Description.Replace("<br/>",String.Empty);
                }
            }
            return issues;
        }

        /// <summary>
        /// Gets all the available workflow actions for a given issue
        /// </summary>
        /// <param name="issueKey">The Key of the issue whose available actions we want to know</param>
        /// <returns>A List of integers, each one representing the ID of an available actions</returns>
        public List<int> GetAvailableActions(string issueKey) {
            List<int> ret = new List<int>();
            RemoteNamedObject[] availableActions = JiraSoapHelper.GetJiraSoapServiceProxy().getAvailableActions(AuthenticationToken, issueKey);
            foreach (RemoteNamedObject o in availableActions) {
                ret.Add(Int32.Parse(o.id));
            }
            return ret;
        }

        /// <summary>
        /// Gets all the available resolutions from the JIRA Server Instance
        /// </summary>
        /// <returns>A generic dictionary of strings representing the resolution names and keys</returns>
        public List<KeyValuePair<string,string>> GetAvailableResolutions() {
            List<KeyValuePair<string, string>> ret = new List<KeyValuePair<string, string>>();
            RemoteResolution[] resolutions =  JiraSoapHelper.GetJiraSoapServiceProxy().getResolutions(this.AuthenticationToken);
            foreach (RemoteResolution resolution in resolutions) {
                ret.Add(new KeyValuePair<string, string>(resolution.id,resolution.name));
            }
            return ret;
        }

        /// <summary>
        /// Changes the status of a given Issue to "In Progress"
        /// </summary>
        /// <param name="issueKey">The key of the issue to mark as in progress</param>
        public void StartIssueProgress(string issueKey) {
            string actionId = ((int)JiraWorkflowAction.START_PROGRESS).ToString();
            // No special parameters for this action
            RemoteFieldValue[] actionParams = new RemoteFieldValue[0];
            JiraSoapHelper.GetJiraSoapServiceProxy().progressWorkflowAction(AuthenticationToken, issueKey, actionId, actionParams);
        }

        /// <summary>
        /// Gets a list of Version ID's according to those Versions Names
        /// </summary>
        /// <param name="versionNames">The list containing the versions names whose IDs we want to get</param>
        /// <returns>A list containing the IDs of the appropiate versions</returns>
        public List<string> GetVersionsIdsFromVersionNames(string[] versionNames) {
            List<string> versionIDs = new List<string>();

            RemoteVersion[] projectVersions =
                JiraSoapHelper.GetJiraSoapServiceProxy().getVersions(AuthenticationToken, JiraConfigurationHelper.getCurrentProjectKey());

            foreach (string name in versionNames){
                foreach (RemoteVersion projectVersion in projectVersions) {
                    if (projectVersion.name.Equals(name)){
                        versionIDs.Add(projectVersion.id);
                        break;
                    }
                }
            }
            return versionIDs;
        }

        /// <summary>
        /// Stops the work progress of an Issue
        /// </summary>
        /// <param name="issueKey">The key of the issue whose progress is being stopped</param>
        public void StopIssueProgress(string issueKey){
            string actionId = ((int)JiraWorkflowAction.STOP_PROGRESS).ToString();
            // No special parameters for this action
            RemoteFieldValue[] actionParams = new RemoteFieldValue[0];
            JiraSoapHelper.GetJiraSoapServiceProxy().progressWorkflowAction(AuthenticationToken, issueKey, actionId, actionParams);
        }

        private RemoteCustomFieldValue[] GetIssueCustomFields(string issueKey) {
            return JiraSoapHelper.GetJiraSoapServiceProxy().getIssue(AuthenticationToken, issueKey).customFieldValues;
        }

    }
}
