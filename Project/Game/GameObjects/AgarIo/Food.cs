using System;
using SFML.Graphics;
namespace Project.Game.GameObjects.AgarIo
{
    public class Food : GameObject, ICloneable
    {
        public Food()
        {
            AddComponent(new ComponentCollide(this));
            var render = new ComponentRender(this, new CircleShape(10));
            render.shape.FillColor = new Color().CreateRandom();
            AddComponent(render);
        }
        public object Clone()
        {
            return new Food();
        }
    }
}
