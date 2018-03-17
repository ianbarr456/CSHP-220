using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Resources;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int turnsCounter = 0;
        private string playerImage = "Images/X.png";
        int[,] gridArray = new int[3, 3];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void r0C0Button_Click(object sender, RoutedEventArgs e)
        {
            if (r0C0Button.Background == Brushes.Black)
            {
                player(0, 0);

                // Using Resource declaration for image
                Uri resourceUri = new Uri(playerImage, UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;

                r0C0Button.Background = brush;
            }
        }
        private void r0C1Button_Click(object sender, RoutedEventArgs e)
        {
            if (r0C1Button.Background == Brushes.Black)
            {
                player(0, 1);

                // Using Resource declaration for image
                Uri resourceUri = new Uri(playerImage, UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;

                r0C1Button.Background = brush;
            }
        }
        private void r0C2Button_Click(object sender, RoutedEventArgs e)
        {
            if (r0C2Button.Background == Brushes.Black)
            {
                player(0, 2);

                // Using Resource declaration for image
                Uri resourceUri = new Uri(playerImage, UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;

                r0C2Button.Background = brush;
            }
        }
        private void r1C0Button_Click(object sender, RoutedEventArgs e)
        {
            if (r1C0Button.Background == Brushes.Black)
            {
                player(1, 0);

                // Using Resource declaration for image
                Uri resourceUri = new Uri(playerImage, UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;

                r1C0Button.Background = brush;
            }
        }
        private void r1C1Button_Click(object sender, RoutedEventArgs e)
        {
            if (r1C1Button.Background == Brushes.Black)
            {
                player(1, 1);

                // Using Resource declaration for image
                Uri resourceUri = new Uri(playerImage, UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;

                r1C1Button.Background = brush;
            }
        }
        private void r1C2Button_Click(object sender, RoutedEventArgs e)
        {
            if (r1C2Button.Background == Brushes.Black)
            {
                player(1, 2);

                // Using Resource declaration for image
                Uri resourceUri = new Uri(playerImage, UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;

                r1C2Button.Background = brush;
            }
        }
        private void r2C0Button_Click(object sender, RoutedEventArgs e)
        {
            if (r2C0Button.Background == Brushes.Black)
            {
                player(2, 0);

                // Using Resource declaration for image
                Uri resourceUri = new Uri(playerImage, UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;

                r2C0Button.Background = brush;
            }
        }
        private void r2C1Button_Click(object sender, RoutedEventArgs e)
        {
            if (r2C1Button.Background == Brushes.Black)
            {
                player(2, 1);

                // Using Resource declaration for image
                Uri resourceUri = new Uri(playerImage, UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;

                r2C1Button.Background = brush;
            }
        }
        private void r2C2Button_Click(object sender, RoutedEventArgs e)
        {
            if (r2C2Button.Background == Brushes.Black)
            {
                player(2, 2);

                // Using Resource declaration for image
                Uri resourceUri = new Uri(playerImage, UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;

                r2C2Button.Background = brush;
                //if (resourceUri.OriginalString == "Images/X.png");
            }

        }
        private string player(int gridRow, int gridColumn)
        {
            turnsCounter += 1;
            if (turnsCounter <= 9)
            {
                if (turnsCounter % 2 == 0)
                {
                    playerImage = "Images/O.png";
                    uxStatus.Text = "Turn: Player X";
                    uxStatus.Foreground = Brushes.Red;
                    gridArray[gridRow, gridColumn] = 2;
                }
                else
                {
                    playerImage = "Images/X.png";
                    uxStatus.Text = "Turn: Player O";
                    uxStatus.Foreground = Brushes.RoyalBlue;
                    gridArray[gridRow, gridColumn] = 1;
                }
            }

            bool vrtWin = isVerticalWin();
            bool hzlWin = isHorizontalWin();
            bool diagWin = isDiagonalWin();

            if (turnsCounter == 9 && vrtWin == false && hzlWin == false && diagWin == false)
            {
                uxStatus.Text = "Tie game";
                uxStatus.Foreground = Brushes.Green;
            }

            return playerImage;
        }
        private bool isVerticalWin()
        {
            if ((gridArray[0, 0] == 1 && gridArray[1, 0] == 1 && gridArray[2, 0] == 1) || (gridArray[0, 1] == 1 && gridArray[1, 1] == 1 && gridArray[2, 1] == 1) ||
                (gridArray[0, 2] == 1 && gridArray[1, 2] == 1 && gridArray[2, 2] == 1))
            {
                uxStatus.Text = "Player X Wins!!!";
                uxStatus.Foreground = Brushes.Red;
                disableRemainingMoves();
                return true;
            }

            else if ((gridArray[0, 0] == 2 && gridArray[1, 0] == 2 && gridArray[2, 0] == 2) || (gridArray[0, 1] == 2 && gridArray[1, 1] == 2 && gridArray[2, 1] == 2) ||
                (gridArray[0, 2] == 2 && gridArray[1, 2] == 2 && gridArray[2, 2] == 2))
            {
                uxStatus.Text = "Player O Wins!!!";
                uxStatus.Foreground = Brushes.RoyalBlue;
                disableRemainingMoves();
                return true;
            }
            else { return false; }
        }
        private bool isHorizontalWin()
        {
            if ((gridArray[0, 0] == 1 && gridArray[0, 1] == 1 && gridArray[0, 2] == 1) || (gridArray[1, 0] == 1 && gridArray[1, 1] == 1 && gridArray[1, 2] == 1) ||
                (gridArray[2, 0] == 1 && gridArray[2, 1] == 1 && gridArray[2, 2] == 1))
            {
                uxStatus.Text = "Player X Wins!!!";
                uxStatus.Foreground = Brushes.Red;
                disableRemainingMoves();
                return true;
            }

            else if ((gridArray[0, 0] == 2 && gridArray[0, 1] == 2 && gridArray[0, 2] == 2) || (gridArray[1, 0] == 2 && gridArray[1, 1] == 2 && gridArray[1, 2] == 2) ||
                (gridArray[2, 0] == 2 && gridArray[2, 1] == 2 && gridArray[2, 2] == 2))
            {
                uxStatus.Text = "Player O Wins!!!";
                uxStatus.Foreground = Brushes.RoyalBlue;
                disableRemainingMoves();
                return true;
            }
            else { return false; }
        }
        private bool isDiagonalWin()
        {
            if ((gridArray[0, 0] == 1 && gridArray[1, 1] == 1 && gridArray[2, 2] == 1) || (gridArray[0, 2] == 1 && gridArray[1, 1] == 1 && gridArray[2, 0] == 1))
            {
                uxStatus.Text = "Player X Wins!!!";
                uxStatus.Foreground = Brushes.Red;
                disableRemainingMoves();
                return true;
            }

            else if ((gridArray[0, 0] == 2 && gridArray[1, 1] == 2 && gridArray[2, 2] == 2) || (gridArray[0, 2] == 2 && gridArray[1, 1] == 2 && gridArray[2, 0] == 2))
            {
                uxStatus.Text = "Player O Wins!!!";
                uxStatus.Foreground = Brushes.RoyalBlue;
                disableRemainingMoves();
                return true;
            }
            else { return false; }
        }
        private void disableRemainingMoves()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gridArray[i, j] == 0)
                    {
                        string buttonCall = $"r{i}C{j}Button";
                        foreach (Button item in boardArea.Children)
                        {
                            if (item.Name == buttonCall)
                            {
                                item.IsEnabled = false;
                            }
                        }

                    }
                }
            }
        }

        private void OnNew_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gridArray[i, j] = 0;

                    string buttonCall = $"r{i}C{j}Button";
                    foreach (Button item in boardArea.Children)
                    {
                        if (item.Name == buttonCall)
                        {
                            item.IsEnabled = true;
                            item.Background = Brushes.Black;
                        }
                    }
                }
            }
            uxStatus.Text = "Turn: Player X";
            uxStatus.Foreground = Brushes.Red;
            turnsCounter = 0;
        }
        private void OnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
