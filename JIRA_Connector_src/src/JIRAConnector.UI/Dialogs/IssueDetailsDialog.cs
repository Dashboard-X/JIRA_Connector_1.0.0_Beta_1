using System;
using System.Windows.Forms;
using JIRAConnector.Common;
using JIRAConnector.UI.Helpers;
using JIRAConnector.UI.UserControls;

namespace JIRAConnector.UI.Dialogs{
    /// <summary>
    /// Dialog Window used to display an issue's detailed properties
    /// </summary>
    public partial class IssueDetailsDialog : Form {
        
        /// <summary>
        /// Creates a new instance of the Dialog Form and assigns values to all its controls
        /// </summary>
        /// <param name="issue">The <c>Issue</c> entity whose are going to be displayed</param>
        public IssueDetailsDialog(Issue issue) {
            
            InitializeComponent();
            //TODO: Improve visualization of issue details
            
            this.lblIssueKey.Text += issue.Key;
            
            this.lblIssueType.Text = issue.Type;
            this.pictureIssueType.Image = IconHelper.GetIssueTypeIcon(issue.Type);

            this.lblIssueStatus.Text = issue.Status;
            this.pictureIssueStatus.Image = IconHelper.GetIssueStatusIcon(issue.Status);

            this.lblIssuePriority.Text = issue.Priority;
            this.pictureIssuePriority.Image = IconHelper.GetIssuePriorityIcon(issue.Priority);

            this.lblReporter.Text = issue.Reporter;

            this.lblOriginalEstimate.Text = issue.OriginalEstimate;

            this.lblRemainingEstimate.Text = issue.RemainingEstimate;

            this.lblTimeSpent.Text = issue.TimeSpent;
            
            this.lblUpdated.Text += issue.Updated;

            this.lblCreated.Text += issue.Created;

            this.lblDueDate.Text += issue.DueDate;
            
            this.lblIssueSummary.Text = issue.Summary;

            this.txtIssueDescription.Text = issue.Description;

            this.lblIssueLink.Text = issue.Link;

            this.lblIssueComments.Text = issue.Comments.Count + " Comments:";
            foreach (IssueComment comment in issue.Comments) {
              this.pnlComments.Controls.Add(new IssueCommentControl(comment));
            }
            if (issue.AffectsVersions !=null){
                foreach (String affectVersion in issue.AffectsVersions) {
                    this.lblAffectVersions.Text += affectVersion + " - ";
                }
            }
            if (issue.FixVersions != null) {
                foreach (String fixVersion in issue.FixVersions) {
                    this.lblFixVersions.Text += fixVersion + " - ";
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e){
            this.Dispose();
        }

        private void lblFixVersions_Click(object sender, EventArgs e) {

        }
      
    }
}