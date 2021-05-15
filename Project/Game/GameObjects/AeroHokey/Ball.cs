using SFML.Graphics;
using SFML.System;
namespace Project.Game.AeroHokey
{
    public class Ball : GameObject
    {
        public Vector2f direction;
        public float directionScale;
        public Ball(Scene scene, Shape shape)
        {
            AddComponent(new ComponentCollide(this));
            AddComponent(new ComponentFollowParticlesEffect(this, scene));
            AddComponent(new ComponentGravityParticlesCollide(this, scene, 40));
            AddComponent(new ComponentRender(this, shape) { layer = 1 });
            directionScale = 1;
            position = new Vector2f(200, 200 + Game.random.Next(50, 200));
            direction = new Vector2f(Game.random.Next(100, 700), Game.random.Next(100,500));
        }
        protected override void OnUpdate()
        {
            position += direction * objTimer.deltaTime * directionScale;
            if (position.X > Screen.widthWindow || position.X < 0)
                direction.X *= -1f;

            if (position.Y > Screen.heightWindow || position.Y < 0)
                direction.Y *= -1f;
        }
        public override void OnCollisionWith(GameObject gameObject)
        {
            if (gameObject is Plate || gameObject is PlateBot)
            {
                GetComponent<ComponentGravityParticlesCollide>().CreateParticles();
                direction.X *= -1;
                position.X += direction.X * 2 * objTimer.deltaTime;
            }
            if(IsMine(gameObject))
            {
                GetComponent<ComponentGravityParticlesCollide>().CreateParticles();
                gameObject.Destroy();
                directionScale = 0;
                objTimer.Invoke(ResumeMoving, 2f);
            }
        }
        public bool IsMine(GameObject gameObject)
            => gameObject as Mine is not null;
        public void ResumeMoving()
            => directionScale = 1f;
    }
}
