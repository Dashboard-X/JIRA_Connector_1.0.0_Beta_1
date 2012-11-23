namespace JIRAConnector.UI.Dialogs
{
    partial class LogWorkDoneDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblOriginalEstimate = new System.Windows.Forms.Label();
            this.lblRemainingEstimate = new System.Windows.Forms.Label();
            this.lblTimeSpent = new System.Windows.Forms.Label();
            this.lblWorkDescription = new System.Windows.Forms.Label();
            this.txtWorkDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time Spent";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(123, 258);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(212, 258);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(234, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(197, 34);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "The format of this is \' *w *d *h *m \' (representing weeks, days, hours and minute" +
                "s - where * can be any number).  Examples: 4d, 5h 30m, 60m and 3w. ";
            // 
            // lblOriginalEstimate
            // 
            this.lblOriginalEstimate.AutoSize = true;
            this.lblOriginalEstimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginalEstimate.Location = new System.Drawing.Point(8, 166);
            this.lblOriginalEstimate.Name = "lblOriginalEstimate";
            this.lblOriginalEstimate.Size = new System.Drawing.Size(110, 13);
            this.lblOriginalEstimate.TabIndex = 5;
            this.lblOriginalEstimate.Text = "Original Estimate: ";
            // 
            // lblRemainingEstimate
            // 
            this.lblRemainingEstimate.AutoSize = true;
            this.lblRemainingEstimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingEstimate.Location = new System.Drawing.Point(8, 191);
            this.lblRemainingEstimate.Name = "lblRemainingEstimate";
            this.lblRemainingEstimate.Size = new System.Drawing.Size(126, 13);
            this.lblRemainingEstimate.TabIndex = 6;
            this.lblRemainingEstimate.Text = "Remaining Estimate: ";
            // 
            // lblTimeSpent
            // 
            this.lblTimeSpent.AutoSize = true;
            this.lblTimeSpent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeSpent.Location = new System.Drawing.Point(8, 217);
            this.lblTimeSpent.Name = "lblTimeSpent";
            this.lblTimeSpent.Size = new System.Drawing.Size(79, 13);
            this.lblTimeSpent.TabIndex = 7;
            this.lblTimeSpent.Text = "Time Spent: ";
            // 
            // lblWorkDescription
            // 
            this.lblWorkDescription.AutoSize = true;
            this.lblWorkDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkDescription.Location = new System.Drawing.Point(8, 62);
            this.lblWorkDescription.Name = "lblWorkDescription";
            this.lblWorkDescription.Size = new System.Drawing.Size(105, 13);
            this.lblWorkDescription.TabIndex = 8;
            this.lblWorkDescription.Text = "Work Description";
            // 
            // txtWorkDescription
            // 
            this.txtWorkDescription.Location = new System.Drawing.Point(123, 59);
            this.txtWorkDescription.Multiline = true;
            this.txtWorkDescription.Name = "txtWorkDescription";
            this.txtWorkDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWorkDescription.Size = new System.Drawing.Size(303, 89);
            this.txtWorkDescription.TabIndex = 9;
            // 
            // LogWorkDoneDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(438, 293);
            this.Controls.Add(this.txtWorkDescription);
            this.Controls.Add(this.lblWorkDescription);
            this.Controls.Add(this.lblTimeSpent);
            this.Controls.Add(this.lblRemainingEstimate);
            this.Controls.Add(this.lblOriginalEstimate);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogWorkDoneDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log Work for TODAY";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblOriginalEstimate;
        private System.Windows.Forms.Label lblRemainingEstimate;
        private System.Windows.Forms.Label lblTimeSpent;
        private System.Windows.Forms.Label lblWorkDescription;
        private System.Windows.Forms.TextBox txtWorkDescription;
    }
}