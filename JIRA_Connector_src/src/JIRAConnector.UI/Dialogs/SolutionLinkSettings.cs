using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JIRAConnector.UI.Dialogs {
    public partial class SolutionLinkSettings : Form {
        private UISolution solution = null;

        public SolutionLinkSettings(UISolution solution) {
            InitializeComponent();
            this.solution = solution;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            
            //Solution.Settings.ProjectKey = txtProjectKey.Text;
            
            Close();
        }

        public UISolution Solution {
            get { return solution; }
        }

        private void btnTest_Click(object sender, EventArgs e){
            this.lblTesting.Visible = true;
            this.lblTesting.Text = "TESTING...";
            Cursor.Current = Cursors.WaitCursor;
            Solution.Settings.Url = txtUrl.Text;
            Solution.Settings.Port = txtPort.Text;
            Solution.Settings.Username = txtUserName.Text;
            Solution.Settings.Password = txtPassword.Text;
            UIController controller = new UIController();
            controller.HandleTestSettingsRequest(this);
        }

        public void DisplayProjectKeys(List<string> keys) {
            Cursor.Current = Cursors.Default;
            this.lblTesting.Text = "TEST OK. Please select a project";
            this.btnOk.Enabled = true;
            this.btnTest.Enabled = true;
            this.btnTest.Text = "Test Again";
            this.cmbProjects.Enabled = true;
            this.cmbProjects.DataSource = keys;
        }

        public void DisplayTestFailedMessage() {
            Cursor.Current = Cursors.Default;
            this.lblTesting.Text = "TEST FAILED. Check your settings";
            this.btnTest.Text = "Test Again";
        }

        private void cmbProjects_SelectedIndexChanged(object sender, EventArgs e){
            Solution.Settings.ProjectKey = cmbProjects.SelectedItem.ToString();
        }
    }
}