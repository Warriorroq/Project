using SFML.Graphics;
using SFML.System;
namespace Project.Game.AeroHokey
{
    public class BallParticle : GameObject
    {
        protected float _liveTime;
        private float _Timer;
        private ComponentRender render;
        public BallParticle(Scene scene, Shape shape, Vector2f position, float liveTime) : base(scene)
        {
            render = new ComponentRender(this, shape, scene);
            AddComponent(render);
            this.position = position;
            _liveTime = liveTime;
            objTimer.Invoke(Destroy, _liveTime);
        }
        protected override void OnUpdate()
        {
            _Timer += objTimer.deltaTime;
            ChangeColor();
        }
        private void ChangeColor()
        {
            var color = render.shape.FillColor;
            color.A = (byte)(255 - 255 * (_Timer / _liveTime));
            render.shape.FillColor = color;
        }
    }
}
