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
            ((System.ComponentModel.ISupportInitialize)DrawPictureBox).BeginInit();
            SuspendLayout();
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(625, 380);
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
            DrawPictureBox.Size = new Size(736, 340);
            DrawPictureBox.TabIndex = 1;
            DrawPictureBox.TabStop = false;
            // 
            // ThrowDartButton
            // 
            ThrowDartButton.Location = new Point(456, 380);
            ThrowDartButton.Name = "ThrowDartButton";
            ThrowDartButton.Size = new Size(163, 58);
            ThrowDartButton.TabIndex = 2;
            ThrowDartButton.Text = "Throw &Dart";
            ThrowDartButton.UseVisualStyleBackColor = true;
            ThrowDartButton.Click += ThrowDartButton_Click;
            // 
            // DartGame
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
