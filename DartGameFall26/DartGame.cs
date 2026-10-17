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
            ModeLabel.Text = reviewMode ? "Review Mode" : "Play Mode";
        }

        int GetRandomNumber(int max)
        {
            return random.Next(0, max);
        }

        // Turns one log line into 7 ints. Returns false if the line is corrupt.
        bool TryReadRound(string line, out int[] values)
        {
            values = new int[7];
            string[] parts = line.Split(',');
            if (parts.Length != 7)
            {
                return false;
            }
            for (int i = 0; i < 7; i++)
            {
                if (!int.TryParse(parts[i], out values[i]))
                {
                    return false;
                }
            }
            return true;
        }

        // Reads the whole log into loggedRounds, skipping bad lines.
        void LoadRounds()
        {
            loggedRounds.Clear();
            try
            {
                if (File.Exists(LogPath))
                {
                    foreach (string line in File.ReadAllLines(LogPath))
                    {
                        if (TryReadRound(line, out int[] values))
                        {
                            loggedRounds.Add(values);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not read the log file: " + ex.Message);
            }
        }

        // Finds the highest round number so a new round continues from there.
        int GetLastRoundNumber()
        {
            LoadRounds();
            int last = 0;
            foreach (int[] round in loggedRounds)
            {
                if (round[0] > last)
                {
                    last = round[0];
                }
            }
            return last;
        }

        // Appends the finished round to the log (creates the file if it's missing).
        void LogRound()
        {
            string line = $"{currentRound},{dartX[0]},{dartY[0]},{dartX[1]},{dartY[1]},{dartX[2]},{dartY[2]}";
            try
            {
                File.AppendAllText(LogPath, line + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not write to the log file: " + ex.Message);
            }
        }

        //add noises for when the dart hits the board or misses the board
        // Returns true if the dart landed on the dartboard circle.
        bool IsOnBoard(int x, int y)
        {
            int centerX = DartBoardPictureBox.ClientSize.Width / 2;
            int centerY = DartBoardPictureBox.ClientSize.Height / 2;

            // The board is about 26% of the picture's smaller side (adjust if it feels off)
            int smallerSide = Math.Min(DartBoardPictureBox.ClientSize.Width, DartBoardPictureBox.ClientSize.Height);
            double boardRadius = smallerSide * 0.26;

            double distance = Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));
            return distance <= boardRadius;
        }

        void PlayThrowSound(bool hit)
        {
            if (hit)
            {
                System.Media.SystemSounds.Asterisk.Play();   // "ding" for a hit
            }
            else
            {
                System.Media.SystemSounds.Hand.Play();       // error sound for a miss
            }
        }
        //Event handlers below this***************************************

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DartGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Space)
            {
                return;
            }
            e.Handled = true;            // stops Space from "clicking" whichever button has focus
            e.SuppressKeyPress = true;

            if (!roundInProgress)        // ignore Space in review mode or before a round starts
            {
                return;
            }

            // 1. pick a random spot for this dart
            dartX[throwCount] = GetRandomNumber(DartBoardPictureBox.ClientSize.Width);
            dartY[throwCount] = GetRandomNumber(DartBoardPictureBox.ClientSize.Height);

            // 2. draw it and play the hit/miss sound
            DrawDart(dartX[throwCount], dartY[throwCount]);
            PlayThrowSound(IsOnBoard(dartX[throwCount], dartY[throwCount]));

            // 3. count the throw (only once!)
            throwCount++;

            if (throwCount == 3)         // round over: save it
            {
                LogRound();
                roundInProgress = false;
                MessageBox.Show($"Round {currentRound} logged!");
            }
            UpdateLabels();
        }

        private void StartRoundButton_Click(object sender, EventArgs e)
        {
            reviewMode = false;
            RoundsListBox.Enabled = false;
            RoundsListBox.Items.Clear();
            ClearDartBoard();
            currentRound = GetLastRoundNumber() + 1;
            throwCount = 0;
            roundInProgress = true;
            UpdateLabels();
        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            roundInProgress = false;     // leaves play mode (an unfinished round is not logged)
            reviewMode = true;
            currentRound = 0;
            throwCount = 0;
            ClearDartBoard();

            LoadRounds();
            RoundsListBox.Items.Clear();
            foreach (int[] round in loggedRounds)
            {
                RoundsListBox.Items.Add($"Round {round[0]}");
            }
            RoundsListBox.Enabled = true;

            if (loggedRounds.Count == 0)
            {
                MessageBox.Show("No rounds found. Play a round first.");
            }
            UpdateLabels();

        }

        private void RoundsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reviewMode || RoundsListBox.SelectedIndex < 0)
            {
                return;                  // nothing valid selected
            }

            int[] round = loggedRounds[RoundsListBox.SelectedIndex]; // same order as the list
            ClearDartBoard();
            for (int i = 1; i < 7; i += 2)   // positions 1,3,5 are X; 2,4,6 are Y
            {
                DrawDart(round[i], round[i + 1]);
            }
            currentRound = round[0];
            throwCount = 3;
            UpdateLabels();
        }
    }
}
