using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mini_Project;
using System.Drawing;

namespace HangAMan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IBackend _backend;
        private bool _gameRunning;
        private IList<BitmapImage> pictures;

        public MainWindow()
        {
            InitializeComponent();
            pictures = new List<BitmapImage>(11);
            string path = @".\Pictures\";
            foreach (var file in Directory.GetFiles(path, "*.png", SearchOption.TopDirectoryOnly))
            {
                pictures.Add(new BitmapImage(new Uri(file)));
            }
        }

        private void buttonStartGame_Click(object sender, RoutedEventArgs e)
        {
            //_backend = new ;
            var scenario = GenerateScenario();
            _backend.Setup(scenario.Item1, scenario.Item2);
            string word = _backend.GetWord();
            string wordUI = "";
            foreach (var c in word)
            {
                wordUI += " _";
            }
            labelWord.Content = wordUI;
            UpdateAttemptsLeft();
            _gameRunning = true;
        }

        private Tuple<string, int> GenerateScenario()
        {
            return null;
        }

        private void UpdateAttemptsLeft()
        {
            labelAttemptsLeft.Content = _backend.GetAllowedAttempts() - _backend.GetGuessAttempts();
        }

        private void UpdatePicture()
        {
            int failedAttempts = _backend.GetFailedAttempts();
            int totalAttempts = _backend.GetAllowedAttempts();
            if (failedAttempts >= totalAttempts)
            {
                // Show last picture
                image.Source = pictures.Last();
            }
            else
            {
                int percentage = failedAttempts / totalAttempts * 10;
                // Show the picture that matches the closest picture id from the percentage between failedAttempts and totalAttempts
                // Show the picture.
                image.Source = pictures[percentage];
            }
        }

        private void UpdateUI()
        {
            UpdateAttemptsLeft();
            if (_backend.IsGameWon())
            {
                ResetGame();
                MessageBox.Show("Congratulations. You won!");
            }
            else if (_backend.IsGameOver())
            {
                ResetGame();
                MessageBox.Show("Awww. You lost..");
            }
            string word = _backend.GetWord();
            string[] guessedChars = _backend.GetGuesses();
            string wordUI = "";
            foreach (var c in word)
            {
                if (guessedChars.Any(s => s.Equals(c.ToString())))
                {
                    wordUI += " " + c;
                }
                else
                {
                  wordUI += " _";  
                }
            }
            labelWord.Content = wordUI;
            UpdatePicture();
        }

        private void ResetGame()
        {
            _gameRunning = false;
            labelAttemptsLeft.Content = 0;
            labelWord.Content = "";
            textBoxGuessWord.Text = "";
            image.Source = pictures.First();
        }

        private void MakeAGuess(char input)
        {
            input = Char.ToLower(input);
            _backend.Guess(input);
            UpdateUI();
        }

        private void buttonGuessWord_Click(object sender, RoutedEventArgs e)
        {
            string input = textBoxGuessWord.Text;
            _backend.Guess(input);
            UpdateUI();
        }

        #region LetterButtons

        private void buttonA_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('A');
        }

        private void buttonB_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('B');
        }

        private void buttonC_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('C');
        }

        private void buttonD_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('D');
        }

        private void buttonE_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('E');
        }

        private void buttonF_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('F');
        }

        private void buttonG_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('G');
        }

        private void buttonH_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('H');
        }

        private void buttonI_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('I');
        }

        private void buttonJ_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('J');
        }

        private void buttonK_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('K');
        }

        private void buttonL_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('L');
        }

        private void buttonM_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('M');
        }

        private void buttonN_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('N');
        }

        private void buttonO_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('O');
        }

        private void buttonP_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('P');
        }

        private void buttonQ_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('Q');
        }

        private void buttonR_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('R');
        }

        private void buttonS_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('S');
        }

        private void buttonT_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('T');
        }

        private void buttonU_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('U');
        }

        private void buttonV_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('V');
        }

        private void buttonW_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('W');
        }

        private void buttonX_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('X');
        }

        private void buttonY_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('Y');
        }

        private void buttonZ_Click(object sender, RoutedEventArgs e)
        {
            MakeAGuess('Z');
        }

        #endregion
        
    }
}