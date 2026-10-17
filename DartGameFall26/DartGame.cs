using System.Runtime.CompilerServices;

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
            SetDefaults();
        }
        Label RoundLabel = new Label();
        Label ThrowLabel = new Label();
        Label ModelLabel = new Label();
        const string LogPath = "..\\..\\..\\DartGame.log"; // same relative path trick as your File IO practice
        Random random = new Random();                      // ONE Random for the whole form
        bool roundInProgress = false;   // true while the user is throwing darts
        bool reviewMode = false;        // true while reviewing old rounds
        int currentRound = 0;
        int throwCount = 0;             // how many darts thrown this round (0-3)
        int[] dartX = new int[3];       // the 3 dart positions for the current round
        int[] dartY = new int[3];
        List<int[]> loggedRounds = new List<int[]>();  // rounds read from the file

        void SetDefaults()
        {
            KeyPreview = true;
            KeyDown += DartGame_KeyDown;
            RoundsListBox.Enabled = false;
            UpdateLabels();
        }

        int GetNumberFrom(int max, int min = 0)
        {
            Random randy = new Random();
            return randy.Next(min, max + 1);
        }

        void DrawDart(int x, int y)
        {
            Graphics g = DartBoardPictureBox.CreateGraphics();   // makes the drawing object
            Pen thePen = new Pen(Color.Red);                     // makes the pen object
            int size = 20;
            thePen.Width = 3;

            g.DrawEllipse(thePen, x - size / 2, y - size / 2, size, size);        // draws the dartboard
            g.DrawLine(thePen, x - 5, y, x + 5, y);        // draws the dartboard
            g.DrawLine(thePen, x, y - 5, x, y + 5);        // draws the dartboard

            thePen.Dispose();                               // cleans up the pen object
            g.Dispose();                                    // cleans up the drawing object
        }
        
        void ClearDartBoard()
        {
            DartBoardPictureBox.Refresh(); // Clears the dartboard by refreshing the PictureBox
        }

        void UpdateLabels()
        {
            RoundLabel.Text = $"Round: {currentRound}";
            ThrowLabel.Text = $"Throw: {throwCount}";
            ModelLabel.Text = reviewMode ? "Review Mode" : "Play Mode";
        }

        void WritetoFile(string fileName, string text)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(text);
            }
        }

        //Event handlers below this***************************************

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DartBoardPictureBox_SpaceBar(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                int x = GetNumberFrom(DartBoardPictureBox.Width);
                int y = GetNumberFrom(DartBoardPictureBox.Height);
                DrawDart(x, y);                                 // calls the DrawDart method to draw a dart at a random location
            }
        }

        private void StartRoundButton_Click(object sender, EventArgs e)
        {
            // The method starts the round and allows the user to throw 3 darts before saving the location of
            //the darts to a file. The user can then review the darts thrown in the round.
            int rounds = RoundsListBox.SelectedIndex + 1; // Get the selected round number (1-based index)
            for (int i = 0; i < rounds; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int x = GetNumberFrom(DartBoardPictureBox.Width);
                    int y = GetNumberFrom(DartBoardPictureBox.Height);
                    WritetoFile("DartLocations.txt", $"{x},{y}");
                }
            }

        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            // The method reads the dart locations from the file and draws them on the dartboard.
            if (File.Exists("DartLocations.txt"))
            {
                string[] lines = File.ReadAllLines("DartLocations.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
                    {
                        DrawDart(x, y);
                    }
                }
            }
            else
            {
                MessageBox.Show("No dart locations found. Please throw some darts first.");
            }

        }

        private void RoundsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
