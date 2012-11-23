using System;
using System.Windows.Forms;
using JIRAConnector.Common;

namespace JIRAConnector.UI{
    
    /// <summary>
    /// Dialog Window used to display an issue's detailed properties
    /// </summary>
    public partial class IssueDetailDialog : Form {
        
        /// <summary>
        /// Creates a new instance of the Dialog Form and assigns values to all its controls
        /// </summary>
        /// <param name="issue">The <c>Issue</c> entity whose are going to be displayed</param>
        public IssueDetailDialog(Issue issue) {
            
            InitializeComponent();
            //TODO: Improve visualization of issue details
            
            this.lblIssueKey.Text += issue.Key;
            this.lblIssueTitle.Text += issue.Title;
            this.lblIssueType.Text += issue.Type;
            this.lblIssueSummary.Text += issue.Summary;
            foreach (IssueComment comment in issue.Comments) {
                this.lblIssueComments.Text += comment.Text;
                this.lblIssueComments.Text += "\n";
            }
        }

        private void btnClose_Click(object sender, EventArgs e){
            this.Dispose();
        }
      
    }
}