using System;
using System.Collections.Generic;
using JIRAConnector.Common;
using JIRAConnector.Common.Enums;
using JIRAConnector.Common.Exceptions;
using JIRAConnector.Communication;
using System.Collections;

namespace JIRAConnector.Core{
    /// <summary>
    /// Business Logic Process Class that represents a proxy for a JIRA implementation. It's method are implemented as coarse-grained
    /// services intended to be consumed by the UI.
    /// </summary>
    public class JiraProxy : IJiraProxy{
        IJiraProvider provider;
        List<KeyValuePair<string, string>> resolutionsCache;

        private IJiraProvider Provider {
            get {
                if (provider == null) {
                    provider = new JiraProvider();
                }
                return provider;
            }
        }

        /// <summary>
        /// Gets all the issues of the selected project assigned to the current user of JiraConnector
        /// </summary>
        /// <param name="projectName">The project name as stated in the Jira Configuration</param>
        /// <returns>A Bindable list of <c>Issue</c> entities </returns>
        public BusinessObjectBindingList<Issue> GetAllIssuesFromProject(string projectName) {
            List<Issue> issues;
            BusinessObjectBindingList<Issue> ret = new BusinessObjectBindingList<Issue>();
            try {
                issues = Provider.GetAllIssuesFromProjectAssignedToCurrentUser(projectName);
                foreach (Issue i in issues) {
                    ret.Add(i);
                }
            }catch (Exception ex) {
                ExceptionManager.PublishException(ex);
            }
            return ret;
        }

        /// <summary>
        /// Adds to an issue some detailed and variable information (such as comments)
        /// </summary>
        /// <param name="issue">The <c>Issue</c> entity to add information to</param>
        public void AddDetailedInfoToIssue(Issue issue) {
            try {
                issue.Comments = Provider.GetIssueComments(issue.Key);
            } catch (Exception ex) {
                ExceptionManager.PublishException(ex);
            }
        }

        /// <summary>
        /// Adds a comment to an Issue
        /// </summary>
        /// <param name="issue">The <c>Issue</c> entity to which the comment will be added</param>
        /// <param name="comment">The text of the comment to be added</param>
        public void AddCommentToIssue(Issue issue, string comment) {
            try {
                IssueComment issueComment = new IssueComment(JiraConfigurationHelper.GetUserName(), DateTime.Now, comment);
                this.Provider.AddCommentToIssue(issue.Key, issueComment);
            }
            catch (Exception ex){
                ExceptionManager.PublishException(ex);
            }
        }

        /// <summary>
        /// Marks an Issue as "Resolved"
        /// </summary>
        /// <param name="issue">The <c>Issue</c> entity to resolve</param>
        /// <param name="resolution">The resolution to assing to the issue</param>
        /// <param name="comment">An Optional Comment to add to the issue when resolving it</param>
        public void ResolveIssue(Issue issue, KeyValuePair<string, string> resolution, string comment) {
            try {
                if (!CanPerformWorkflowAction(issue,JiraWorkflowAction.RESOLVE)) {
                    throw new FunctionalException("The \"Resolve\" action is not valid for this issue.");
                }

                List<string> fixVersions = this.Provider.GetVersionsIdsFromVersionNames(issue.FixVersions);
                List<string> affectsVersions = this.Provider.GetVersionsIdsFromVersionNames(issue.AffectsVersions);

                this.Provider.ProgressWorkflowForResolution(((int)JiraWorkflowAction.RESOLVE).ToString(),issue.Key, resolution.Key, 
                    comment, fixVersions.ToArray(), affectsVersions.ToArray());

                //For now it's necesarry to add the resolution comment on another different step, after de progression of
                //the workflow action. For more information see http://jira.atlassian.com/browse/JRA-11278
                if (!comment.Equals(String.Empty)) {
                    this.AddCommentToIssue(issue, comment);
                }
            }
            catch (Exception ex){
                ExceptionManager.PublishException(ex);
            }
        }

        public void CloseIssue(Issue issue, KeyValuePair<string, string> resolution, string comment) {
            try {
                if (!CanPerformWorkflowAction(issue, JiraWorkflowAction.CLOSE)) {
                    throw new FunctionalException("The \"Close\" action is not valid for this issue.");
                }

                List<string> fixVersions = this.Provider.GetVersionsIdsFromVersionNames(issue.FixVersions);
                List<string> affectsVersions = this.Provider.GetVersionsIdsFromVersionNames(issue.AffectsVersions);

                this.Provider.ProgressWorkflowForResolution(((int)JiraWorkflowAction.CLOSE).ToString(), issue.Key, resolution.Key,
                    comment, fixVersions.ToArray(), affectsVersions.ToArray());

                //For now it's necesarry to add the resolution comment on another different step, after de progression of
                //the workflow action. For more information see http://jira.atlassian.com/browse/JRA-11278
                if (!comment.Equals(String.Empty)) {
                    this.AddCommentToIssue(issue, comment);
                }
            } catch (Exception ex) {
                ExceptionManager.PublishException(ex);
            }
        }

