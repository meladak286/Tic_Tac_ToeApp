using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    public static class DrawWinnerLine
    {
        /// <summary>
        /// Generate the winner line
        /// </summary>
        /// <param name="board">The main board to draw the line over it</param>
        /// <param name="positions">The positions of the winner symbols</param>
        /// <returns>The line ready to be added</returns>
        public static Line Draw(Grid board, List<int> positions)
        {
            // Get the positions of the winner symbols
            int[] xPos = positions.GetRange(0, 2).ToArray();
            int[] yPos = positions.GetRange(4, 2).ToArray();

            // Get the first and last button to draw a line between them
            Button xButton = board.Children
            .Cast<Button>()
            .First(e => Grid.GetRow(e) == xPos[1] && Grid.GetColumn(e) == xPos[0]);
            Button yButton = board.Children
            .Cast<Button>()
            .First(e => Grid.GetRow(e) == yPos[1] && Grid.GetColumn(e) == yPos[0]);

            // Get the points for the line
            Point i = xButton.TransformToAncestor(board)
                          .Transform(new Point(0, 0));
            Point j = yButton.TransformToAncestor(board)
                          .Transform(new Point(0, 0));

            // Set the line points
            Line line = new Line();
            line.Y1 = i.Y + (xButton.ActualHeight / 2);
            line.X1 = i.X + (xButton.ActualWidth / 2);
            line.X2 = j.X + (yButton.ActualWidth / 2);
            line.Y2 = j.Y + (yButton.ActualHeight / 2);

            line.Stroke = Brushes.LightBlue;
            line.StrokeThickness = 5;

            return line;
        }
    }
}
