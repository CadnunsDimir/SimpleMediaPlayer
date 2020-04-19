namespace SimpleMediaPlayer
{
    partial class HomeScreen
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
            this.button1 = new System.Windows.Forms.Button();
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.playBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.filePlayingNameLbl = new System.Windows.Forms.Label();
            this.timeInfoLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "selecionar arquivos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // filesListBox
            // 
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.Location = new System.Drawing.Point(13, 13);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.Size = new System.Drawing.Size(320, 160);
            this.filesListBox.TabIndex = 1;
            this.filesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FilesListBox_MouseDoubleClick);
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(13, 219);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(90, 45);
            this.playBtn.TabIndex = 2;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Location = new System.Drawing.Point(189, 219);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(90, 45);
            this.pauseBtn.TabIndex = 3;
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(339, 219);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(90, 45);
            this.stopBtn.TabIndex = 4;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Now Playing:";
            // 
            // filePlayingNameLbl
            // 
            this.filePlayingNameLbl.AutoSize = true;
            this.filePlayingNameLbl.Location = new System.Drawing.Point(88, 180);
            this.filePlayingNameLbl.Name = "filePlayingNameLbl";
            this.filePlayingNameLbl.Size = new System.Drawing.Size(0, 13);
            this.filePlayingNameLbl.TabIndex = 6;
            // 
            // timeInfoLbl
            // 
            this.timeInfoLbl.AutoSize = true;
            this.timeInfoLbl.Location = new System.Drawing.Point(16, 200);
            this.timeInfoLbl.Name = "timeInfoLbl";
            this.timeInfoLbl.Size = new System.Drawing.Size(72, 13);
            this.timeInfoLbl.TabIndex = 7;
            this.timeInfoLbl.Text = "00:00 / 00:00";
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 288);
            this.Controls.Add(this.timeInfoLbl);
            this.Controls.Add(this.filePlayingNameLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.filesListBox);
            this.Controls.Add(this.button1);
            this.Name = "HomeScreen";
            this.Text = "Simple Media Player (for JW Meeting)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox filesListBox;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label filePlayingNameLbl;
        private System.Windows.Forms.Label timeInfoLbl;
    }
}

