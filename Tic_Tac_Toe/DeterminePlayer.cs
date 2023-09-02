using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Tic_Tac_Toe.Library;
using Tic_Tac_Toe.Library.Models;

namespace Tic_Tac_Toe
{
    internal static class DeterminePlayer
    {
        /// <summary>
        /// Choose which player gets to play in this turn
        /// </summary>
        public static PlayerModel Determine(ref Turns turn, TextBlock txbPlayerOne, TextBlock txbPlayerTwo, PlayerModel PlayerOne, PlayerModel PlayerTwo)
        {
            if (turn == Turns.First)
            {
                txbPlayerOne.Foreground = Brushes.Navy;
                txbPlayerTwo.Foreground = Brushes.SkyBlue;
                turn = Turns.Second;
                return PlayerOne;
            }
            else
            {
                txbPlayerTwo.Foreground = Brushes.Navy;
                txbPlayerOne.Foreground = Brushes.SkyBlue;
                turn = Turns.First;
                return PlayerTwo;
            }
        }
    }
}
