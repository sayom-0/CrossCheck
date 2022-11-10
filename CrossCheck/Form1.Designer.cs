
namespace CrossCheck
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.BrowseFilesButton = new System.Windows.Forms.Button();
            this.FilePathText = new System.Windows.Forms.TextBox();
            this.ResultsBox = new System.Windows.Forms.RichTextBox();
            this.CheckButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BrowseFilesButton
            // 
            this.BrowseFilesButton.Location = new System.Drawing.Point(12, 12);
            this.BrowseFilesButton.Name = "BrowseFilesButton";
            this.BrowseFilesButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseFilesButton.TabIndex = 0;
            this.BrowseFilesButton.Text = "Browse";
            this.BrowseFilesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BrowseFilesButton.UseVisualStyleBackColor = true;
            this.BrowseFilesButton.Click += new System.EventHandler(this.BrowseFilesButton_Click);
            // 
            // FilePathText
            // 
            this.FilePathText.Location = new System.Drawing.Point(93, 12);
            this.FilePathText.Name = "FilePathText";
            this.FilePathText.ReadOnly = true;
            this.FilePathText.Size = new System.Drawing.Size(302, 23);
            this.FilePathText.TabIndex = 1;
            // 
            // ResultsBox
            // 
            this.ResultsBox.Location = new System.Drawing.Point(12, 41);
            this.ResultsBox.Name = "ResultsBox";
            this.ResultsBox.ReadOnly = true;
            this.ResultsBox.Size = new System.Drawing.Size(383, 291);
            this.ResultsBox.TabIndex = 2;
            this.ResultsBox.Text = "";
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(167, 338);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(75, 23);
            this.CheckButton.TabIndex = 3;
            this.CheckButton.Text = "Check";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 371);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.ResultsBox);
            this.Controls.Add(this.FilePathText);
            this.Controls.Add(this.BrowseFilesButton);
            this.Name = "Form1";
            this.Text = "Inventory Cross Checker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button BrowseFilesButton;
        private System.Windows.Forms.TextBox FilePathText;
        private System.Windows.Forms.RichTextBox ResultsBox;
        private System.Windows.Forms.Button CheckButton;
    }
}

