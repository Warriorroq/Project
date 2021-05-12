using SFML.Graphics;

namespace Project.Game
{
    public class ComponentRender : Component
    {
        public Shape shape;
        public int layer;
        public ComponentRender(GameObject parent ,Shape shape, Scene scene) : base(parent)
        {
            this.shape = shape;
        }
        public override void Update()
            =>shape.Position = owner.position;
        public virtual void Draw()
            =>Screen.window.Draw(shape);
    }
}
