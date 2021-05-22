﻿using SFML.Graphics;
using SFML.System;
using System;
using Project.Game;
namespace Project
{
    public static class ExtensionMethods
    {
        public static float Distance(this Vector2f value, Vector2f vector2)
            => MathF.Sqrt(MathF.Pow(vector2.Y - value.Y, 2)
                + MathF.Pow(vector2.X - value.X, 2));
        public static byte NextByte(this Random random)
            => (byte)random.Next(0, 256);
        public static CircleShape Clone(this CircleShape shape) => new CircleShape(shape);
        public static RectangleShape Clone(this RectangleShape shape) => new RectangleShape(shape);
        public static Color CreateRandom(this Color color)
            => new Color(Program.random.NextByte(), Program.random.NextByte(), Program.random.NextByte());
    }
}
