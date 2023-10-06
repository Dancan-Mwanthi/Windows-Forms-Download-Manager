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
            txt_Url.Text = "https://www.youtube.com/watch?v=fkFNQtWZQzo&ab_channel=OzzyManReviews";
            // 
            // lbl_Status
            // 
            lbl_Status.AutoSize = true;
            lbl_Status.Location = new Point(32, 97);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(45, 15);
            lbl_Status.TabIndex = 2;
            lbl_Status.Text = "Status :";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(76, 115);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(450, 23);
            progressBar.TabIndex = 4;
            // 
            // val_progressPercentage
            // 
            val_progressPercentage.AutoSize = true;
            val_progressPercentage.Location = new Point(503, 97);
            val_progressPercentage.Name = "val_progressPercentage";
            val_progressPercentage.Size = new Size(23, 15);
            val_progressPercentage.TabIndex = 5;
            val_progressPercentage.Text = "0%";
            // 
            // btn_Start
            // 
            btn_Start.Location = new Point(364, 157);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new Size(75, 23);
            btn_Start.TabIndex = 6;
            btn_Start.Text = "&Start";
            btn_Start.UseVisualStyleBackColor = true;
            btn_Start.Click += btn_Start_Click;
            // 
            // btn_Pause
            // 
            btn_Pause.Location = new Point(451, 157);
            btn_Pause.Name = "btn_Pause";
            btn_Pause.Size = new Size(75, 23);
            btn_Pause.TabIndex = 7;
            btn_Pause.Text = "&Pause";
            btn_Pause.UseVisualStyleBackColor = true;
            btn_Pause.Click += btn_Pause_Click;
            // 
            // val_downloaded
            // 
            val_downloaded.AutoSize = true;
            val_downloaded.Location = new Point(76, 97);
            val_downloaded.Name = "val_downloaded";
            val_downloaded.Size = new Size(34, 15);
            val_downloaded.TabIndex = 11;
            val_downloaded.Text = "0 MB";
            // 
            // val_downloadLabel
            // 
            val_downloadLabel.AutoSize = true;
            val_downloadLabel.Location = new Point(76, 71);
            val_downloadLabel.Name = "val_downloadLabel";
            val_downloadLabel.Size = new Size(0, 15);
            val_downloadLabel.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 201);
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
            Name = "Form1";
            Text = "Form1";
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