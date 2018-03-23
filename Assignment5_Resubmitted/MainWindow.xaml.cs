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

namespace Tic_Tac_Toe2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int turnsCounter = 0;
        private int[,] gridArray = new int[3, 3];
        public MainWindow()
        {
            InitializeComponent();
            uxTurn.Text = "Turn: Player X";
            uxTurn.Foreground = Brushes.Red;
            uxTurn.FontWeight = FontWeights.Bold;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button buttonIndex = (sender as Button);
            string buttonCoordString = buttonIndex.Tag.ToString();
            string[] coords = buttonCoordString.Split(',');
            int row = Convert.ToByte(coords[0]);
            int col = Convert.ToByte(coords[1]);
            playerAction(row, col, buttonIndex);
        }

        private string playerAction(int gridRow, int gridColumn, Button button)
        {
            turnsCounter += 1;
            if (turnsCounter <= 9)
            {
                if (turnsCounter % 2 == 0)
                {
                    button.Content = "O";
                    button.Foreground = Brushes.RoyalBlue;
                    button.FontWeight = FontWeights.Bold;
                    uxTurn.Text = "Turn: Player X";
                    uxTurn.Foreground = Brushes.Red;
                    uxTurn.FontWeight = FontWeights.Bold;
                    gridArray[gridRow, gridColumn] = 2;
                }
                else
                {
                    button.Content = "X";
                    button.Foreground = Brushes.Red;
                    button.FontWeight = FontWeights.Bold;
                    uxTurn.Text = "Turn: Player O";
                    uxTurn.Foreground = Brushes.RoyalBlue;
                    uxTurn.FontWeight = FontWeights.Bold;
                    gridArray[gridRow, gridColumn] = 1;
                }
            }

            bool vrtWin = isVerticalWin();
            bool hzlWin = isHorizontalWin();
            bool diagWin = isDiagonalWin();

            if (turnsCounter == 9 && vrtWin == false && hzlWin == false && diagWin == false)
            {
                uxTurn.Text = "Tie game";
                uxTurn.Foreground = Brushes.Green;
                disableRemainingMoves();
            }

            return (string)button.Content;
        }
        private bool isVerticalWin()
        {
            if ((gridArray[0, 0] == 1 && gridArray[1, 0] == 1 && gridArray[2, 0] == 1) || (gridArray[0, 1] == 1 && gridArray[1, 1] == 1 && gridArray[2, 1] == 1) ||
                (gridArray[0, 2] == 1 && gridArray[1, 2] == 1 && gridArray[2, 2] == 1))
            {
                uxTurn.Text = "Player X Wins!!!";
                uxTurn.Foreground = Brushes.Red;
                disableRemainingMoves();
                return true;
            }

            else if ((gridArray[0, 0] == 2 && gridArray[1, 0] == 2 && gridArray[2, 0] == 2) || (gridArray[0, 1] == 2 && gridArray[1, 1] == 2 && gridArray[2, 1] == 2) ||
                (gridArray[0, 2] == 2 && gridArray[1, 2] == 2 && gridArray[2, 2] == 2))
            {
                uxTurn.Text = "Player O Wins!!!";
                uxTurn.Foreground = Brushes.RoyalBlue;
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
                uxTurn.Text = "Player X Wins!!!";
                uxTurn.Foreground = Brushes.Red;
                disableRemainingMoves();
                return true;
            }

            else if ((gridArray[0, 0] == 2 && gridArray[0, 1] == 2 && gridArray[0, 2] == 2) || (gridArray[1, 0] == 2 && gridArray[1, 1] == 2 && gridArray[1, 2] == 2) ||
                (gridArray[2, 0] == 2 && gridArray[2, 1] == 2 && gridArray[2, 2] == 2))
            {
                uxTurn.Text = "Player O Wins!!!";
                uxTurn.Foreground = Brushes.RoyalBlue;
                disableRemainingMoves();
                return true;
            }
            else { return false; }
        }
        private bool isDiagonalWin()
        {
            if ((gridArray[0, 0] == 1 && gridArray[1, 1] == 1 && gridArray[2, 2] == 1) || (gridArray[0, 2] == 1 && gridArray[1, 1] == 1 && gridArray[2, 0] == 1))
            {
                uxTurn.Text = "Player X Wins!!!";
                uxTurn.Foreground = Brushes.Red;
                disableRemainingMoves();
                return true;
            }

            else if ((gridArray[0, 0] == 2 && gridArray[1, 1] == 2 && gridArray[2, 2] == 2) || (gridArray[0, 2] == 2 && gridArray[1, 1] == 2 && gridArray[2, 0] == 2))
            {
                uxTurn.Text = "Player O Wins!!!";
                uxTurn.Foreground = Brushes.RoyalBlue;
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
                        foreach (Button item in uxGrid.Children)
                        {
                                item.IsEnabled = false;
                        }
                }
            }
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gridArray[i, j] = 0;
                    foreach (Button item in uxGrid.Children)
                    {
                        item.Content = null;
                        item.IsEnabled = true;
                    }
                }
            }
            uxTurn.Text = "Turn: Player X";
            uxTurn.Foreground = Brushes.Red;
            turnsCounter = 0;
        }
        private void OnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
