using System;

namespace Project
{
    class Program
    {
        public static Random random;
        static void Main(string[] args)
        {
            random = new Random(DateTime.UtcNow.Second + DateTime.UtcNow.Minute * 60);
            new Game.Game().Start();
        }
    }
}
