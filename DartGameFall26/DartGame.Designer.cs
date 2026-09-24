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
            ExitButton = new Button();
            DrawPictureBox = new PictureBox();
            ThrowDartButton = new Button();
            DrawSpiralButton = new Button();
            ((System.ComponentModel.ISupportInitialize)DrawPictureBox).BeginInit();
            SuspendLayout();
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(556, 520);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(163, 58);
            ExitButton.TabIndex = 0;
            ExitButton.Text = "E&xit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // DrawPictureBox
            // 
            DrawPictureBox.Location = new Point(36, 24);
            DrawPictureBox.Name = "DrawPictureBox";
            DrawPictureBox.Size = new Size(683, 490);
            DrawPictureBox.TabIndex = 1;
            DrawPictureBox.TabStop = false;
            // 
            // ThrowDartButton
            // 
            ThrowDartButton.Location = new Point(387, 520);
            ThrowDartButton.Name = "ThrowDartButton";
            ThrowDartButton.Size = new Size(163, 58);
            ThrowDartButton.TabIndex = 2;
            ThrowDartButton.Text = "Throw &Dart";
            ThrowDartButton.UseVisualStyleBackColor = true;
            ThrowDartButton.Click += ThrowDartButton_Click;
            // 
            // DrawSpiralButton
            // 
            DrawSpiralButton.Location = new Point(218, 520);
            DrawSpiralButton.Name = "DrawSpiralButton";
            DrawSpiralButton.Size = new Size(163, 58);
            DrawSpiralButton.TabIndex = 3;
            DrawSpiralButton.Text = "Draw &Spiral";
            DrawSpiralButton.UseVisualStyleBackColor = true;
            DrawSpiralButton.Click += DrawSpiralButton_Click;
            // 
            // DartGame
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 590);
            Controls.Add(DrawSpiralButton);
            Controls.Add(ThrowDartButton);
            Controls.Add(DrawPictureBox);
            Controls.Add(ExitButton);
            Name = "DartGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dart Game";
            ((System.ComponentModel.ISupportInitialize)DrawPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button ExitButton;
        private PictureBox DrawPictureBox;
        private Button ThrowDartButton;
        private Button DrawSpiralButton;
    }
}
