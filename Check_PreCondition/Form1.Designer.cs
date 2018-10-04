namespace Check_PreCondition_v2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtbx_usrname = new System.Windows.Forms.TextBox();
            this.txtbx_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkbx_rememberMe = new System.Windows.Forms.CheckBox();
            this.chkbx_TogglePassword = new System.Windows.Forms.CheckBox();
            this.rtb_Console = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbx_TesRunID = new System.Windows.Forms.TextBox();
            this.btn_validate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // txtbx_usrname
            // 
            this.txtbx_usrname.Location = new System.Drawing.Point(109, 16);
            this.txtbx_usrname.Name = "txtbx_usrname";
            this.txtbx_usrname.Size = new System.Drawing.Size(243, 20);
            this.txtbx_usrname.TabIndex = 0;
            // 
            // txtbx_password
            // 
            this.txtbx_password.Location = new System.Drawing.Point(109, 64);
            this.txtbx_password.Name = "txtbx_password";
            this.txtbx_password.Size = new System.Drawing.Size(243, 20);
            this.txtbx_password.TabIndex = 1;
            this.txtbx_password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // chkbx_rememberMe
            // 
            this.chkbx_rememberMe.AutoSize = true;
            this.chkbx_rememberMe.Location = new System.Drawing.Point(36, 108);
            this.chkbx_rememberMe.Name = "chkbx_rememberMe";
            this.chkbx_rememberMe.Size = new System.Drawing.Size(92, 17);
            this.chkbx_rememberMe.TabIndex = 4;
            this.chkbx_rememberMe.Text = "RememberMe";
            this.chkbx_rememberMe.UseVisualStyleBackColor = true;
            // 
            // chkbx_TogglePassword
            // 
            this.chkbx_TogglePassword.AutoSize = true;
            this.chkbx_TogglePassword.Location = new System.Drawing.Point(305, 108);
            this.chkbx_TogglePassword.Name = "chkbx_TogglePassword";
            this.chkbx_TogglePassword.Size = new System.Drawing.Size(102, 17);
            this.chkbx_TogglePassword.TabIndex = 5;
            this.chkbx_TogglePassword.Text = "Show Password";
            this.chkbx_TogglePassword.UseVisualStyleBackColor = true;
            this.chkbx_TogglePassword.CheckedChanged += new System.EventHandler(this.chkbx_TogglePassword_CheckedChanged);
            // 
            // rtb_Console
            // 
            this.rtb_Console.Location = new System.Drawing.Point(34, 246);
            this.rtb_Console.Name = "rtb_Console";
            this.rtb_Console.Size = new System.Drawing.Size(479, 155);
            this.rtb_Console.TabIndex = 6;
            this.rtb_Console.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Test Plan ID:";
            // 
            // txtbx_TesRunID
            // 
            this.txtbx_TesRunID.Location = new System.Drawing.Point(109, 163);
            this.txtbx_TesRunID.Name = "txtbx_TesRunID";
            this.txtbx_TesRunID.Size = new System.Drawing.Size(195, 20);
            this.txtbx_TesRunID.TabIndex = 8;
            // 
            // btn_validate
            // 
            this.btn_validate.Location = new System.Drawing.Point(320, 158);
            this.btn_validate.Name = "btn_validate";
            this.btn_validate.Size = new System.Drawing.Size(207, 29);
            this.btn_validate.TabIndex = 9;
            this.btn_validate.Text = "Identify Missing Pre-Conditions in Plan";
            this.btn_validate.UseVisualStyleBackColor = true;
            this.btn_validate.Click += new System.EventHandler(this.btn_validate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Console Logs:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(545, 433);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_validate);
            this.Controls.Add(this.txtbx_TesRunID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtb_Console);
            this.Controls.Add(this.chkbx_TogglePassword);
            this.Controls.Add(this.chkbx_rememberMe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbx_password);
            this.Controls.Add(this.txtbx_usrname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Check Precondition-v4.1.0";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbx_usrname;
        private System.Windows.Forms.TextBox txtbx_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkbx_rememberMe;
        private System.Windows.Forms.CheckBox chkbx_TogglePassword;
        private System.Windows.Forms.RichTextBox rtb_Console;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbx_TesRunID;
        private System.Windows.Forms.Button btn_validate;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

