namespace JarrettVance.Updater
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.linkInfo = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picDownload = new System.Windows.Forms.PictureBox();
            this.picZip = new System.Windows.Forms.PictureBox();
            this.picCleanup = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCleanup)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInfo.Location = new System.Drawing.Point(37, 42);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(428, 18);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "to version {1} from {2}";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(27, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 24);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Updating {0}";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(31, 74);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(434, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // linkInfo
            // 
            this.linkInfo.AutoSize = true;
            this.linkInfo.Location = new System.Drawing.Point(413, 118);
            this.linkInfo.Name = "linkInfo";
            this.linkInfo.Size = new System.Drawing.Size(52, 13);
            this.linkInfo.TabIndex = 5;
            this.linkInfo.TabStop = true;
            this.linkInfo.Text = "More Info";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(433, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // picDownload
            // 
            this.picDownload.Enabled = false;
            this.picDownload.Image = ((System.Drawing.Image)(resources.GetObject("picDownload.Image")));
            this.picDownload.Location = new System.Drawing.Point(31, 107);
            this.picDownload.Name = "picDownload";
            this.picDownload.Size = new System.Drawing.Size(24, 24);
            this.picDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picDownload.TabIndex = 8;
            this.picDownload.TabStop = false;
            // 
            // picZip
            // 
            this.picZip.Enabled = false;
            this.picZip.Image = ((System.Drawing.Image)(resources.GetObject("picZip.Image")));
            this.picZip.Location = new System.Drawing.Point(31, 107);
            this.picZip.Name = "picZip";
            this.picZip.Size = new System.Drawing.Size(24, 24);
            this.picZip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picZip.TabIndex = 9;
            this.picZip.TabStop = false;
            this.picZip.Visible = false;
            // 
            // picCleanup
            // 
            this.picCleanup.Enabled = false;
            this.picCleanup.Image = ((System.Drawing.Image)(resources.GetObject("picCleanup.Image")));
            this.picCleanup.Location = new System.Drawing.Point(31, 107);
            this.picCleanup.Name = "picCleanup";
            this.picCleanup.Size = new System.Drawing.Size(24, 24);
            this.picCleanup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picCleanup.TabIndex = 10;
            this.picCleanup.TabStop = false;
            this.picCleanup.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblStatus.Location = new System.Drawing.Point(57, 108);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(346, 23);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Reading manifest…";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 154);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.picCleanup);
            this.Controls.Add(this.picZip);
            this.Controls.Add(this.picDownload);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.linkInfo);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Updater";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCleanup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.LinkLabel linkInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picDownload;
        private System.Windows.Forms.PictureBox picZip;
        private System.Windows.Forms.PictureBox picCleanup;
        private System.Windows.Forms.Label lblStatus;
    }
}

