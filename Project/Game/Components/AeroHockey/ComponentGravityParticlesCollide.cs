using SFML.Graphics;
using SFML.System;
using System;

namespace Project.Game.AeroHokey
{
    public class ComponentGravityParticlesCollide : Component
    {
        private Scene _scene;
        private int _particles;
        public ComponentGravityParticlesCollide(GameObject parent, Scene scene, int particles) : base(parent)
        {
            _scene = scene;
            _particles = particles;
        }
        public void CreateParticles()
            => AddParticlesToScreen(_scene, _particles);
        private void AddParticlesToScreen(Scene scene, int particles)
        {
            for (int i = 0; i < particles; i++)
            {
                scene.Add(new BallParticleWithGravity(
                    scene,
                    new CircleShape(5)
                        {
                            FillColor = Color.Magenta,
                            Origin = new Vector2f(10, 10) / 2f
                        },
                    owner.position, 
                    3f)
                    );
            }
        }
    }
}
