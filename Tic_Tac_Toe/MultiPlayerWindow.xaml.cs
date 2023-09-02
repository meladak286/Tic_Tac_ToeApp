using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tic_Tac_Toe.Library;
using Tic_Tac_Toe.Library.Models;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MultiPlayerWindow.xaml
    /// </summary>
    public partial class MultiPlayerWindow : Window
    {
        private Turns turn = Turns.First;
        private PlayerModel PlayerOne;
        private PlayerModel PlayerTwo;
        private PlayerModel activePlayer;
        private int[,] boardArray = new int[3, 3];


        public MultiPlayerWindow(PlayerModel playerOne, PlayerModel playerTwo)
        {
            InitializeComponent();

            // assign player model to the local instance
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;

            // Display players names
            txbPlayerOne.Text = playerOne.Name;
            txbPlayerTwo.Text = playerTwo.Name;

        }



        private void btnBoardClick(object sender, RoutedEventArgs e)
        {
            // Get the player who is going to play in this turn
            activePlayer = DeterminePlayer.Determine(ref turn, txbPlayerOne, txbPlayerTwo, PlayerOne, PlayerTwo);

            // Display the player on the button that he clicked
            Button btn = (Button)sender;
            DisplaySymbol.Display(btn, activePlayer);

            // Get the button that have been clicked position
            int row = Grid.GetRow(btn);
            int col = Grid.GetColumn(btn);

            // Add the clicked button position to the button positions array
            boardArray[row, col] = activePlayer.Id;
            

            CheckForWinner();
        }
        private void CheckForWinner()
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

                }
            }
        }
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
        /// <summary>
        /// Resets the game
        /// </summary>
        private void Reset()
        {
            MultiPlayerWindow window = new MultiPlayerWindow(PlayerOne, PlayerTwo);
            window.Show();
            this.Close();
        }
    }

}
