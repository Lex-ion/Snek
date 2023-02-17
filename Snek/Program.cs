namespace Snek
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Game snekGame = new Game(16,16,1,1,1);
            Console.WriteLine("Hello, World!");
            snekGame.Start();
            while (snekGame.Active)
            {
                try { snekGame.Loop(); } catch { snekGame.END(); }
                
            }

        }
    }
}