        /// <summary>
        /// Indicates where a given workflow action is valid for a specific issue
        /// </summary>
        /// <param name="issue">The <c>Issue</c> entity to resolve</param>
        private bool CanPerformWorkflowAction(Issue issue, JiraWorkflowAction action ){
            List<int> availableActions = this.Provider.GetAvailableActions(issue.Key);
            if (availableActions.Contains((int)action)){
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets all the available project keys in a JIRA Server Instance to which the user has access
        /// </summary>
        /// <returns>An array of strings containing the project keys</returns>
        public List<string> GetAllProjectKeysForCurrenUser() {
            List<string> ret = new List<string>();
            try {
                ret = this.Provider.GetAllProjectKeysForCurrenUser();
            }
            catch (Exception ex){
                ExceptionManager.PublishException(ex);
            }
            return ret;
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
            try {
                Provider.AuthenticateUser(url, port, username, password);
            }
            catch (Exception ex){
                ExceptionManager.PublishException(ex);
            }
        }

        /// <summary>
        /// This method allows the user to log work done on an issue.
        /// </summary>
        /// <param name="issue">The selected issue to log work to</param>
        /// <param name="workDone">A string representing the ammount of work done as entered by the user</param>
        public void LogWorkDone(Issue issue, string workDone, string workDescription) {
            try{
                Provider.LogWorkDone(issue.Id,workDone, workDescription);
            }
            catch (Exception ex){
                ExceptionManager.PublishException(ex);
            }
            
        }

        /// <summary>
        /// Gets all the "Open" and "In Progress" issues of the selected project assigned to the current user of JiraConnector
        /// </summary>
        /// <param name="projectKey">The project key as stated in the Jira Configuration</param>
        /// <returns>A Bindable list of <c>Issue</c> entities </returns>
        public BusinessObjectBindingList<Issue> GetOpenIssuesFromProject(string projectKey) {
            List<Issue> issues;
            BusinessObjectBindingList<Issue> ret = new BusinessObjectBindingList<Issue>();
            try{
                issues = Provider.GetOpenIssuesFromProjectAssignedToCurrentUser(projectKey);
                foreach (Issue i in issues){
                    ret.Add(i);
                }
            }
            catch (Exception ex){
                ExceptionManager.PublishException(ex);
            }
            return ret;
        }

        /// <summary>
        /// Gets all the available resolutions from the JIRA Server Instance
        /// </summary>
        /// <returns>A generic dictionary of strings representing the resolution names and keys</returns>
        public List<KeyValuePair<string,string>> GetAllResolutions() {
            //We use a cache for storing the available resolutions
            if (this.resolutionsCache == null) {
                resolutionsCache = this.Provider.GetAvailableResolutions();
            }
            return resolutionsCache;
        }

        /// <summary>
        /// Changes the status of a given Issue to "In Progress"
        /// </summary>
        /// <param name="issue">The <c>Issue</c> entity to mark as in progress</param>
        public void StartIssueProgress(Issue issue) {
            try{
                if (!CanPerformWorkflowAction(issue, JiraWorkflowAction.START_PROGRESS)){
                    throw new FunctionalException("The \"Start Progress\" action is not valid for this issue.");
                }
                this.Provider.StartIssueProgress(issue.Key);
            }catch (Exception ex){
                ExceptionManager.PublishException(ex);
            }
        }

        /// <summary>
        /// Stops the work progress of an Issue
        /// </summary>
        /// <param name="issue">The <c>Issue</c> whose progress is being stopped</param>
        public void StopIssueProgress(Issue selectedIssue){
            try{
                if (!CanPerformWorkflowAction(selectedIssue, JiraWorkflowAction.STOP_PROGRESS)){
                    throw new FunctionalException("The \"Stop Progress\" action is not valid for this issue.");
                }
                this.Provider.StopIssueProgress(selectedIssue.Key);
            }catch (Exception ex){
                ExceptionManager.PublishException(ex);
            }
        }
    }
}
