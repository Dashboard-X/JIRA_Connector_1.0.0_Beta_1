using System;
using JIRAConnector.Common;

namespace JIRAConnector.UI.Dialogs
{
    partial class IssueDetailsDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.lblIssueKey = new System.Windows.Forms.Label();
            this.lblIssueSummary = new System.Windows.Forms.Label();
            this.lblTitleIssueType = new System.Windows.Forms.Label();
            this.lblIssueDescription = new System.Windows.Forms.Label();
            this.lblIssueComments = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblTimeSpent = new System.Windows.Forms.Label();
            this.lblTimeSpentTitle = new System.Windows.Forms.Label();
            this.lblRemainingEstimate = new System.Windows.Forms.Label();
            this.lblRemainingEstimateTitle = new System.Windows.Forms.Label();
            this.lblOriginalEstimate = new System.Windows.Forms.Label();
            this.lblOriginalEstimateTitle = new System.Windows.Forms.Label();
            this.lblReporter = new System.Windows.Forms.Label();
            this.lblReporterText = new System.Windows.Forms.Label();
            this.lblIssuePriority = new System.Windows.Forms.Label();
            this.pictureIssuePriority = new System.Windows.Forms.PictureBox();
            this.lblTitleIssuePriority = new System.Windows.Forms.Label();
            this.lblIssueStatus = new System.Windows.Forms.Label();
            this.pictureIssueStatus = new System.Windows.Forms.PictureBox();
            this.lblTitleIssueStatus = new System.Windows.Forms.Label();
            this.lblIssueType = new System.Windows.Forms.Label();
            this.pictureIssueType = new System.Windows.Forms.PictureBox();
            this.lblFixVersions = new System.Windows.Forms.Label();
            this.lblAffectVersions = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblUpdated = new System.Windows.Forms.Label();
            this.lblIssueLink = new System.Windows.Forms.LinkLabel();
            this.lblCreated = new System.Windows.Forms.Label();
            this.pnlComments = new System.Windows.Forms.TableLayoutPanel();
            this.txtIssueDescription = new System.Windows.Forms.TextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIssuePriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIssueStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIssueType)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(368, 398);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close Window";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblIssueKey
            // 
            this.lblIssueKey.AutoSize = true;
            this.lblIssueKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueKey.Location = new System.Drawing.Point(3, 12);
            this.lblIssueKey.Name = "lblIssueKey";
            this.lblIssueKey.Size = new System.Drawing.Size(36, 13);
            this.lblIssueKey.TabIndex = 1;
            this.lblIssueKey.Text = "Key: ";
            // 
            // lblIssueSummary
            // 
            this.lblIssueSummary.AutoSize = true;
            this.lblIssueSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueSummary.Location = new System.Drawing.Point(15, 10);
            this.lblIssueSummary.Name = "lblIssueSummary";
            this.lblIssueSummary.Size = new System.Drawing.Size(111, 18);
            this.lblIssueSummary.TabIndex = 2;
            this.lblIssueSummary.Text = "<SUMMARY>";
            // 
            // lblTitleIssueType
            // 
            this.lblTitleIssueType.AutoSize = true;
            this.lblTitleIssueType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleIssueType.Location = new System.Drawing.Point(1, 39);
            this.lblTitleIssueType.Name = "lblTitleIssueType";
            this.lblTitleIssueType.Size = new System.Drawing.Size(47, 13);
            this.lblTitleIssueType.TabIndex = 3;
            this.lblTitleIssueType.Text = "Type:  ";
            // 
            // lblIssueDescription
            // 
            this.lblIssueDescription.AutoSize = true;
            this.lblIssueDescription.Location = new System.Drawing.Point(15, 112);
            this.lblIssueDescription.Name = "lblIssueDescription";
            this.lblIssueDescription.Size = new System.Drawing.Size(63, 13);
            this.lblIssueDescription.TabIndex = 4;
            this.lblIssueDescription.Text = "Description:";
            // 
            // lblIssueComments
            // 
            this.lblIssueComments.AutoSize = true;
            this.lblIssueComments.Location = new System.Drawing.Point(15, 217);
            this.lblIssueComments.Name = "lblIssueComments";
            this.lblIssueComments.Size = new System.Drawing.Size(62, 13);
            this.lblIssueComments.TabIndex = 5;
            this.lblIssueComments.Text = "Comments: ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(2, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblTimeSpent);
            this.splitContainer1.Panel1.Controls.Add(this.lblTimeSpentTitle);
            this.splitContainer1.Panel1.Controls.Add(this.lblRemainingEstimate);
            this.splitContainer1.Panel1.Controls.Add(this.lblRemainingEstimateTitle);
            this.splitContainer1.Panel1.Controls.Add(this.lblOriginalEstimate);
            this.splitContainer1.Panel1.Controls.Add(this.lblOriginalEstimateTitle);
            this.splitContainer1.Panel1.Controls.Add(this.lblReporter);
            this.splitContainer1.Panel1.Controls.Add(this.lblReporterText);
            this.splitContainer1.Panel1.Controls.Add(this.lblIssuePriority);
            this.splitContainer1.Panel1.Controls.Add(this.pictureIssuePriority);
            this.splitContainer1.Panel1.Controls.Add(this.lblTitleIssuePriority);
            this.splitContainer1.Panel1.Controls.Add(this.lblIssueStatus);
            this.splitContainer1.Panel1.Controls.Add(this.pictureIssueStatus);
            this.splitContainer1.Panel1.Controls.Add(this.lblTitleIssueStatus);
            this.splitContainer1.Panel1.Controls.Add(this.lblIssueType);
            this.splitContainer1.Panel1.Controls.Add(this.pictureIssueType);
            this.splitContainer1.Panel1.Controls.Add(this.lblIssueKey);
            this.splitContainer1.Panel1.Controls.Add(this.lblTitleIssueType);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblFixVersions);
            this.splitContainer1.Panel2.Controls.Add(this.lblAffectVersions);
            this.splitContainer1.Panel2.Controls.Add(this.lblDueDate);
            this.splitContainer1.Panel2.Controls.Add(this.lblUpdated);
            this.splitContainer1.Panel2.Controls.Add(this.lblIssueLink);
            this.splitContainer1.Panel2.Controls.Add(this.lblCreated);
            this.splitContainer1.Panel2.Controls.Add(this.pnlComments);
            this.splitContainer1.Panel2.Controls.Add(this.txtIssueDescription);
            this.splitContainer1.Panel2.Controls.Add(this.lblIssueComments);
            this.splitContainer1.Panel2.Controls.Add(this.lblIssueSummary);
            this.splitContainer1.Panel2.Controls.Add(this.lblIssueDescription);
            this.splitContainer1.Size = new System.Drawing.Size(811, 379);
            this.splitContainer1.SplitterDistance = 156;
            this.splitContainer1.TabIndex = 6;
            // 
            // lblTimeSpent
            // 
            this.lblTimeSpent.AutoSize = true;
            this.lblTimeSpent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeSpent.Location = new System.Drawing.Point(3, 246);
            this.lblTimeSpent.Name = "lblTimeSpent";
            this.lblTimeSpent.Size = new System.Drawing.Size(27, 13);
            this.lblTimeSpent.TabIndex = 19;
            this.lblTimeSpent.Text = "xxxx";
            // 
            // lblTimeSpentTitle
            // 
            this.lblTimeSpentTitle.AutoSize = true;
            this.lblTimeSpentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeSpentTitle.Location = new System.Drawing.Point(3, 233);
            this.lblTimeSpentTitle.Name = "lblTimeSpentTitle";
            this.lblTimeSpentTitle.Size = new System.Drawing.Size(75, 13);
            this.lblTimeSpentTitle.TabIndex = 18;
            this.lblTimeSpentTitle.Text = "Time Spent:";
            // 
            // lblRemainingEstimate
            // 
            this.lblRemainingEstimate.AutoSize = true;
            this.lblRemainingEstimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingEstimate.Location = new System.Drawing.Point(3, 202);
            this.lblRemainingEstimate.Name = "lblRemainingEstimate";
            this.lblRemainingEstimate.Size = new System.Drawing.Size(27, 13);
            this.lblRemainingEstimate.TabIndex = 17;
            this.lblRemainingEstimate.Text = "xxxx";
            // 
            // lblRemainingEstimateTitle
            // 
            this.lblRemainingEstimateTitle.AutoSize = true;
            this.lblRemainingEstimateTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingEstimateTitle.Location = new System.Drawing.Point(3, 189);
            this.lblRemainingEstimateTitle.Name = "lblRemainingEstimateTitle";
            this.lblRemainingEstimateTitle.Size = new System.Drawing.Size(122, 13);
            this.lblRemainingEstimateTitle.TabIndex = 16;
            this.lblRemainingEstimateTitle.Text = "Remaining Estimate:";
            // 
            // lblOriginalEstimate
            // 
            this.lblOriginalEstimate.AutoSize = true;
            this.lblOriginalEstimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginalEstimate.Location = new System.Drawing.Point(3, 158);
            this.lblOriginalEstimate.Name = "lblOriginalEstimate";
            this.lblOriginalEstimate.Size = new System.Drawing.Size(27, 13);
            this.lblOriginalEstimate.TabIndex = 15;
            this.lblOriginalEstimate.Text = "xxxx";
            // 
            // lblOriginalEstimateTitle
            // 
            this.lblOriginalEstimateTitle.AutoSize = true;
            this.lblOriginalEstimateTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginalEstimateTitle.Location = new System.Drawing.Point(1, 145);
            this.lblOriginalEstimateTitle.Name = "lblOriginalEstimateTitle";
            this.lblOriginalEstimateTitle.Size = new System.Drawing.Size(106, 13);
            this.lblOriginalEstimateTitle.TabIndex = 14;
            this.lblOriginalEstimateTitle.Text = "Original Estimate:";
            // 
            // lblReporter
            // 
            this.lblReporter.AutoSize = true;
            this.lblReporter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReporter.Location = new System.Drawing.Point(73, 112);
            this.lblReporter.Name = "lblReporter";
            this.lblReporter.Size = new System.Drawing.Size(54, 13);
            this.lblReporter.TabIndex = 13;
            this.lblReporter.Text = "Reporter: ";
            // 
            // lblReporterText
            // 
            this.lblReporterText.AutoSize = true;
            this.lblReporterText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReporterText.Location = new System.Drawing.Point(1, 112);
            this.lblReporterText.Name = "lblReporterText";
            this.lblReporterText.Size = new System.Drawing.Size(64, 13);
            this.lblReporterText.TabIndex = 12;
            this.lblReporterText.Text = "Reporter: ";
            // 
            // lblIssuePriority
            // 
            this.lblIssuePriority.AutoSize = true;
            this.lblIssuePriority.Location = new System.Drawing.Point(73, 89);
            this.lblIssuePriority.Name = "lblIssuePriority";
            this.lblIssuePriority.Size = new System.Drawing.Size(70, 13);
            this.lblIssuePriority.TabIndex = 11;
            this.lblIssuePriority.Text = "<PRIORITY>";
            // 
            // pictureIssuePriority
            // 
            this.pictureIssuePriority.Location = new System.Drawing.Point(50, 89);
            this.pictureIssuePriority.Name = "pictureIssuePriority";
            this.pictureIssuePriority.Size = new System.Drawing.Size(22, 14);
            this.pictureIssuePriority.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureIssuePriority.TabIndex = 10;
            this.pictureIssuePriority.TabStop = false;
            // 
            // lblTitleIssuePriority
            // 
            this.lblTitleIssuePriority.AutoSize = true;
            this.lblTitleIssuePriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleIssuePriority.Location = new System.Drawing.Point(1, 90);
            this.lblTitleIssuePriority.Name = "lblTitleIssuePriority";
            this.lblTitleIssuePriority.Size = new System.Drawing.Size(50, 13);
            this.lblTitleIssuePriority.TabIndex = 9;
            this.lblTitleIssuePriority.Text = "Priority:";
            // 
            // lblIssueStatus
            // 
            this.lblIssueStatus.AutoSize = true;
            this.lblIssueStatus.Location = new System.Drawing.Point(73, 64);
            this.lblIssueStatus.Name = "lblIssueStatus";
            this.lblIssueStatus.Size = new System.Drawing.Size(62, 13);
            this.lblIssueStatus.TabIndex = 8;
            this.lblIssueStatus.Text = "<STATUS>";
            // 
            // pictureIssueStatus
            // 
            this.pictureIssueStatus.Location = new System.Drawing.Point(50, 64);
            this.pictureIssueStatus.Name = "pictureIssueStatus";
            this.pictureIssueStatus.Size = new System.Drawing.Size(22, 14);
            this.pictureIssueStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureIssueStatus.TabIndex = 7;
            this.pictureIssueStatus.TabStop = false;
            // 
            // lblTitleIssueStatus
            // 
            this.lblTitleIssueStatus.AutoSize = true;
            this.lblTitleIssueStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleIssueStatus.Location = new System.Drawing.Point(1, 65);
            this.lblTitleIssueStatus.Name = "lblTitleIssueStatus";
            this.lblTitleIssueStatus.Size = new System.Drawing.Size(47, 13);
            this.lblTitleIssueStatus.TabIndex = 6;
            this.lblTitleIssueStatus.Text = "Status:";
            // 
            // lblIssueType
            // 
            this.lblIssueType.AutoSize = true;
            this.lblIssueType.Location = new System.Drawing.Point(73, 38);
            this.lblIssueType.Name = "lblIssueType";
            this.lblIssueType.Size = new System.Drawing.Size(79, 13);
            this.lblIssueType.TabIndex = 5;
            this.lblIssueType.Text = "<ISSUETYPE>";
            // 
            // pictureIssueType
            // 
            this.pictureIssueType.Location = new System.Drawing.Point(50, 38);
            this.pictureIssueType.Name = "pictureIssueType";
            this.pictureIssueType.Size = new System.Drawing.Size(22, 14);
            this.pictureIssueType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureIssueType.TabIndex = 4;
            this.pictureIssueType.TabStop = false;
            // 
            // lblFixVersions
            // 
            this.lblFixVersions.AutoSize = true;
            this.lblFixVersions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixVersions.Location = new System.Drawing.Point(411, 89);
            this.lblFixVersions.Name = "lblFixVersions";
            this.lblFixVersions.Size = new System.Drawing.Size(93, 13);
            this.lblFixVersions.TabIndex = 17;
            this.lblFixVersions.Text = "Fix Version/s:  ";
            this.lblFixVersions.Click += new System.EventHandler(this.lblFixVersions_Click);
            // 
            // lblAffectVersions
            // 
            this.lblAffectVersions.AutoSize = true;
            this.lblAffectVersions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffectVersions.Location = new System.Drawing.Point(15, 90);
            this.lblAffectVersions.Name = "lblAffectVersions";
            this.lblAffectVersions.Size = new System.Drawing.Size(111, 13);
            this.lblAffectVersions.TabIndex = 16;
            this.lblAffectVersions.Text = "Affect Version/s:  ";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.Location = new System.Drawing.Point(411, 65);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(34, 13);
            this.lblDueDate.TabIndex = 15;
            this.lblDueDate.Text = "Due:";
            // 
            // lblUpdated
            // 
            this.lblUpdated.AutoSize = true;
            this.lblUpdated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdated.Location = new System.Drawing.Point(209, 64);
            this.lblUpdated.Name = "lblUpdated";
            this.lblUpdated.Size = new System.Drawing.Size(63, 13);
            this.lblUpdated.TabIndex = 14;
            this.lblUpdated.Text = "Updated: ";
            // 
            // lblIssueLink
            // 
            this.lblIssueLink.AutoSize = true;
            this.lblIssueLink.Location = new System.Drawing.Point(15, 39);
            this.lblIssueLink.Name = "lblIssueLink";
            this.lblIssueLink.Size = new System.Drawing.Size(43, 13);
            this.lblIssueLink.TabIndex = 8;
            this.lblIssueLink.TabStop = true;
            this.lblIssueLink.Text = "<LINK>";
            // 
            // lblCreated
            // 
            this.lblCreated.AutoSize = true;
            this.lblCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreated.Location = new System.Drawing.Point(14, 64);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(59, 13);
            this.lblCreated.TabIndex = 13;
            this.lblCreated.Text = "Created: ";
            // 
            // pnlComments
            // 
            this.pnlComments.AutoScroll = true;
            this.pnlComments.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pnlComments.ColumnCount = 1;
            this.pnlComments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlComments.Location = new System.Drawing.Point(17, 233);
            this.pnlComments.Name = "pnlComments";
            this.pnlComments.RowCount = 1;
            this.pnlComments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlComments.Size = new System.Drawing.Size(607, 124);
            this.pnlComments.TabIndex = 7;
            // 
            // txtIssueDescription
            // 
            this.txtIssueDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIssueDescription.Location = new System.Drawing.Point(17, 128);
            this.txtIssueDescription.Multiline = true;
            this.txtIssueDescription.Name = "txtIssueDescription";
            this.txtIssueDescription.ReadOnly = true;
            this.txtIssueDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIssueDescription.Size = new System.Drawing.Size(607, 76);
            this.txtIssueDescription.TabIndex = 6;
            // 
            // IssueDetailsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 433);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssueDetailsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Details";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureIssuePriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIssueStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIssueType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblIssueKey;
        private System.Windows.Forms.Label lblIssueSummary;
        private System.Windows.Forms.Label lblTitleIssueType;
        private System.Windows.Forms.Label lblIssueDescription;
        private System.Windows.Forms.Label lblIssueComments;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureIssueType;
        private System.Windows.Forms.Label lblIssueType;
        private System.Windows.Forms.Label lblIssueStatus;
        private System.Windows.Forms.PictureBox pictureIssueStatus;
        private System.Windows.Forms.Label lblTitleIssueStatus;
        private System.Windows.Forms.Label lblIssuePriority;
        private System.Windows.Forms.PictureBox pictureIssuePriority;
        private System.Windows.Forms.Label lblTitleIssuePriority;
        private System.Windows.Forms.TextBox txtIssueDescription;
        private System.Windows.Forms.TableLayoutPanel pnlComments;
        private System.Windows.Forms.Label lblUpdated;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label lblReporterText;
        private System.Windows.Forms.LinkLabel lblIssueLink;
        private System.Windows.Forms.Label lblReporter;
        private System.Windows.Forms.Label lblTimeSpent;
        private System.Windows.Forms.Label lblTimeSpentTitle;
        private System.Windows.Forms.Label lblRemainingEstimate;
        private System.Windows.Forms.Label lblRemainingEstimateTitle;
        private System.Windows.Forms.Label lblOriginalEstimate;
        private System.Windows.Forms.Label lblOriginalEstimateTitle;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblAffectVersions;
        private System.Windows.Forms.Label lblFixVersions;

       
    }
}