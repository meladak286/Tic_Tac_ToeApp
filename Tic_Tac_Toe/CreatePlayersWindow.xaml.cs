using System.Runtime.CompilerServices;
using System.Windows;
using Tic_Tac_Toe.Library;
using Tic_Tac_Toe.Library.Interfaces;
using Tic_Tac_Toe.Library.Models;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for CreatePlayersWindow.xaml
    /// </summary>
    public partial class CreatePlayersWindow : Window
    {

        IPlayerRequester callingWindow;
        GameMode gameMode;
        public CreatePlayersWindow(IPlayerRequester caller, GameMode mode)
        {
            InitializeComponent();
            // Get the calling form.
            callingWindow = caller;
            // Get the game mode
            gameMode = mode;
            // Check if the game mode is single player then lock the second player text box
            if(mode == GameMode.Single)
            {
                txtPlayerNameTwo.IsEnabled = false;
            }
        }
        /// <summary>
        /// Check if all the inputs is valid.
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            bool output = true;
            if(gameMode == GameMode.Multi)
            {
                if(txtPlayerNameOne.Text.Trim() == string.Empty)
                {
                    output = false;
                }
                if (txtPlayerNameTwo.Text.Trim() == string.Empty)
                {
                    output = false;
                }
            }
            else
            {
                if (txtPlayerNameOne.Text.Trim() == string.Empty)
                {
                    output = false;
                }
            }
            return output;
        }
        /// <summary>
        /// Initialize the player models.
        /// </summary>
        /// <param name="mode">The game mode</param>
        private void CreatePlayers(GameMode mode)
        {
            PlayerModel model = new PlayerModel();
            model.Id = Constants.PlayerOneId;
            model.Name = txtPlayerNameOne.Text;
            model.Symbol = PlayerSymbol.X;
            callingWindow.CreateFirstPlayer(model);
            model = new PlayerModel();
            model.Id = Constants.PlayerTwoId;
            model.Symbol = PlayerSymbol.O;
            if (mode == GameMode.Multi)
            {
                model.Name = txtPlayerNameTwo.Text;
            }
            else
            {
                model.Name = "Computer";
            }
            callingWindow.CreateSecondPlayer(model);
        }

        private void btnCreatePlayers_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                CreatePlayers(gameMode);
                this.Close();
            }
        }
    }
}
