namespace mysqltomongo
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
            this.db_entry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passwd_entry = new System.Windows.Forms.TextBox();
            this.username_entry = new System.Windows.Forms.TextBox();
            this.hostname_entry = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // db_entry
            // 
            this.db_entry.Location = new System.Drawing.Point(152, 46);
            this.db_entry.Name = "db_entry";
            this.db_entry.Size = new System.Drawing.Size(100, 22);
            this.db_entry.TabIndex = 0;
            this.db_entry.Text = "mothrecs";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "MySql Database:";
            // 
            // passwd_entry
            // 
            this.passwd_entry.Location = new System.Drawing.Point(152, 116);
            this.passwd_entry.Name = "passwd_entry";
            this.passwd_entry.Size = new System.Drawing.Size(100, 22);
            this.passwd_entry.TabIndex = 2;
            this.passwd_entry.UseSystemPasswordChar = true;
            // 
            // username_entry
            // 
            this.username_entry.Location = new System.Drawing.Point(152, 81);
            this.username_entry.Name = "username_entry";
            this.username_entry.Size = new System.Drawing.Size(100, 22);
            this.username_entry.TabIndex = 3;
            this.username_entry.Text = "martin";
            // 
            // hostname_entry
            // 
            this.hostname_entry.Location = new System.Drawing.Point(152, 18);
            this.hostname_entry.Name = "hostname_entry";
            this.hostname_entry.Size = new System.Drawing.Size(100, 22);
            this.hostname_entry.TabIndex = 4;
            this.hostname_entry.Text = "localhost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hostname:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 315);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hostname_entry);
            this.Controls.Add(this.username_entry);
            this.Controls.Add(this.passwd_entry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.db_entry);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox db_entry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwd_entry;
        private System.Windows.Forms.TextBox username_entry;
        private System.Windows.Forms.TextBox hostname_entry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

