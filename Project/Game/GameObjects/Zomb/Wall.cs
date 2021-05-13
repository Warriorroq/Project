using SFML.Graphics;
using SFML.System;

namespace Project.Game.Zomb
{
    public class Wall : GameObject
    {
        public Wall(Scene scene) : base(scene)
        {
            position = new Vector2f(400, 400);
            var a = new RectangleShape(new Vector2f(200, 200))
            {
                FillColor = Color.Black,
            };
            AddComponent(new ComponentRender(this, a, scene));
        }
    }
}
