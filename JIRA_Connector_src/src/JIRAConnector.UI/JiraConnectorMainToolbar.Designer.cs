namespace JIRAConnector.UI
{
    partial class JiraConnectorMainToolbar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.mainMenuToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnRefreshIssues = new System.Windows.Forms.ToolStripButton();
            this.btnAbout = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.commandsToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.btnIssueDetail = new System.Windows.Forms.ToolStripButton();
            this.btnAddComment = new System.Windows.Forms.ToolStripButton();
            this.btnLogWork = new System.Windows.Forms.ToolStripButton();
            this.btnStartProgress = new System.Windows.Forms.ToolStripButton();
            this.btnStopProgress = new System.Windows.Forms.ToolStripButton();
            this.btnResolveIssue = new System.Windows.Forms.ToolStripButton();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabIssues = new System.Windows.Forms.TabPage();
            this.grdIssues = new System.Windows.Forms.DataGridView();
            this.btnCloseIssue = new System.Windows.Forms.ToolStripButton();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.mainMenuToolStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.commandsToolStrip.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabIssues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIssues)).BeginInit();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.mainMenuToolStrip);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.mainSplitContainer.Size = new System.Drawing.Size(699, 224);
            this.mainSplitContainer.SplitterDistance = 36;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // mainMenuToolStrip
            // 
            this.mainMenuToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainMenuToolStrip.ImageScalingSize = new System.Drawing.Size(26, 26);
            this.mainMenuToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshIssues,
            this.btnAbout});
            this.mainMenuToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.mainMenuToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuToolStrip.Name = "mainMenuToolStrip";
            this.mainMenuToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mainMenuToolStrip.Size = new System.Drawing.Size(36, 224);
            this.mainMenuToolStrip.TabIndex = 0;
            this.mainMenuToolStrip.Text = "Jira Connector Action Menu";
            // 
            // btnRefreshIssues
            // 
            this.btnRefreshIssues.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshIssues.Image = global::JIRAConnector.UI.Properties.Resources.JiraConnector_Img_RefreshIssues;
            this.btnRefreshIssues.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshIssues.Name = "btnRefreshIssues";
            this.btnRefreshIssues.Size = new System.Drawing.Size(34, 30);
            this.btnRefreshIssues.Text = "Refresh Issues";
            this.btnRefreshIssues.ToolTipText = "Refresh Issues";
            this.btnRefreshIssues.Click += new System.EventHandler(this.btnRefreshIssues_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbout.Image = global::JIRAConnector.UI.Properties.Resources.jira_connector_logo;
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(34, 30);
            this.btnAbout.Text = "About...";
            this.btnAbout.ToolTipText = "About JiraConnector";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.commandsToolStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainTabControl, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.16071F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.83929F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(659, 224);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // commandsToolStrip
            // 
            this.commandsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.commandsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.commandsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.btnIssueDetail,
            this.btnAddComment,
            this.btnLogWork,
            this.btnStartProgress,
            this.btnStopProgress,
            this.btnResolveIssue,
            this.btnCloseIssue});
            this.commandsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.commandsToolStrip.Name = "commandsToolStrip";
            this.commandsToolStrip.Size = new System.Drawing.Size(659, 24);
            this.commandsToolStrip.TabIndex = 2;
            this.commandsToolStrip.Text = "toolStrip2";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Filters....."});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 24);
            // 
            // btnIssueDetail
            // 
            this.btnIssueDetail.Image = global::JIRAConnector.UI.Properties.Resources.JiraConnector_Img_Info1;
            this.btnIssueDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIssueDetail.Name = "btnIssueDetail";
            this.btnIssueDetail.Size = new System.Drawing.Size(84, 21);
            this.btnIssueDetail.Text = "&View Details";
            this.btnIssueDetail.Click += new System.EventHandler(this.btnIssueDetail_Click);
            // 
            // btnAddComment
            // 
            this.btnAddComment.Image = global::JIRAConnector.UI.Properties.Resources.JiraConnector_Img_Pencil1;
            this.btnAddComment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(94, 21);
            this.btnAddComment.Text = "Add Comment";
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // btnLogWork
            // 
            this.btnLogWork.Image = global::JIRAConnector.UI.Properties.Resources.JiraConnector_Img_Calendar;
            this.btnLogWork.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLogWork.Name = "btnLogWork";
            this.btnLogWork.Size = new System.Drawing.Size(72, 21);
            this.btnLogWork.Text = "Log Work";
            this.btnLogWork.Click += new System.EventHandler(this.btnLogWork_Click);
            // 
            // btnStartProgress
            // 
            this.btnStartProgress.Image = global::JIRAConnector.UI.Properties.Resources.JiraConnector_Img_Start_Icon;
            this.btnStartProgress.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartProgress.Name = "btnStartProgress";
            this.btnStartProgress.Size = new System.Drawing.Size(96, 21);
            this.btnStartProgress.Text = "Start Progress";
            this.btnStartProgress.Click += new System.EventHandler(this.btnStartProgress_Click);
            // 
            // btnStopProgress
            // 
            this.btnStopProgress.Image = global::JIRAConnector.UI.Properties.Resources.JiraConnector_Img_Stop_Icon;
            this.btnStopProgress.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopProgress.Name = "btnStopProgress";
            this.btnStopProgress.Size = new System.Drawing.Size(94, 21);
            this.btnStopProgress.Text = "Stop Progress";
            this.btnStopProgress.Click += new System.EventHandler(this.btnStopProgress_Click);
            // 
            // btnResolveIssue
            // 
            this.btnResolveIssue.Image = global::JIRAConnector.UI.Properties.Resources.JiraConnector_Img_StatusResolved;
            this.btnResolveIssue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResolveIssue.Name = "btnResolveIssue";
            this.btnResolveIssue.Size = new System.Drawing.Size(65, 21);
            this.btnResolveIssue.Text = "Resolve";
            this.btnResolveIssue.Click += new System.EventHandler(this.btnResolveIssue_Click);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.mainTabControl.Controls.Add(this.tabIssues);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(3, 27);
            this.mainTabControl.Multiline = true;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(653, 194);
            this.mainTabControl.TabIndex = 1;
            // 
            // tabIssues
            // 
            this.tabIssues.Controls.Add(this.grdIssues);
            this.tabIssues.Location = new System.Drawing.Point(4, 4);
            this.tabIssues.Name = "tabIssues";
            this.tabIssues.Padding = new System.Windows.Forms.Padding(3);
            this.tabIssues.Size = new System.Drawing.Size(645, 168);
            this.tabIssues.TabIndex = 0;
            this.tabIssues.Text = "My Issues";
            this.tabIssues.UseVisualStyleBackColor = true;
            // 
            // grdIssues
            // 
            this.grdIssues.AllowUserToAddRows = false;
            this.grdIssues.AllowUserToDeleteRows = false;
            this.grdIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIssues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIssues.Location = new System.Drawing.Point(3, 3);
            this.grdIssues.MultiSelect = false;
            this.grdIssues.Name = "grdIssues";
            this.grdIssues.ReadOnly = true;
            this.grdIssues.RowHeadersVisible = false;
            this.grdIssues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdIssues.Size = new System.Drawing.Size(639, 162);
            this.grdIssues.TabIndex = 0;
            this.grdIssues.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdIssues_ColumnHeaderMouseClick);
            this.grdIssues.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdIssues_CellContentClick);
            // 
            // btnCloseIssue
            // 
            this.btnCloseIssue.Image = global::JIRAConnector.UI.Properties.Resources.JiraConnector_Img_status_closed;
            this.btnCloseIssue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseIssue.Name = "btnCloseIssue";
            this.btnCloseIssue.Size = new System.Drawing.Size(53, 20);
            this.btnCloseIssue.Text = "Close";
            this.btnCloseIssue.Click += new System.EventHandler(this.btnCloseIssue_Click);
            // 
            // JiraConnectorMainToolbar
            // 
            this.Controls.Add(this.mainSplitContainer);
            this.Name = "JiraConnectorMainToolbar";
            this.Size = new System.Drawing.Size(699, 224);
            this.Load += new System.EventHandler(this.JiraConnectorMainToolbar_Load);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel1.PerformLayout();
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.ResumeLayout(false);
            this.mainMenuToolStrip.ResumeLayout(false);
            this.mainMenuToolStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.commandsToolStrip.ResumeLayout(false);
            this.commandsToolStrip.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.tabIssues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdIssues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.ToolStrip mainMenuToolStrip;
        private System.Windows.Forms.ToolStripButton btnAbout;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabIssues;
        private System.Windows.Forms.DataGridView grdIssues;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip commandsToolStrip;
        private System.Windows.Forms.ToolStripButton btnIssueDetail;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripButton btnAddComment;
        private System.Windows.Forms.ToolStripButton btnResolveIssue;
        private System.Windows.Forms.ToolStripButton btnLogWork;
        private System.Windows.Forms.ToolStripButton btnStartProgress;
        private System.Windows.Forms.ToolStripButton btnRefreshIssues;
        private System.Windows.Forms.ToolStripButton btnStopProgress;
        private System.Windows.Forms.ToolStripButton btnCloseIssue;


    }
}
