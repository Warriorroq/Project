using SFML.Graphics;
using SFML.System;

namespace Project.Game.AeroHokey
{
    class BallParticleWithGravity : BallParticle
    {
        public BallParticleWithGravity(Shape shape, Vector2f position, float liveTime) : base(shape, position, liveTime)
        {
            var rigitBody = new ComponentRigidbody(this);
            GetComponent<ComponentRender>().shape.FillColor = Color.Magenta;
            rigitBody.SetVelocity(new Vector2f(Game.random.Next(-80, 80), Game.random.Next(-90, -10)));
            AddComponent(rigitBody);
            objTimer.TimeScale = 1.33f;
            objTimer.Init(60f);
        }
    }
}
