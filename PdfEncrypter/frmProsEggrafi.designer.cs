namespace PdfEncrypter
{
    partial class frmProsEggrafi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProsEggrafi));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegisterAutomatic = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnTrial = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblcaption = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnRegisterAutomatic);
            this.groupBox1.Controls.Add(this.picLogo);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnTrial);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.lblcaption);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnRegisterAutomatic
            // 
            resources.ApplyResources(this.btnRegisterAutomatic, "btnRegisterAutomatic");
            this.btnRegisterAutomatic.Name = "btnRegisterAutomatic";
            this.btnRegisterAutomatic.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.White;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.picLogo, "picLogo");
            this.picLogo.Name = "picLogo";
            this.picLogo.TabStop = false;
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTrial
            // 
            resources.ApplyResources(this.btnTrial, "btnTrial");
            this.btnTrial.Image = global::PdfEncrypter.Properties.Resources.arrow_right_blue;
            this.btnTrial.Name = "btnTrial";
            this.btnTrial.Click += new System.EventHandler(this.btnTrial_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblcaption
            // 
            this.lblcaption.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblcaption, "lblcaption");
            this.lblcaption.Name = "lblcaption";
            // 
            // frmProsEggrafi
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProsEggrafi";
            this.ShowInTaskbar = true;
            this.Load += new System.EventHandler(this.frmProsEggrafi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnTrial;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblcaption;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnRegisterAutomatic;
        private System.Windows.Forms.Label label1;
    }
}