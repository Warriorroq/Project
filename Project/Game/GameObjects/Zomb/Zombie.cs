using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
namespace Project.Game.Zomb
{
    public class Zombie : GameObject
    {
        private ComponentNavAgent navigation;
        private Vector2f direction;
        private Vector2f velocity;
        public Zombie(Scene scene) : base(scene)
        {
            navigation = new ComponentNavAgent(this);
            AddComponent(navigation);
            var a = new CircleShape(20)
            {
                Origin = new Vector2f(20, 20) / 2,
                FillColor = Color.Black,
            };
            AddComponent(new ComponentRender(this, a, scene));
            navigation.FindPath(new Vector2f(600, 600));
            foreach (var obj in navigation.path)
                Console.WriteLine(obj);
            GetPoint();
        }
        protected override void OnUpdate()
        {
            position += velocity * objTimer.deltaTime;
            if (position.Distance(direction) < 5f)
                GetPoint();
        }
        private void GetPoint()
        {
            if(navigation.path.Count != 0)
            {
                direction = navigation.GetNextPoint();
                velocity = (direction - position);
            }
            else
            {
                velocity.X = 0;
                velocity.Y = 0;
            }
        }
    }
}
