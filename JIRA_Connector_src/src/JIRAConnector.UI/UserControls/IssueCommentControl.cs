using System.Windows.Forms;
using JIRAConnector.Common;

namespace JIRAConnector.UI.UserControls{
    
    /// <summary>
    /// UserControl that displays a comment made on a Issue
    /// </summary>
    public partial class IssueCommentControl : UserControl{
        
        /// <summary>
        /// Default constructor that initialize all the control's components
        /// </summary>
        public IssueCommentControl(){
            InitializeComponent();
        }
        
        /// <summary>
        /// Overloaded constructor that binds the components to the data to display
        /// </summary>
        /// <param name="comment">The <c>IssueComment</c> entity instance to display</param>
        public IssueCommentControl(IssueComment comment) : this() {
            this.lblAuthor.Text += comment.Author;
            this.lblAuthor.Text += "  Date: " + comment.Date.ToString();
            this.lblCommentText.Text = comment.Text;
        }
    }
}
