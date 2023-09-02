using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tic_Tac_Toe;
using Tic_Tac_Toe.Library;
using Tic_Tac_Toe.Library.Models;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for SinglePlayerWindow.xaml
    /// </summary>
    public partial class SinglePlayerWindow : Window
    {
        PlayerModel PlayerOne, PlayerTwo;
        int[,] boardArray = new int[3, 3];
        List<Difficulty> difficulties = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();
        Difficulty difficulty = Difficulty.NotDefined;

        public SinglePlayerWindow(PlayerModel playerOne, PlayerModel playerTwo)
        {
            InitializeComponent();

            // assign player model to the local instance
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;

            // Display players names
            txbPlayerOne.Text = playerOne.Name;
            txbPlayerTwo.Text = playerTwo.Name;

            cbxDifficulty.ItemsSource = difficulties;
            cbxDifficulty.SelectedIndex = 0;
        }

        private void btnBoardClick(object sender, RoutedEventArgs e)
        {
            // Display the player on the button that he clicked
            Button btn = (Button)sender;
            DisplaySymbol.Display(btn, PlayerOne);

            // Get the button that have been clicked position
            int row = Grid.GetRow(btn);
            int col = Grid.GetColumn(btn);

            // Add the clicked button position to the button positions array
            boardArray[row, col] = PlayerOne.Id;

            if(CheckForWinner() == true)
            {
                return;
            }
            board.IsEnabled = false;
            int x, y;
            (x, y) = ComputerLogic.PlayTurn(boardArray, difficulty);

            btn = board.Children
            .Cast<Button>()
            .FirstOrDefault(e => Grid.GetRow(e) == x && Grid.GetColumn(e) == y);
            if(btn is not null)
            {
                DisplaySymbol.Display(btn, PlayerTwo);
            }
            CheckForWinner();
            if (boardArray.Cast<int>().Contains(0))
            {
                board.IsEnabled = true; 
            }

        }
        private bool CheckForWinner()
        {
            PlayerModel winner = null;
            // Check for a winner
            var (id, positions) = CheckWinner.Check(boardArray);
            // Check if there is a winner or not
            if (id != 0)
            {

                if (PlayerOne.Id == id)
                {
                    winner = PlayerOne;
                }
                else if (PlayerTwo.Id == id)
                {
                    winner = PlayerTwo;
                }
                if (winner is not null)
                {
                    // Stop the game
                    mainBoard.IsEnabled = false;

                    // Draw the line on the screen
                    Line line = DrawWinnerLine.Draw(board, positions);
                    Grid.SetRow(line, 1);
                    Grid.SetColumn(line, 1);
                    mainBoard.Children.Add(line);


                    MessageBox mbox = new MessageBox();
                    MessageBoxResult result = mbox.Show("We have a winner!", $"The winner is {winner.Name}\n Do you want to try again?");
                    if (result == MessageBoxResult.Yes)
                    {
                        // Start the game again
                        Reset();
                    }
                    else
                    {
                        // Go back to main menu
                        this.Close();
                    }
                    return true;
                }
            }
            return false;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void cbxDifficulty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            difficulty = (Difficulty)cbxDifficulty.SelectedItem;
            if (difficulty != Difficulty.NotDefined)
            {
                cbxDifficulty.IsEnabled = false;
                board.IsEnabled = true; 
            }
        }

        private void Reset()
        {
            SinglePlayerWindow window = new SinglePlayerWindow(PlayerOne, PlayerTwo);
            window.Show();
            this.Close();
        }
    }
}
