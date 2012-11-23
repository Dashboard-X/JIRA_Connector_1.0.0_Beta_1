namespace JIRAConnector.Common.Enums{
    public enum JiraIssueStatus {
       ANY,OPEN,IN_PROGRESS,RESOLVED,CLOSED,UNRESOLVED
    };

    public enum JiraIssueAsignee{
        CURRENT_USER
    };
    
    public enum JiraWorkflowAction {
      RESOLVE=5,CLOSE=2,START_PROGRESS=4,STOP_PROGRESS=301  
    };
}