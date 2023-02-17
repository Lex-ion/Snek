using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek
{
    internal class Game
    {
        public static int Height  { get; set; }
        public static int Width   { get; set; }
        public int Speed { get; set; }
        public static int Instance { get; set; }
        public bool Active { get; set; }
        public int Difficulty { get; set; }
        public static int Score { get; set; }

        public static bool CreateFoodPrimary = false;
        public static bool CreateFoodSecondary = false;
        public SnekModes mode { get; set; }

        public MovementKeys lastMove = MovementKeys.UP;
        public Game(int height, int width, int speed, int instance,int difficulty)
        {
            Height = height;
            Width = width;
            Speed = speed;
            Instance = instance;
            Difficulty = difficulty;
            
        }

        public void Menu()
        {
            Console.WriteLine("-------Menu-------");
            Console.WriteLine("Kvantový snek  [1]");
            Console.WriteLine("------------------");
            while (mode==SnekModes.NONE)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.NumPad1:
                        mode = SnekModes.SINGLE_PLAYER;
                        break;
                    
                }
            }
            

            ResetCursor();
        }

        public void Prepare()
        {
            Console.CursorVisible = false;
            Console.Title = $"Snek game - {Game.Instance}";
            Console.Clear();
            Score = 0;
            mode = SnekModes.NONE;
            Snake.CurrentPosX=Width/2;
            Snake.CurrentPosY = Height / 2;
            
        }

        public void Start()
        {
            Prepare();
            Menu();
            Active=true;
            CreateFoodPrimary = true;
            
        }

        public void Loop()
        {
            

            
            
            Wait();

            Update();

            Draw();
        }

        public void Update()
        {
            Food.GenerateFood();
            UpadateSnek();
        }

        public void Draw()
        {

            DrawBoard();

            DrawScore();

            ResetCursor();
        }

        public void DrawBoard()
        {
            HorizontalBorder();

            for (int i = 0; i < Height; i++)
            {
                Console.Write("|");
                for (int j = 0; j < Width; j++)
                {
                    switch (Board.boardPrimary[ i,j])
                    {
                        case BoardTiles.FREESPACE:
                            Console.Write("  ");
                            break;
                        case BoardTiles.FOOD:
                            Console.Write("@ ");
                            break;

                        case BoardTiles.SNEKHEAD_P1:
                            Console.Write("# ");
                            break;
                    }
                }Console.SetCursorPosition(Console.GetCursorPosition().Left-1, Console.GetCursorPosition().Top); Console.CursorVisible=false;
                Console.WriteLine("|");
            }
            HorizontalBorder();
        }

        public void HorizontalBorder()
        {
            Console.Write("+");
            for (int i = 0; i < Width - 1; i++)
                Console.Write("--");
            Console.WriteLine("-+");
        }

        public void DrawScore()
        {
            Console.WriteLine($"\nScore: {Score}" );
        }

        public static void ResetCursor()
        {
            Console.SetCursorPosition(0,0);
            Console.CursorVisible = false;
        }

        public void Wait()
        {
            int TimeOut = 1000 - 25 * Speed * Difficulty;
            if (TimeOut < 0)
            {
                TimeOut = 0;
            }

            Thread.Sleep(TimeOut);
        }

        public void UpadateSnek()
        {
            Snake.Direction  = GetDirection();
            Snake.Movement();
        }


        public MovementKeys GetDirection()
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        lastMove =  MovementKeys.UP;
                        break;
                    case ConsoleKey.A:
                        lastMove =  MovementKeys.LEFT;
                        break;
                    case ConsoleKey.S:
                        lastMove= MovementKeys.DOWN;
                        break;
                    case ConsoleKey.D:
                        lastMove= MovementKeys.RIGHT;
                        break;
                }
            }
            return lastMove;
        }

        public void END()
        {
            Active = false;
            Console.Clear();
            Console.WriteLine("GAME OVER");
            Console.ReadKey();

        }

    }
}
