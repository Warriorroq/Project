using SFML.Graphics;
using SFML.System;
namespace Project.Game.Zomb
{
    public class Player : GameObject
    {
        public Player(Scene scene) : base(scene)
        {
            var a = new CircleShape(20)
            {
                Origin = new Vector2f(20, 20) / 2,
                FillColor = Color.Blue,
            };
            AddComponent(new ComponentRender(this, a, scene));
        }
        protected override void OnUpdate()
        {
            position += new Vector2f(Input.Vertical * 100f, Input.Horisontal * 100f) * objTimer.deltaTime;
        }
    }
}
