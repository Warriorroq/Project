using SFML.Graphics;
using SFML.System;
using System;
using Project.Game;
namespace Project
{
    public static class ExtensionMethods
    {
        public static float Distance(this Vector2f value, Vector2f value2)
            => MathF.Sqrt(MathF.Pow(value2.Y - value.Y, 2)
                + MathF.Pow(value2.X - value.X, 2));
        public static float DistanceWithOutSqrt(this Vector2f value, Vector2f value2)
            => MathF.Pow(value2.Y - value.Y, 2) + MathF.Pow(value2.X - value.X, 2);
        public static byte NextByte(this Random random)
            => (byte)random.Next(0, 256);
        public static CircleShape Clone(this CircleShape shape) => new CircleShape(shape);
        public static RectangleShape Clone(this RectangleShape shape) => new RectangleShape(shape);
        public static Color CreateRandom(this Color color)
            => new Color(Program.random.NextByte(), Program.random.NextByte(), Program.random.NextByte());
        public static Vector2f RandomVector(this Random random, Vector2i min, Vector2i max)
        {
            Vector2f vector;
            vector.X = random.Next(min.X, max.X);
            vector.Y = random.Next(min.Y, max.Y);
            return vector;
        }
    }
}
