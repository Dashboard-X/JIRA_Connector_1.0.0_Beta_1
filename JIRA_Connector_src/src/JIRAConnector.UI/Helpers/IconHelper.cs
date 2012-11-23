using System.Drawing;
using JIRAConnector.UI.Properties;

namespace JIRAConnector.UI.Helpers{
    /// <summary>
    /// Provides functionality for the UI Components to obtain icons needed to display in
    /// several controls / forms
    /// </summary>
    class IconHelper{

        /// <summary>
        /// Obtains an issue type icon based on its type description
        /// </summary>
        internal static Image GetIssueTypeIcon (string issueType) {
            Image ret = null;
            switch (issueType) {
                case "Bug":
                    ret = Resources.JiraConnector_Img_bug;
                    break;
                case "New Feature":
                    ret = Resources.JiraConnector_Img_newfeature;
                    break;
                case "Improvement":
                    ret = Resources.JiraConnector_Img_improvement;
                    break;
                case "Task":
                    ret = Resources.JiraConnector_Img_task;
                    break;
            }
            return ret;
        }

        /// <summary>
        /// Obtains an issue status icon based on its status description
        /// </summary>
        internal static Image GetIssueStatusIcon(string status) {
            Image ret = null;
            switch (status){
                case "Open":
                    ret = Resources.JiraConnector_Img_status_open;
                    break;
                case "Closed":
                    ret = Resources.JiraConnector_Img_status_closed;
                    break;
                case "Resolved":
                    ret = Resources.JiraConnector_Img_status_resolved;
                    break;
                case "Reopened":
                    ret = Resources.JiraConnector_Img_status_reopened;
                    break;
                case "Unassigned":
                    ret = Resources.JiraConnector_Img_status_unassigned;
                    break;
                case "In Progress":
                    ret = Resources.JiraConnector_Img_StatusInProgress;
                    break;
            }
            return ret;
        }

        /// <summary>
        /// Obtains an issue priority icon based on its priority description
        /// </summary>
        internal static Image GetIssuePriorityIcon(string priority) {
            Image ret = null;
            switch (priority){
                case "Blocker":
                    ret = Resources.JiraConnector_Img_priority_blocker;
                    break;
                case "Critical":
                    ret = Resources.JiraConnector_Img_priority_critical;
                    break;
                case "Major":
                    ret = Resources.JiraConnector_Img_priority_major;
                    break;
                case "Minor":
                    ret = Resources.JiraConnector_Img_priority_minor;
                    break;
                case "Trivial":
                    ret = Resources.JiraConnector_Img_priority_trivial;
                    break;
            }
            return ret;
        }
    }
}
