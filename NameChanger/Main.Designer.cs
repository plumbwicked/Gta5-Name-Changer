namespace NameChanger
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblCurrentName = new System.Windows.Forms.Label();
            this.txtCurrentName = new System.Windows.Forms.TextBox();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.lblNewName = new System.Windows.Forms.Label();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.lblGitHub = new System.Windows.Forms.LinkLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblCurrentName
            // 
            resources.ApplyResources(this.lblCurrentName, "lblCurrentName");
            this.lblCurrentName.Name = "lblCurrentName";
            // 
            // txtCurrentName
            // 
            resources.ApplyResources(this.txtCurrentName, "txtCurrentName");
            this.txtCurrentName.Name = "txtCurrentName";
            this.txtCurrentName.TextChanged += new System.EventHandler(this.txtCurrentName_TextChanged);
            // 
            // txtNewName
            // 
            resources.ApplyResources(this.txtNewName, "txtNewName");
            this.txtNewName.Name = "txtNewName";
            // 
            // lblNewName
            // 
            resources.ApplyResources(this.lblNewName, "lblNewName");
            this.lblNewName.Name = "lblNewName";
            // 
            // btnChangeName
            // 
            resources.ApplyResources(this.btnChangeName, "btnChangeName");
            this.btnChangeName.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnChangeName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.UseVisualStyleBackColor = true;
            this.btnChangeName.Click += new System.EventHandler(this.BtnChangeName_Click);
            // 
            // lblGitHub
            // 
            this.lblGitHub.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblGitHub.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblGitHub, "lblGitHub");
            this.lblGitHub.LinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblGitHub.Name = "lblGitHub";
            this.lblGitHub.TabStop = true;
            this.lblGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblGitHub_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Main
            // 
            this.AcceptButton = this.btnChangeName;
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblGitHub);
            this.Controls.Add(this.btnChangeName);
            this.Controls.Add(this.txtNewName);
            this.Controls.Add(this.lblNewName);
            this.Controls.Add(this.txtCurrentName);
            this.Controls.Add(this.lblCurrentName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentName;
        private System.Windows.Forms.TextBox txtCurrentName;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.Label lblNewName;
        private System.Windows.Forms.Button btnChangeName;
        private System.Windows.Forms.LinkLabel lblGitHub;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

