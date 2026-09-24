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
        void DrawDart()
        {
            MessageBox.Show("Ima throw a dart now!");

        }

        //Event handlers below this***************************************

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThrowDartButton_Click(object sender, EventArgs e)
        {
            DrawDart();
        }
    }
}
