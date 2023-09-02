using Tic_Tac_Toe.Library.Models;

namespace Tic_Tac_Toe.Library.Interfaces
{
    public interface IPlayerRequester
    {
        void CreateFirstPlayer(PlayerModel model);
        void CreateSecondPlayer(PlayerModel model);
    }
}
