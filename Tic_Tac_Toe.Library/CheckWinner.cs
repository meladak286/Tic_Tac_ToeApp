using System.Collections.Generic;
using System.Net.Http.Headers;
using Tic_Tac_Toe.Library.Models;

namespace Tic_Tac_Toe.Library
{
    public static class CheckWinner
    {
        /// <summary>
        /// Check if the game has a winner in this round.
        /// </summary>
        /// <param name="board">The array of user inputs</param>
        /// <returns>
        /// The id of the winner if there is a winner
        /// and return 0 if there is no winner.
        /// returns the symbol positions for the winner
        /// </returns>
        public static (int, List<int>) Check(int[,] board)
        {
            List<int> positions;
            int ch, cv, cd;
            (ch, positions) = CheckHorizontally(board);
            if (ch != 0)
            {
                return (ch, positions);
            }
            (cv, positions) = CheckVertically(board);
            if(cv != 0)
            {
                return (cv, positions);
            }
            (cd, positions) = CheckDiagonally(board);
            if(cd != 0)
            {
                return (cd, positions);
            }
            return (0, new List<int>());
        }
        /// <summary>
        /// Check if there is horizontal winner
        /// </summary>
        /// <param name="board">The array of user inputs</param>
        /// <returns>
        /// The id of the winner if there is a winner
        /// and return 0 if there is no winner.
        /// returns the symbol positions for the winner
        /// </returns>
        private static (int, List<int>) CheckHorizontally(int[,] board)
        {
            int count = 0;
            List<int> positions = new List<int>();
            int id = 0;
            int j, i;
            for (i = 0; i < 3; i++)
            {
                count = 0;
                positions = new List<int>();
                for (j = 0; j < 2; j++)
                {
                    if (board[i, j] == board[i, j + 1] && board[i, j] != 0)
                    {
                        count++;
                        positions.Add(j);
                        positions.Add(i);
                    }
                    else
                    {
                        count = 0;
                    }
                    id = board[i, j];
                }

                positions.Add(j);
                positions.Add(i);
                if (count == 2)
                {                    
                    return (id, positions);
                }
            }
            return (0, new List<int>());
        }
        /// <summary>
        /// Check if there is vertical winner
        /// </summary>
        /// <param name="board">The array of user inputs</param>
        /// <returns>
        /// The id of the winner if there is a winner
        /// and return 0 if there is no winner.
        /// returns the symbol positions for the winner
        /// </returns>
        private static (int, List<int>) CheckVertically(int[,] board)
        {
            int count = 0;
            List<int> positions = new List<int>();
            int id = 0;
            int i, j;
            for (i = 0; i < 3; i++)
            {
                count = 0;
                positions = new List<int>();
                for (j = 0; j < 2; j++)
                {
                    if (board[j, i] == board[j + 1, i] && board[j , i] != 0)
                    {
                        count++;
                        positions.Add(i);
                        positions.Add(j);
                    }
                    else
                    {
                        count = 0;
                    }
                    id = board[j, i];
                }
                positions.Add(i);
                positions.Add(j);
                if (count == 2)
                {
                    return (id, positions);
                }
            }
            return (0, new List<int>());
        }
        /// <summary>
        /// Check if there is diagonal winner
        /// </summary>
        /// <param name="board">The array of user inputs</param>
        /// <returns>
        /// The id of the winner if there is a winner
        /// and return 0 if there is no winner.
        /// returns the symbol positions for the winner
        /// </returns>
        private static (int, List<int>) CheckDiagonally(int[,] board)
        {
            int j = 0;
            int count = 0;
            List<int> positions = new List<int>();
            int output = board[0, 0];
            for(int i = 0; i < 3; i++)
            {
                if (board[i,j] == output && board[i, j] != 0)
                {
                    count++;
                    positions.Add(j);
                    positions.Add(i);
                }
                else
                {
                    count = 0;
                    output = 0;
                    positions = new List<int>();
                }
                j++;
            }
            if(count == 3)
            {
                return (output, positions);
            }
            j = 2;
            count = 0;
            output = board[0, 2];
            positions = new List<int>();
            for(int i = 0; i < 3; i++)
            {
                if (board[i, j] == output && board[i, j] != 0)
                {
                    count++;
                    positions.Add(j);
                    positions.Add(i);
                }
                else
                {
                    count = 0;
                    output = 0;
                    positions = new List<int>();
                }
                j--;
            }
            if (count == 3)
            {
                return (output, positions);
            }
            return (0, new List<int>());
        }
    }
}
