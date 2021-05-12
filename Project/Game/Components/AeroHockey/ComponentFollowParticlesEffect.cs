using SFML.Graphics;
using SFML.System;
using System;
namespace Project.Game.AeroHokey
{
    public class ComponentFollowParticlesEffect : Component
    {
        private Scene _scene;
        public ComponentFollowParticlesEffect(GameObject parent, Scene scene) : base(parent)
        {
            _scene = scene;
            parent.objTimer.InvokeRepeating(CreateBall, 0f, 0.1f);
        }
        public void CreateBall()
        {
            _scene.Add(new BallParticle(
                _scene,
                new CircleShape(5)
                {
                    FillColor = Color.Black,
                    Origin = new Vector2f(10, 10) / 2f
                }, 
                owner.position, 
                3f)
                );
        }
    }
}
