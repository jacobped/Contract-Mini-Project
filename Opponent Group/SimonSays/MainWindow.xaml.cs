using System;
using System.Collections.Generic;
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
using System.Threading;
using System.ComponentModel;
using System.Timers;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace SimonSays
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private IList<int> buttons;
        private int position = 0;
        private IDataProvider dataProvider;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer() { IsEnabled = true, Interval = new TimeSpan(0, 0, 1), };
            timer.Tick += (s, es) =>
            {
                if (position >= buttons.Count)
                    return;
                Flash(buttons[position]);
                position++;

            };
            timer.Start();
        }

        private void Animate(Button button)
        {
            var blinkAnimation = new DoubleAnimation
            {
                From = 1,
                To = 0
            };

            var blinkStoryboard = new Storyboard
            {
                Duration = TimeSpan.FromMilliseconds(500),
                AutoReverse = true
            };

            Storyboard.SetTarget(blinkAnimation, button);
            Storyboard.SetTargetProperty(blinkAnimation, new PropertyPath(OpacityProperty));

            blinkStoryboard.Children.Add(blinkAnimation);
            button.BeginStoryboard(blinkStoryboard);
        }

        private void Flash(int position)
        {
            Button button;
            switch (position)
            {
                case 1:
                    button = button1;
                    break;
                case 2:
                    button = button2;

                    break;
                case 3:
                    button = button3;

                    break;
                case 4:
                    button = button4;
     
                    break;
                default:
                    throw new Exception("You suck!");
            }
            Animate(button);
        }

        private void CheckButtonPress(int buttonNumber)
        {
            dataProvider.MoveCheckMarkerToNextPosition();
            var correct = dataProvider.MatchesWithCheckMarker(buttonNumber - 1);
            if(!correct)
            {
                StopGame();
                return;
            }

            var lastOne = !dataProvider.CanMoveCheckMarker();
            if (lastOne)
                IncreaseSequence();
        }

        private void StopGame()
        {
            dataProvider.ClearSequence();
            buttons.Clear();
            position = 0;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CheckButtonPress(0);
            Animate(button1);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            CheckButtonPress(1);
            Animate(button2);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            CheckButtonPress(2);
            Animate(button3);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            CheckButtonPress(3);
            Animate(button4);
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            dataProvider.ClearSequence();
            IncreaseSequence();   
        }

        private void IncreaseSequence()
        {
            dataProvider.IncreaseSequenceLength(4);
            buttons = dataProvider.GetSequence();
            position = 0;
        }

        private void buttonReplay_Click(object sender, RoutedEventArgs e)
        {
            position = 0;
        }
  
    }
}
