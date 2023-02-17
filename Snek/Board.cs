namespace Snek
{
    internal class Board
    {
        public static BoardTiles[,] boardPrimary   = new BoardTiles[Game.Height, Game.Width];
        
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public char Character { get; set; }
        public ConsoleColor Color { get; set; }

        public Board(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

    }
}
