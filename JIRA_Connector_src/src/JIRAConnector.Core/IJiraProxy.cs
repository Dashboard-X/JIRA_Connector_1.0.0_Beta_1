using System.Collections.Generic;
using JIRAConnector.Common;

namespace JIRAConnector.Core{
    /// <summary>
    /// Interface implemented by all the classes that wish to act as a proxy for a JIRA implementation.
    /// </summary>
    public interface IJiraProxy{
        /// <summary>
        /// Gets all the issues of the selected project assigned to the current user of JiraConnector
        /// </summary>
        /// <param name="projectName">The project name as stated in the Jira Configuration</param>
        /// <returns>A Bindable list of <c>Issue</c> entities </returns>
        BusinessObjectBindingList<Issue> GetAllIssuesFromProject(string projectName);
        
        /// <summary>
        /// Adds to an issue some detailed and variable information (such as comments)
        /// </summary>
        /// <param name="issue">The <c>Issue</c> entity to add information to</param>
        void AddDetailedInfoToIssue(Issue issue);

        /// <summary>
        /// Adds a comment to an Issue
        /// </summary>
        /// <param name="issue">The <c>Issue</c> entity to which the comment will be added</param>
        /// <param name="comment">The text of the comment to be added</param>
        void AddCommentToIssue(Issue issue, string comment);

        /// <summary>
        /// Marks an Issue as "Resolved"
        /// </summary>
        /// <param name="issue">The <c>Issue</c> entity to resolve</param>
        /// <param name="resolution">The resolution to assing to the issue</param>
        /// <param name="comment">An Optional Comment to add to the issue when resolving it</param>
        void ResolveIssue(Issue issue, KeyValuePair<string, string> resolution, string comment);

        /// <summary>
        /// Marks an Issue as "Closed"
        /// </summary>
        /// <param name="issue">The <c>Issue</c> entity to close</param>
        /// <param name="resolution">The resolution to assing to the issue</param>
        /// <param name="comment">An Optional Comment to add to the issue when closing it</param>
        void CloseIssue(Issue issue, KeyValuePair<string, string> resolution, string comment);

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
        /// <param name="issue">The selected issue to log work to</param>
        /// <param name="workDone">A string representing the ammount of work done as entered by the user</param>
        void LogWorkDone(Issue issue, string workDone, string workDescription);

        /// <summary>
        /// Gets all the "Open" and "In Progress" issues of the selected project assigned to the current user of JiraConnector
        /// </summary>
        /// <param name="projectKey">The project key as stated in the Jira Configuration</param>
        /// <returns>A Bindable list of <c>Issue</c> entities </returns>
        BusinessObjectBindingList<Issue> GetOpenIssuesFromProject(string projectKey);

        /// <summary>
        /// Gets all the available resolutions from the JIRA Server Instance
        /// </summary>
        /// <returns>A generic dictionary of strings representing the resolution names and keys</returns>
        List<KeyValuePair<string,string>> GetAllResolutions();

        /// <summary>
        /// Changes the status of a given Issue to "In Progress"
        /// </summary>
        /// <param name="issue">The <c>Issue</c> entity to mark as in progress</param>
        void StartIssueProgress(Issue issue);

        /// <summary>
        /// Stops the work progress of an Issue
        /// </summary>
        /// <param name="issue">The <c>Issue</c> whose progress is being stopped</param>
        void StopIssueProgress(Issue selectedIssue);
    }
}
