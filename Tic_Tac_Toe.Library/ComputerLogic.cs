namespace Tic_Tac_Toe.Library
{
    public static class ComputerLogic
    {
        public static (int x, int y) PlayTurn(int[,] boardArray, Difficulty difficulty)
        {
            switch (difficulty)// Check the game difficulty
            {
                case Difficulty.Easy:
                    return PlayTurnEasy(boardArray);
                case Difficulty.Normal:
                    return PlayTurnNormal(boardArray);
                case Difficulty.Hard:
                    return PlayTurnHard(boardArray);

            }
            return (-1, -1);
        }
        private static (int x, int y) PlayTurnEasy(int[,] boardArray)
        {
            Random r = new Random();

            int x = r.Next(boardArray.GetLength(0));
            int y = r.Next(boardArray.GetLength(1));



            int item = boardArray[x, y];
            
            if(item == 0)
            {
                boardArray[x, y] = 2;
                return (x, y);
            }
            else
            {
                return PlayTurnEasy(boardArray);
            }
        }
        private static (int x, int y) PlayTurnNormal(int[,] boardArray)
        {
            // Check the score for each move
            int[,] score = CheckScore.GetScore(boardArray);

            // Get the best move
            int max = score.Cast<int>().Max();
            


            for(int i = 0; i < score.GetLength(0); i++)
            {
                for(int j = 0; j < score.GetLength(1); j++)
                {
                    if (score[i, j] == max && boardArray[i, j] == 0)
                    {
                        boardArray[i, j] = Constants.PlayerTwoId;
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }
        private static (int x, int y) PlayTurnHard(int[,] boardArray)
        {

            // Check the score for each move
            int[,] score = CheckScore.GetScore(boardArray, Difficulty.Hard);

            // Get the best move
            int max = score.Cast<int>().Max();



            for (int i = 0; i < score.GetLength(0); i++)
            {
                for (int j = 0; j < score.GetLength(1); j++)
                {
                    if (score[i, j] == max && boardArray[i, j] == 0)
                    {
                        boardArray[i, j] = Constants.PlayerTwoId;
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }
        
    }
}
