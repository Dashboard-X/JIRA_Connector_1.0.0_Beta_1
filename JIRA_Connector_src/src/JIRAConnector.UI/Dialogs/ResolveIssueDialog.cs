using System.Collections.Generic;
using System.Windows.Forms;

namespace JIRAConnector.UI.Dialogs
{
    public partial class ResolveIssueDialog : Form{
        public KeyValuePair<string,string> selectedResolution;
        
        public ResolveIssueDialog(){
            InitializeComponent();
        }
        
        /// <summary>
        /// Creates a new instance of the class and initializes de "Resolutions" ComboBox with
        /// all the available resolutions for the user to choose.
        /// </summary>
        public ResolveIssueDialog(List<KeyValuePair<string, string>> resolutions): this(){
            this.cmbResolution.DisplayMember = "Value";
            this.cmbResolution.ValueMember = "Key";
            this.cmbResolution.DataSource = resolutions;
        }

        private void cmbResolution_SelectedIndexChanged(object sender, System.EventArgs e){
            this.selectedResolution = (KeyValuePair<string,string>)this.cmbResolution.SelectedItem;
        }

        private void btnOK_Click(object sender, System.EventArgs e){
            this.Visible = false;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        
        public string ResolutionComment {
            get {
                return this.txtComment.Text;
            }
        }
    }
}