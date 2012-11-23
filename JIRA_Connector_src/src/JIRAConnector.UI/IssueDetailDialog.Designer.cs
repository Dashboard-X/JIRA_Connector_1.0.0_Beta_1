using System;
using JIRAConnector.Common;

namespace JIRAConnector.UI
{
    partial class IssueDetailDialog
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
            this.lblIssueTitle = new System.Windows.Forms.Label();
            this.lblIssueType = new System.Windows.Forms.Label();
            this.lblIssueSummary = new System.Windows.Forms.Label();
            this.lblIssueComments = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(219, 265);
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
            this.lblIssueKey.Location = new System.Drawing.Point(12, 9);
            this.lblIssueKey.Name = "lblIssueKey";
            this.lblIssueKey.Size = new System.Drawing.Size(31, 13);
            this.lblIssueKey.TabIndex = 1;
            this.lblIssueKey.Text = "Key: ";
            // 
            // lblIssueTitle
            // 
            this.lblIssueTitle.AutoSize = true;
            this.lblIssueTitle.Location = new System.Drawing.Point(12, 35);
            this.lblIssueTitle.Name = "lblIssueTitle";
            this.lblIssueTitle.Size = new System.Drawing.Size(33, 13);
            this.lblIssueTitle.TabIndex = 2;
            this.lblIssueTitle.Text = "Title: ";
            // 
            // lblIssueType
            // 
            this.lblIssueType.AutoSize = true;
            this.lblIssueType.Location = new System.Drawing.Point(12, 61);
            this.lblIssueType.Name = "lblIssueType";
            this.lblIssueType.Size = new System.Drawing.Size(40, 13);
            this.lblIssueType.TabIndex = 3;
            this.lblIssueType.Text = "Type:  ";
            // 
            // lblIssueSummary
            // 
            this.lblIssueSummary.AutoSize = true;
            this.lblIssueSummary.Location = new System.Drawing.Point(12, 86);
            this.lblIssueSummary.Name = "lblIssueSummary";
            this.lblIssueSummary.Size = new System.Drawing.Size(56, 13);
            this.lblIssueSummary.TabIndex = 4;
            this.lblIssueSummary.Text = "Summary: ";
            // 
            // lblIssueComments
            // 
            this.lblIssueComments.AutoSize = true;
            this.lblIssueComments.Location = new System.Drawing.Point(12, 115);
            this.lblIssueComments.Name = "lblIssueComments";
            this.lblIssueComments.Size = new System.Drawing.Size(62, 13);
            this.lblIssueComments.TabIndex = 5;
            this.lblIssueComments.Text = "Comments: ";
            // 
            // IssueDetailDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 300);
            this.Controls.Add(this.lblIssueComments);
            this.Controls.Add(this.lblIssueKey);
            this.Controls.Add(this.lblIssueSummary);
            this.Controls.Add(this.lblIssueTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblIssueType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssueDetailDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblIssueKey;
        private System.Windows.Forms.Label lblIssueTitle;
        private System.Windows.Forms.Label lblIssueType;
        private System.Windows.Forms.Label lblIssueSummary;
        private System.Windows.Forms.Label lblIssueComments;

       
    }
}