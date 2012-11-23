using System.Collections.Generic;
using JIRAConnector.Common;

namespace JIRAConnector.Communication{
    public interface IJiraProvider{
        
        /// <summary>
        /// Authenticates a user in a JIRA Implementation
        /// </summary>
        /// <param name="userName">The JIRA UserName</param>
        /// <param name="password">The password for that UserName in clear text</param>
        /// <returns>A boolean indicating where the login attempt was successful or not</returns>
        bool AuthenticateUser(string userName, string password);

        /// <summary>
        /// Gets all the issues of the selected project assigned to the current user of JiraConnector
        /// </summary>
        /// <param name="projectKey">The project key as stated in the Jira Project Configuration</param>
        /// <returns>A generic list of <c>Issue</c> entities </returns>
        List<Issue> GetAllIssuesFromProjectAssignedToCurrentUser(string projectKey);

        /// <summary>
        /// Get all te comments associated with a specified issue
        /// </summary>
        /// <param name="issueKey">The Key of the Issue whose comments are to be retrieved </param>
        /// <returns>A generic list of <c>IssueComment</c> entities</returns>
        List<IssueComment> GetIssueComments(string issueKey);

        /// <summary>
        /// Adds a comment to an Issue
        /// </summary>
        /// <param name="comment">The <c>RemoteComment</c> to add to the issue</param>
        /// <param name="issueKey">The key of the issue to which the comment will be added</param>
        void AddCommentToIssue(string issueKey, IssueComment comment);

        /// <summary>
        /// Progress the workflow of and Issue in order to resolve it or close it
        /// </summary>
        /// <param name="actionId">The string representation of the numeric id corresponding to the workflow action to perform</param>
        /// <param name="issueKey">The key of the Issue to resolve</param>
        /// <param name="resolutionKey">The resolution key of the issue</param>
        /// <param name="resolutionComment">An optional comment related to the action</param>
        /// <param name="fixVersions">A list a list containing all the Issue fix versions' ID's</param>
        /// <param name="affectsVersions">A list a list containing all the Issue affects versions' ID's</param>
        void ProgressWorkflowForResolution(string actionId, string issueKey, string resolutionKey, string resolutionComment, string[] fixVersions, string[] affectsVersions);

        /// <summary>
        /// Gets all the available project keys in a JIRA Server Instance to which the user has access
        /// </summary>
        /// <returns>An array of strings containing the project keys</returns>
        List<string> GetAllProjectKeysForCurrenUser();

        /// <summary>
        /// Authenticates a user in a JIRA Server instance, generating an authentication token
        /// that is saved for future calls between JiraConnector and the server.
        /// </summary>
        /// <param name="url">The URL of the JIRA Server Instance</param>
        /// <param name="port">The corresponding port</param>
        /// <param name="username">The username to authenticate</param>
        /// <param name="password">The password corresponding to the user</param>
        void AuthenticateUser(string url, string port, string username, string password);

        /// <summary>
        /// This method allows the user to log work done on an issue.
        /// </summary>
        /// <param name="issueId">The ID of the selected issue to log work to</param>
        /// <param name="workDone">A string representing the ammount of work done as entered by the user</param>
        void LogWorkDone(string issueId, string workDone, string workDescription);

        /// <summary>
        /// Gets all the "Open" and "In Progress" issues of the selected project assigned to the current user of JiraConnector
        /// </summary>
        /// <param name="projectKey">The project key as stated in the Jira Project Configuration</param>
        /// <returns>A generic list of <c>Issue</c> entities </returns>
        List<Issue> GetOpenIssuesFromProjectAssignedToCurrentUser(string projectKey);

        /// <summary>
        /// Gets all the available workflow actions for a given issue
        /// </summary>
        /// <param name="issueKey">The Key of the issue whose available actions we want to know</param>
        /// <returns>A List of integers, each one representing the ID of an available actions</returns>
        List<int> GetAvailableActions(string issueKey);

        /// <summary>
        /// Gets all the available resolutions from the JIRA Server Instance
        /// </summary>
        /// <returns>A generic dictionary of strings representing the resolution names and keys</returns>
        List<KeyValuePair<string,string>> GetAvailableResolutions();

        /// <summary>
        /// Changes the status of a given Issue to "In Progress"
        /// </summary>
        /// <param name="issueKey">The key of the issue to mark as in progress</param>
        void StartIssueProgress(string issueKey);

        /// <summary>
        /// Gets a list of Version ID's according to those Versions Names
        /// </summary>
        /// <param name="versionNames">The list containing the versions names whose IDs we want to get</param>
        /// <returns>A list containing the IDs of the appropiate versions</returns>
        List<string> GetVersionsIdsFromVersionNames(string[] versionNames);

        /// <summary>
        /// Stops the work progress of an Issue
        /// </summary>
        /// <param name="issueKey">The key of the issue whose progress is being stopped</param>
        void StopIssueProgress(string issueKey);
    }
}
