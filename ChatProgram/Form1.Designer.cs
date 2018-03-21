namespace ChatProgram
{
    partial class Form1
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
            this.TxtField = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.LogTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TxtField
            // 
            this.TxtField.BackColor = System.Drawing.Color.Silver;
            this.TxtField.Location = new System.Drawing.Point(16, 379);
            this.TxtField.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtField.Name = "TxtField";
            this.TxtField.Size = new System.Drawing.Size(468, 22);
            this.TxtField.TabIndex = 0;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(493, 379);
            this.sendButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(120, 25);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // LogTxt
            // 
            this.LogTxt.Location = new System.Drawing.Point(16, 15);
            this.LogTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LogTxt.Multiline = true;
            this.LogTxt.Name = "LogTxt";
            this.LogTxt.ReadOnly = true;
            this.LogTxt.Size = new System.Drawing.Size(596, 356);
            this.LogTxt.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 418);
            this.Controls.Add(this.LogTxt);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.TxtField);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Chat client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtField;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox LogTxt;
    }
}

