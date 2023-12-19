namespace wf_DownloadManager
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
            lbl_Url = new Label();
            txt_Url = new TextBox();
            lbl_Status = new Label();
            progressBar = new ProgressBar();
            val_progressPercentage = new Label();
            btn_Start = new Button();
            btn_Pause = new Button();
            val_downloaded = new Label();
            val_downloadLabel = new Label();
            SuspendLayout();
            // 
            // lbl_Url
            // 
            lbl_Url.AutoSize = true;
            lbl_Url.Location = new Point(28, 31);
            lbl_Url.Name = "lbl_Url";
            lbl_Url.Size = new Size(28, 15);
            lbl_Url.TabIndex = 0;
            lbl_Url.Text = "Url :";
            // 
            // txt_Url
            // 
            txt_Url.Location = new Point(72, 28);
            txt_Url.Name = "txt_Url";
            txt_Url.Size = new Size(454, 23);
            txt_Url.TabIndex = 1;
            txt_Url.Text = "https://www.youtube.com/watch?v=v_XsmqA_YTk";
            // 
            // lbl_Status
            // 
            lbl_Status.AccessibleDescription = "cntrlsDownload";
            lbl_Status.AccessibleName = "cntrlsDownload";
            lbl_Status.AutoSize = true;
            lbl_Status.Location = new Point(19, 51);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(45, 15);
            lbl_Status.TabIndex = 2;
            lbl_Status.Tag = "cntrlsDownload";
            lbl_Status.Text = "Status :";
            lbl_Status.Visible = false;
            // 
            // progressBar
            // 
            progressBar.AccessibleDescription = "cntrlsDownload";
            progressBar.AccessibleName = "cntrlsDownload";
            progressBar.Location = new Point(63, 69);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(450, 23);
            progressBar.TabIndex = 4;
            progressBar.Tag = "cntrlsDownload";
            progressBar.Visible = false;
            // 
            // val_progressPercentage
            // 
            val_progressPercentage.AccessibleDescription = "cntrlsDownload";
            val_progressPercentage.AccessibleName = "cntrlsDownload";
            val_progressPercentage.AutoSize = true;
            val_progressPercentage.Location = new Point(490, 51);
            val_progressPercentage.Name = "val_progressPercentage";
            val_progressPercentage.Size = new Size(23, 15);
            val_progressPercentage.TabIndex = 5;
            val_progressPercentage.Tag = "cntrlsDownload";
            val_progressPercentage.Text = "0%";
            val_progressPercentage.Visible = false;
            // 
            // btn_Start
            // 
            btn_Start.Location = new Point(532, 28);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new Size(75, 23);
            btn_Start.TabIndex = 6;
            btn_Start.Text = "&Start";
            btn_Start.UseVisualStyleBackColor = true;
            btn_Start.Click += btn_Start_Click;
            // 
            // btn_Pause
            // 
            btn_Pause.AccessibleDescription = "cntrlsDownload";
            btn_Pause.AccessibleName = "cntrlsDownload";
            btn_Pause.Location = new Point(519, 69);
            btn_Pause.Name = "btn_Pause";
            btn_Pause.Size = new Size(75, 23);
            btn_Pause.TabIndex = 7;
            btn_Pause.Tag = "cntrlsDownload";
            btn_Pause.Text = "&Pause";
            btn_Pause.UseVisualStyleBackColor = true;
            btn_Pause.Visible = false;
            //btn_Pause.Click += btn_Pause_Click;
            // 
            // val_downloaded
            // 
            val_downloaded.AccessibleDescription = "cntrlsDownload";
            val_downloaded.AccessibleName = "cntrlsDownload";
            val_downloaded.AutoSize = true;
            val_downloaded.Location = new Point(63, 51);
            val_downloaded.Name = "val_downloaded";
            val_downloaded.Size = new Size(34, 15);
            val_downloaded.TabIndex = 11;
            val_downloaded.Tag = "cntrlsDownload";
            val_downloaded.Text = "0 MB";
            val_downloaded.Visible = false;
            // 
            // val_downloadLabel
            // 
            val_downloadLabel.AutoSize = true;
            val_downloadLabel.Location = new Point(63, 25);
            val_downloadLabel.Name = "val_downloadLabel";
            val_downloadLabel.Size = new Size(0, 15);
            val_downloadLabel.TabIndex = 12;
            val_downloadLabel.Tag = "cntrlsDownload";
            val_downloadLabel.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(641, 100);
            Controls.Add(val_downloadLabel);
            Controls.Add(val_downloaded);
            Controls.Add(btn_Pause);
            Controls.Add(btn_Start);
            Controls.Add(val_progressPercentage);
            Controls.Add(progressBar);
            Controls.Add(lbl_Status);
            Controls.Add(txt_Url);
            Controls.Add(lbl_Url);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "wfDownloadManager";
            Opacity = 0.95D;
            Text = "Download Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Url;
        private TextBox txt_Url;
        private Label lbl_Status;
        private ProgressBar progressBar;
        private Label val_progressPercentage;
        private Button btn_Start;
        private Button btn_Pause;
        private Label val_downloaded;
        private Label val_downloadLabel;
    }
}