using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek
{
    internal class Food
    {
        public static int[] FoodPos;

        public static void GenerateFood()
        {
             Random rnd = new Random();
            int[] foodPos = {rnd.Next(Game.Height),rnd.Next(Game.Width) };
            
            if (Game.CreateFoodPrimary)
            {
                if (Board.boardPrimary[foodPos[0], foodPos[1]] == BoardTiles.FREESPACE)
                {
                    Game.CreateFoodPrimary = false;
                    Board.boardPrimary[foodPos[0], foodPos[1]] = BoardTiles.FOOD;
                    FoodPos = foodPos;
                }
                else
                {
                    GenerateFood();
                }
            }
            
            
        }

    }
}
