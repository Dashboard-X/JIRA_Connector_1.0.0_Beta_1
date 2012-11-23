using System.Text;
using JIRAConnector.Common;
using JIRAConnector.Common.Enums;

namespace JIRAConnector.Communication{
    class JiraHttpHelper{
        
        
        public static string GetJiraBaseURL () {
            string url = JiraConfigurationHelper.GetJiraURL() + ":" + JiraConfigurationHelper.getJiraPort();
            return url;
        }
        
        /// <summary>
        /// This method builds a HTTP URL to perform a request to JIRA in order to get certain issues applying a filter
        /// </summary>
        /// <param name="projectId">The id of the project</param>
        /// <param name="asignee">The asignee whose issues we are filtering</param>
        /// <param name="status">The status of the issues we are filtering</param>
        /// <returns>A string with a well formed URL to perform a XML-HTTP request</returns>
        public static string GetJiraRpcUrlForFilter (string projectId,JiraIssueAsignee asignee, JiraIssueStatus status) {

            StringBuilder url = new StringBuilder();
            url.Append(GetJiraBaseURL());
            url.Append("/secure/IssueNavigator.jspa?");
            url.Append("view=rss");
            url.Append("&pid=" + projectId);
            if (asignee == JiraIssueAsignee.CURRENT_USER) {
                url.Append("&assigneeSelect=issue_current_user");    
            }
            if (status == JiraIssueStatus.OPEN){ 
                url.Append("&status=1");
            }
            if (status == JiraIssueStatus.UNRESOLVED){
                url.Append("&resolution=-1");
            }
            url.Append("&sorter/field=issuekey&sorter/order=DESC");
            url.Append("&reset=true&decorator=none&");
            url.Append("os_username=" + JiraConfigurationHelper.GetUserName());
            url.Append("&os_password=" + JiraConfigurationHelper.GetUserPassword());
                   
            return url.ToString();
        }

        /// <summary>
        /// Gets a formatted URL prepared specially to perform an HTTP Request
        /// that logs work done to an issue
        /// </summary>
        /// <param name="issueId">The ID of the selected issue to log work to</param>
        /// <param name="workDone">A string representing the ammount of work done as entered by the user</param>
        /// <returns>The formatted URL string</returns>
        public static string GetJiraRpcUrlForLoggingWorkDone(string issueId, string workDone, string workDescription) {
            StringBuilder url = new StringBuilder();
            url.Append(GetJiraBaseURL());
            url.Append("/secure/LogWork.jspa?");
            url.Append("id="+issueId);
            url.Append("&timeLogged="+workDone);
            url.Append("&comment=" + workDescription);
            url.Append("&os_username=" + JiraConfigurationHelper.GetUserName());
            url.Append("&os_password=" + JiraConfigurationHelper.GetUserPassword());
            return url.ToString();
        }
    }
}
