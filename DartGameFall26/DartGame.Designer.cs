namespace DartGameFall26
{
    partial class DartGame
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
            components = new System.ComponentModel.Container();
            ExitButton = new Button();
            DartBoardPictureBox = new PictureBox();
            ReviewButton = new Button();
            StartRoundButton = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            RoundsListBox = new ListBox();
            MainToolTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)DartBoardPictureBox).BeginInit();
            SuspendLayout();
            // 
            // ExitButton
            // 
            ExitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ExitButton.Location = new Point(556, 520);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(163, 58);
            ExitButton.TabIndex = 0;
            ExitButton.Text = "E&xit";
            MainToolTip.SetToolTip(ExitButton, "Quit the game");
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // DartBoardPictureBox
            // 
            DartBoardPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DartBoardPictureBox.BackgroundImage = Properties.Resources.minecraft_end_portal_dartboard;
            DartBoardPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            DartBoardPictureBox.Location = new Point(12, 12);
            DartBoardPictureBox.Name = "DartBoardPictureBox";
            DartBoardPictureBox.Size = new Size(514, 490);
            DartBoardPictureBox.TabIndex = 1;
            DartBoardPictureBox.TabStop = false;
            MainToolTip.SetToolTip(DartBoardPictureBox, "Press Space to throw a dart");
            // 
            // ReviewButton
            // 
            ReviewButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ReviewButton.Location = new Point(556, 456);
            ReviewButton.Name = "ReviewButton";
            ReviewButton.Size = new Size(163, 58);
            ReviewButton.TabIndex = 2;
            ReviewButton.Text = "&Review Game ";
            MainToolTip.SetToolTip(ReviewButton, "Review previously logged rounds");
            ReviewButton.UseVisualStyleBackColor = true;
            ReviewButton.Click += ReviewButton_Click;
            // 
            // StartRoundButton
            // 
            StartRoundButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            StartRoundButton.Location = new Point(556, 392);
            StartRoundButton.Name = "StartRoundButton";
            StartRoundButton.Size = new Size(163, 58);
            StartRoundButton.TabIndex = 3;
            StartRoundButton.Text = "&Start Round";
            MainToolTip.SetToolTip(StartRoundButton, "Start a new round of 3 darts");
            StartRoundButton.UseVisualStyleBackColor = true;
            StartRoundButton.Click += StartRoundButton_Click;
            // 
            // RoundsListBox
            // 
            RoundsListBox.FormattingEnabled = true;
            RoundsListBox.Location = new Point(539, 12);
            RoundsListBox.Name = "RoundsListBox";
            RoundsListBox.Size = new Size(180, 154);
            RoundsListBox.TabIndex = 4;
            MainToolTip.SetToolTip(RoundsListBox, "Pick a round to see its darts");
            RoundsListBox.SelectedIndexChanged += RoundsListBox_SelectedIndexChanged;
            // 
            // DartGame
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 590);
            Controls.Add(RoundsListBox);
            Controls.Add(StartRoundButton);
            Controls.Add(ReviewButton);
            Controls.Add(DartBoardPictureBox);
            Controls.Add(ExitButton);
            Name = "DartGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dart Game";
            ((System.ComponentModel.ISupportInitialize)DartBoardPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button ExitButton;
        private PictureBox DartBoardPictureBox;
        private Button ReviewButton;
        private Button StartRoundButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ListBox RoundsListBox;
        private ToolTip MainToolTip;
    }
}
