namespace DartGameFall26
/*Luke Groesbeck
*Fall 2026
*RCET 3371
*DartGame
*Advanced Programming Techniques & GUI Development
*https://github.com/groeluke/DartGameF26
*/
{
    public partial class DartGame : Form
    {
        public DartGame()
        {
            InitializeComponent();
        }

        int GetNumberFrom(int max, int min = 0)
        {
            Random randy = new Random();
            return randy.Next(min, max + 1);
        }

        void Spiral()
        {
            System.Math.Cos(0);
            System.Math.Sin(5);
        }

        void DrawDart(int x, int y)
        {
            Graphics g = DrawPictureBox.CreateGraphics();   // makes the drawing object
            Pen thePen = new Pen(Color.FromArgb(GetNumberFrom(255), GetNumberFrom(255), GetNumberFrom(255))); // makes the background white
            int size = GetNumberFrom(169);
            thePen.Width = GetNumberFrom(7);

            g.DrawEllipse(thePen, x - size / 2, y - size / 2, size, size);        // draws the dartboard
            g.DrawLine(thePen, x - 10, y, x + 10, y);        // draws the dartboard
            g.DrawLine(thePen, x, y - 10, x, y + 10);        // draws the dartboard

            thePen.Dispose();                               // cleans up the pen object
            g.Dispose();                                    // cleans up the drawing object

        }


        //Event handlers below this***************************************

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThrowDartButton_Click(object sender, EventArgs e)
        {
            int x = GetNumberFrom(DrawPictureBox.Width);
            int y = GetNumberFrom(DrawPictureBox.Height);
            DrawDart(x, y);                                 // calls the DrawDart method to draw a dart at a random location
        }

        private void DrawSpiralButton_Click(object sender, EventArgs e)
        {
            Spiral();                                       // calls the Spiral method to draw a spiral
        }
    }
}
