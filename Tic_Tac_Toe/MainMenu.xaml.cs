using System.Windows;
using Tic_Tac_Toe.Library;
using Tic_Tac_Toe.Library.Interfaces;
using Tic_Tac_Toe.Library.Models;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window, IPlayerRequester
    {
        PlayerModel playerOne;
        PlayerModel playerTwo;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox msg = new MessageBox();
            MessageBoxResult result = msg.Show("", "Are you sure you want to quit");

            // Check if the user confirmed he wants to exit.
            if (result == MessageBoxResult.Yes)
            {
                this.Close(); 
            }
        }

        private void btnSinglePlayer_Click(object sender, RoutedEventArgs e)
        {
            CreatePlayersWindow window = new CreatePlayersWindow(this, GameMode.Single);
            window.ShowDialog();
            // Check if the user has created the player.
            if (playerOne is not null && playerTwo is not null)
            {
                SinglePlayerWindow singlePlayerWindow = new SinglePlayerWindow(playerOne, playerTwo);
                singlePlayerWindow.ShowDialog(); 
            }
        }

        private void btnMultiPlayer_Click(object sender, RoutedEventArgs e)
        {
            CreatePlayersWindow window = new CreatePlayersWindow(this, GameMode.Multi);
            window.ShowDialog();
            // Check if the user has created both players
            if (playerOne is not null && playerTwo is not null)
            {
                MultiPlayerWindow multiPlayerWindow = new MultiPlayerWindow(playerOne, playerTwo);
                multiPlayerWindow.ShowDialog(); 
            }
        }

        /// <summary>
        /// Assign the player model to the local instance
        /// </summary>
        /// <param name="model">The first player model</param>
        public void CreateFirstPlayer(PlayerModel model)
        {
            playerOne = model;
        }

        /// <summary>
        /// Assign the player model to the local instance
        /// </summary>
        /// <param name="model">The second player model</param>
        public void CreateSecondPlayer(PlayerModel model)
        {
            playerTwo = model;
        }
    }
}
