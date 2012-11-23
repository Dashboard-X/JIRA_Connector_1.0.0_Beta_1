using System;
using System.Windows.Forms;
using JIRAConnector.Common;

namespace JIRAConnector.UI{
    public partial class JiraConnectorMainToolbar : UserControl{
        UIController controller = new UIController();
        private Issue selectedIssue;
        BusinessObjectBindingList<Issue> issueList;
        
        public JiraConnectorMainToolbar(){
            InitializeComponent();
        }

        private void JiraConnectorMainToolbar_Load(object sender, EventArgs e){
            controller.MainToolbar = this;
            LoadIssuesToShow();
        }

        private void LoadIssuesToShow() {
            issueList = 
                controller.GetOpenIssuesFromProject(JiraConfigurationHelper.getCurrentProjectKey());
           
            grdIssues.DataSource = issueList;
           
            grdIssues.AutoGenerateColumns = true;
            
            grdIssues.Columns.Insert(0, new DataGridViewCheckBoxColumn());

            // Don't allow the column to be resizable.
            grdIssues.Columns[0].Resizable = DataGridViewTriState.False;

            // Make the check box column frozen so it is always visible.
            grdIssues.Columns[0].Frozen = true;

            // Put an extra border to make the frozen column more visible
            grdIssues.Columns[0].DividerWidth = 1;

            // Auto size columns after the grid data binding is complete.
            grdIssues.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            
            foreach (DataGridViewRow row in grdIssues.Rows) {
                row.Tag = issueList[row.Index];
            }
        }

        private void grdIssues_CellContentClick(object sender, DataGridViewCellEventArgs e){
            // Update the status bar when the cell value changes.
            if (e.ColumnIndex == 0){
                // Force the update of the value for the checkbox column.
                // Without this, the value doens't get updated until you move off from the cell.
                foreach(DataGridViewRow r in grdIssues.Rows) {
                    if (r.Index == e.RowIndex) {
                        r.Cells[0].Value = !(bool)r.Cells[0].EditedFormattedValue;
                    }else {
                        r.Cells[0].Value = false;   
                    }
                }
                if ((bool)grdIssues.Rows[e.RowIndex].Cells[0].Value){
                    selectedIssue = (Issue)grdIssues.Rows[e.RowIndex].Tag;
                }
                else {
                    selectedIssue = null;
                }
            }       
        }

        private void btnIssueDetail_Click(object sender, EventArgs e){
            this.controller.HandleFullIssueDetailRequest(this.selectedIssue);
        }

        private void grdIssues_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e){
            selectedIssue = null;
            foreach (DataGridViewRow row in grdIssues.Rows){
                row.Cells[0].Value = false; 
                row.Tag = issueList[row.Index];
            }
        }

        private void btnAddComment_Click(object sender, EventArgs e){
            this.controller.HandleAddCommentToIssueRequest(this.selectedIssue);
        }

        private void btnResolveIssue_Click(object sender, EventArgs e){
            this.controller.HandleResolveIssueRequest(this.selectedIssue);
        }

        private void btnLogWork_Click(object sender, EventArgs e){
            this.controller.HandleLogWorkDoneRequest(this.selectedIssue);
        }
        
        internal void RefreshIssuesToShow() {
            //Get the unresolved issues cache from the controller
            issueList =
                controller.GetOpenIssuesFromProject(JiraConfigurationHelper.getCurrentProjectKey());
            //rebind the list
            this.grdIssues.DataSource = issueList;
            
            //save the tag object for each row
            foreach (DataGridViewRow row in grdIssues.Rows){
                row.Tag = issueList[row.Index];
            }
            
            //redraw the grid
            this.grdIssues.Invalidate();
        }

        public BusinessObjectBindingList<Issue> IssueList {
            get { return issueList; }
            set { issueList = value; }
        }

        private void btnStartProgress_Click(object sender, EventArgs e){
            this.controller.HandleStartIssueProgressRequest(this.selectedIssue);
        }

        private void btnRefreshIssues_Click(object sender, EventArgs e){
            this.controller.HandleRefreshIssuesRequest();
        }

        private void btnAbout_Click(object sender, EventArgs e) {
            this.controller.HandleAboutRequest();

        }

        private void btnStopProgress_Click(object sender, EventArgs e){
            this.controller.HandleStopIssueProgressRequest(this.selectedIssue);
        }

        private void btnCloseIssue_Click(object sender, EventArgs e) {
            this.controller.HandleCloseIssueRequest(this.selectedIssue);
        }
    }
}
