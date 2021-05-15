using SFML.Graphics;
using SFML.System;
namespace Project.Game
{
    public class ComponentRender : Component
    {
        public Shape shape;
        public int layer;
        public ComponentRender(GameObject parent ,Shape shape) : base(parent)
        {
            this.shape = shape;
        }
        public override void Update()
            =>shape.Position = owner.position;
        public virtual void Draw()
            =>Screen.window.Draw(shape);
        public override object Clone()
        {   
            Shape shapeClone = shape as RectangleShape is null ? 
                (shape as CircleShape).Clone() : (shape as RectangleShape).Clone();
            var clone = new ComponentRender(null, shapeClone);
            clone.layer = layer;
            return clone;
        }
    }
}
