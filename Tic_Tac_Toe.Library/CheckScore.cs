using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.Library
{
    public static class CheckScore
    {
        /// <summary>
        /// Chooses the best option
        /// </summary>
        /// <param name="boardArray"></param>
        /// <param name="difficulty">The game mode</param>
        /// <returns>The position best move</returns>
        public static int[,] GetScore(int[,] boardArray, Difficulty difficulty = Difficulty.Normal)
        {    
            int[,] score = new int[3, 3];

            // Check for possible winning move for the player
            if (difficulty == Difficulty.Hard)
            {
                for (int i = 0; i < boardArray.GetLength(0); i++)
                {
                    for (int j = 0; j < boardArray.GetLength(1); j++)
                    {
                        if (boardArray[i, j] == 0)
                        {
                            boardArray[i, j] = Constants.PlayerTwoId;

                            int id;
                            (id, _) = CheckWinner.Check(boardArray);
                            boardArray[i, j] = 0;
                            if (id == Constants.PlayerTwoId)
                            {
                                score[i, j] += 10;
                                return score;
                            }
                        }
                    }
                }
                for (int i = 0; i < boardArray.GetLength(0); i++)
                {
                    for (int j = 0; j < boardArray.GetLength(1); j++)
                    {
                        if (boardArray[i, j] == 0)
                        {
                            boardArray[i, j] = Constants.PlayerOneId;

                            int id;
                            (id, _) = CheckWinner.Check(boardArray);
                            boardArray[i, j] = 0;
                            if (id == Constants.PlayerOneId)
                            {
                                score[i, j] += 10;
                                return score;
                            }


                        }
                    }
                } 
            }


            // Check Vertically
            for (int i = 0; i < boardArray.GetLength(0); i++)
            {
                for (int j = 0; j < boardArray.GetLength(1); j++)
                {
                    if (boardArray[i, j] == Constants.PlayerTwoId)
                    {
                        for (int x = 0; x < score.GetLength(1); x++)
                        {
                            if (boardArray[i, x] == 0)
                            {
                                score[i, x] += 1;
                            }
                        }
                    }
                }
            }

            // Check Horizontally
            for (int j = 0; j < boardArray.GetLength(1); j++)
            {
                for (int i = 0; i < boardArray.GetLength(0); i++)
                {
                    if (boardArray[j, i] == Constants.PlayerTwoId)
                    {
                        for (int x = 0; x < score.GetLength(0); x++)
                        {
                            if (boardArray[x, i] == 0)
                            {
                                score[x, i] += 1;
                            }
                        }
                    }
                }
            }

            // Check Diagonally
            for (int i = 0; i < boardArray.GetLength(0); i++)
            {
                if (boardArray[i, i] == Constants.PlayerTwoId)
                {
                    for (int x = 0; x < score.GetLength(0); x++)
                    {
                        if (boardArray[x, x] == 0)
                        {
                            score[x, x] += 1;
                        }
                    }
                }
                if (boardArray[2 - i, i] == Constants.PlayerTwoId)
                {
                    for (int x = 0; x < score.GetLength(0); x++)
                    {
                        if (boardArray[2 - x, x] == 0)
                        {
                            score[2 - x, x] += 1;
                        }
                    }
                }
            }
            return score;            
        }
    }
}
