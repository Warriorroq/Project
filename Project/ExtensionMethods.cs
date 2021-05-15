using SFML.Graphics;
using SFML.System;
using System;

namespace Project
{
    public static class ExtensionMethods
    {
        public static float Distance(this Vector2f value, Vector2f vector2)
            => MathF.Sqrt(MathF.Pow(vector2.Y - value.Y, 2)
                + MathF.Pow(vector2.X - value.X, 2));
        public static CircleShape Clone(this CircleShape shape) => new CircleShape(shape);
        public static RectangleShape Clone(this RectangleShape shape) => new RectangleShape(shape);
    }
}
