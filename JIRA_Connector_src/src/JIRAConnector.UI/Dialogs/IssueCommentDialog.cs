using System;
using System.Windows.Forms;

namespace JIRAConnector.UI.Dialogs{
    
    /// <summary>
    /// Dialog Form to input the comment text for an issue.
    /// </summary>
    public partial class IssueCommentDialog : Form{
        /// <summary>
        /// Default public constructor
        /// </summary>
        public IssueCommentDialog(){
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e){
            this.Visible = false;
        }
        
        /// <summary>
        /// Returns the comment text entered by the user
        /// </summary>
        public string Comment {
            get { return this.txtComment.Text; }
        }
    }
}