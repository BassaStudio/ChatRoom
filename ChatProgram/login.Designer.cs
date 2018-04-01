namespace ChatProgram
{
    partial class login
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
            this.signbut = new System.Windows.Forms.Button();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iptxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.porttxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // signbut
            // 
            this.signbut.Location = new System.Drawing.Point(67, 81);
            this.signbut.Name = "signbut";
            this.signbut.Size = new System.Drawing.Size(75, 23);
            this.signbut.TabIndex = 3;
            this.signbut.Text = "Sign in";
            this.signbut.UseVisualStyleBackColor = true;
            this.signbut.Click += new System.EventHandler(this.button1_Click);
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(45, 3);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(153, 20);
            this.nametxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // iptxt
            // 
            this.iptxt.Location = new System.Drawing.Point(45, 29);
            this.iptxt.Name = "iptxt";
            this.iptxt.Size = new System.Drawing.Size(153, 20);
            this.iptxt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ip:";
            // 
            // porttxt
            // 
            this.porttxt.Location = new System.Drawing.Point(45, 55);
            this.porttxt.Name = "porttxt";
            this.porttxt.Size = new System.Drawing.Size(153, 20);
            this.porttxt.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 113);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.porttxt);
            this.Controls.Add(this.iptxt);
            this.Controls.Add(this.nametxt);
            this.Controls.Add(this.signbut);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button signbut;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox iptxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox porttxt;
        private System.Windows.Forms.Label label3;
    }
}

