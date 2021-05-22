using SFML.System;
using SFML.Graphics;
using System;

namespace Project.Game.GameObjects.AgarIo
{
    public class BigBall : GameObject
    {
        public int TotalMass {
            get
                => startMass + mass;
            set
            {
                if (value < 0)
                    return;
                mass = value;
                UpdateSize();
            }
        }
        protected const int startMass = 20;
        private int mass;
        public BigBall()
        {
            var shape = new CircleShape();
            shape.FillColor = new Color().CreateRandom();
            var render = new ComponentRender(this, shape);
            AddComponent(render);
            AddComponent(new ComponentCollide(this));
            TotalMass = startMass;
        }
        public void AddBallMass(BigBall bigBall)
        {
            TotalMass += bigBall.mass / 8;
        }
        public override void OnCollisionWith(GameObject gameObject)
        {
            if (gameObject as BigBall is not null)
                CollideWith(gameObject as BigBall);
            else if (gameObject as Food is not null)
                CollideWith(gameObject as Food);
        }
        private void UpdateSize()
        {
            var render = GetComponent<ComponentRender>();
            (render.shape as CircleShape).Radius = TotalMass;
            render.shape.Origin = new Vector2f(mass, mass);
        }
        private void CollideWith(BigBall ball)
        {
            var changeMass = TotalMass - ball.TotalMass;
            if (changeMass > TotalMass / 10)
                EatBall(ball, changeMass);
        }
        private void EatBall(BigBall ball, int changeMass)
        {
            AddBallMass(ball);
            ball.Destroy();
        }
        private void CollideWith(Food food)
        {
            food.Destroy();
            TotalMass++;
        }
    }
}
