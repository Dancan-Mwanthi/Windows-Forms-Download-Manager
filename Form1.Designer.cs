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
            val_Status = new Label();
            progressBar = new ProgressBar();
            val_progressPercentage = new Label();
            btn_Start = new Button();
            btn_Pause = new Button();
            btn_Resume = new Button();
            lbl_downloaded = new Label();
            lbl_Speed = new Label();
            val_downloaded = new Label();
            val_speed = new Label();
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
            txt_Url.Location = new Point(110, 28);
            txt_Url.Name = "txt_Url";
            txt_Url.Size = new Size(454, 23);
            txt_Url.TabIndex = 1;
            // 
            // lbl_Status
            // 
            lbl_Status.AutoSize = true;
            lbl_Status.Location = new Point(28, 72);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(45, 15);
            lbl_Status.TabIndex = 2;
            lbl_Status.Text = "Status :";
            // 
            // val_Status
            // 
            val_Status.AutoSize = true;
            val_Status.Location = new Point(110, 72);
            val_Status.Name = "val_Status";
            val_Status.Size = new Size(22, 15);
            val_Status.TabIndex = 3;
            val_Status.Text = "???";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(114, 118);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(450, 23);
            progressBar.TabIndex = 4;
            // 
            // val_progressPercentage
            // 
            val_progressPercentage.AutoSize = true;
            val_progressPercentage.Location = new Point(541, 100);
            val_progressPercentage.Name = "val_progressPercentage";
            val_progressPercentage.Size = new Size(23, 15);
            val_progressPercentage.TabIndex = 5;
            val_progressPercentage.Text = "0%";
            // 
            // btn_Start
            // 
            btn_Start.Location = new Point(310, 165);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new Size(75, 23);
            btn_Start.TabIndex = 6;
            btn_Start.Text = "&Start";
            btn_Start.UseVisualStyleBackColor = true;
            btn_Start.Click += btn_Start_Click;
            // 
            // btn_Pause
            // 
            btn_Pause.Location = new Point(397, 165);
            btn_Pause.Name = "btn_Pause";
            btn_Pause.Size = new Size(75, 23);
            btn_Pause.TabIndex = 7;
            btn_Pause.Text = "&Pause";
            btn_Pause.UseVisualStyleBackColor = true;
            btn_Pause.Click += btn_Pause_Click;
            // 
            // btn_Resume
            // 
            btn_Resume.Location = new Point(489, 165);
            btn_Resume.Name = "btn_Resume";
            btn_Resume.Size = new Size(75, 23);
            btn_Resume.TabIndex = 8;
            btn_Resume.Text = "&Resume";
            btn_Resume.UseVisualStyleBackColor = true;
            btn_Resume.Click += btn_Resume_Click;
            // 
            // lbl_downloaded
            // 
            lbl_downloaded.AutoSize = true;
            lbl_downloaded.Location = new Point(28, 205);
            lbl_downloaded.Name = "lbl_downloaded";
            lbl_downloaded.Size = new Size(77, 15);
            lbl_downloaded.TabIndex = 9;
            lbl_downloaded.Text = "Downloaded:";
            // 
            // lbl_Speed
            // 
            lbl_Speed.AutoSize = true;
            lbl_Speed.Location = new Point(63, 236);
            lbl_Speed.Name = "lbl_Speed";
            lbl_Speed.Size = new Size(42, 15);
            lbl_Speed.TabIndex = 10;
            lbl_Speed.Text = "Speed:";
            // 
            // val_downloaded
            // 
            val_downloaded.AutoSize = true;
            val_downloaded.Location = new Point(114, 205);
            val_downloaded.Name = "val_downloaded";
            val_downloaded.Size = new Size(34, 15);
            val_downloaded.TabIndex = 11;
            val_downloaded.Text = "0 MB";
            // 
            // val_speed
            // 
            val_speed.AutoSize = true;
            val_speed.Location = new Point(114, 236);
            val_speed.Name = "val_speed";
            val_speed.Size = new Size(44, 15);
            val_speed.TabIndex = 12;
            val_speed.Text = "0 MB/s";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 289);
            Controls.Add(val_speed);
            Controls.Add(val_downloaded);
            Controls.Add(lbl_Speed);
            Controls.Add(lbl_downloaded);
            Controls.Add(btn_Resume);
            Controls.Add(btn_Pause);
            Controls.Add(btn_Start);
            Controls.Add(val_progressPercentage);
            Controls.Add(progressBar);
            Controls.Add(val_Status);
            Controls.Add(lbl_Status);
            Controls.Add(txt_Url);
            Controls.Add(lbl_Url);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();

            txt_Url.Text = "https://www.youtube.com/watch?v=fkFNQtWZQzo&ab_channel=OzzyManReviews";
        }

        #endregion

        private Label lbl_Url;
        private TextBox txt_Url;
        private Label lbl_Status;
        private Label val_Status;
        private ProgressBar progressBar;
        private Label val_progressPercentage;
        private Button btn_Start;
        private Button btn_Pause;
        private Button btn_Resume;
        private Label lbl_downloaded;
        private Label lbl_Speed;
        private Label val_downloaded;
        private Label val_speed;
    }
}