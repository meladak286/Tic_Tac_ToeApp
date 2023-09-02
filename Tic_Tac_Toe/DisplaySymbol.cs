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
    internal static class DisplaySymbol
    {
        /// <summary>
        /// Display the player symbol on the selected cell
        /// </summary>
        /// <param name="btn">The cell that the player has clicked</param>
        /// <param name="activePlayer"></param>
        public static void Display(Button btn, PlayerModel activePlayer)
        {
            if (activePlayer.Symbol == PlayerSymbol.O)
            {
                btn.Foreground = Brushes.Blue;
            }
            else
            {
                btn.Foreground = Brushes.Red;
            }
            btn.Content = activePlayer.Symbol;
            btn.IsEnabled = false;
        }
    }
}
