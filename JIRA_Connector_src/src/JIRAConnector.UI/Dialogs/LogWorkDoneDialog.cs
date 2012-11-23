using System.Windows.Forms;
using JIRAConnector.Common;

namespace JIRAConnector.UI.Dialogs{
    /// <summary>
    /// A dialog form that gives the user the possibility to log work done to an issue
    /// </summary>
    public partial class LogWorkDoneDialog : Form{
        /// <summary>
        /// Default constructor that initialize the UI components of the form.
        /// </summary>
        public LogWorkDoneDialog(Issue issue){
            InitializeComponent();
            this.lblOriginalEstimate.Text += issue.OriginalEstimate;
            this.lblRemainingEstimate.Text += issue.RemainingEstimate;
            this.lblTimeSpent.Text += issue.TimeSpent;
        }
        
        /// <summary>
        /// A string representing the ammount of work done on an issue.
        /// </summary>
        public string WorkDone {
            get { return this.textBox1.Text; }
        }

        private void btnOk_Click(object sender, System.EventArgs e){
            this.Visible = false;
        }
        
        public string WorkDescription {
            get { return this.txtWorkDescription.Text; }
        }
    }
}