using System.Linq; 
namespace Snek
{
    internal class Snake
    {
          public static int CurrentPosX { get; set; }
          public static int CurrentPosY {get;set;}

        public static int[,] TTLBodies = new int[Game.Height,Game.Width];

        public static MovementKeys Direction { get; set; }

        public static void Movement()
        {
            int currentPosX = CurrentPosX;
            int currentPosY = CurrentPosY;

            int tempPosX = currentPosX;
            int tempPosY = currentPosY;

            switch (Direction)
            {
                case MovementKeys.UP:
                    currentPosY--;
                    break;
                case MovementKeys.DOWN:
                    currentPosY++;
                    break;
                case MovementKeys.RIGHT:
                    currentPosX++;
                    break;
                case MovementKeys.LEFT:
                    currentPosX--;
                    break;
            }

            CurrentPosX = currentPosX;
            CurrentPosY = currentPosY;
            if (Board.boardPrimary[currentPosY, currentPosX] != BoardTiles.FREESPACE)
            {
                if (Board.boardPrimary[currentPosY, currentPosX] != BoardTiles.FOOD)
                    currentPosX *= 100000000;
            }

            

             if (currentPosX == Food.FoodPos[1] && currentPosY == Food.FoodPos[0])
            {
                Game.Score++;
                
                Game.CreateFoodPrimary = true;
                TTLBodies[tempPosY, tempPosX] = Game.Score;
            }
             else
            {

                TTLBodies[tempPosY, currentPosX] = Game.Score;
            }

            

            for (int i = 0; i < Game.Height; i++)
            {
                for (int j = 0; j < Game.Width; j++)
                {

                    if (TTLBodies[i, j] <= 1
                        && i != Food.FoodPos[0]
                        && j != Food.FoodPos[1])
                    {
                        Board.boardPrimary[i, j] = BoardTiles.FREESPACE;
                    }

                    else if (TTLBodies[i,j] > 0)
                    {
                        TTLBodies[i, j] -= 1;
                        Board.boardPrimary[i, j] = BoardTiles.SNEKBODY_P1;
                    }
                }
            }

           

            Board.boardPrimary[currentPosY, currentPosX] = BoardTiles.SNEKHEAD_P1;
        }






    }
}
