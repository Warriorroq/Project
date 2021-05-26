using Project.Game.Components.Agar;
using SFML.Graphics;
using SFML.System;
using System;
namespace Project.Game.GameObjects.AgarIo
{
    public class FoodBall : GameObject
    {
        private Vector2f _velocity;
        private float _speed;
        public FoodBall()
        {
            _speed = 3;
            _velocity = Program.random.RandomVector(new Vector2i(-90, -90), new Vector2i(90, 90));
            AddComponent(new ComponentCollide(this));

            var render = new ComponentRender(this, new CircleShape(10));
            position = new Vector2f(0, 100);
            render.shape.Position = position;
            render.shape.FillColor = new Color().CreateRandom();
            AddComponent(render);

            var food = new ComponentFoodAbility(this, Program.random.Next(20, 40));
            food.massUpdate += ShapeUpdate;
            AddComponent(food);
        }

        private void ShapeUpdate(int size)
        {
            Console.WriteLine(size);
            var shape = GetComponent<ComponentRender>().shape as CircleShape;
            shape.Radius = size;
            shape.Origin = new Vector2f(size, size);
        }

        public override void OnCollisionWith(GameObject gameObject)
        {
            var food = gameObject.GetComponent<ComponentFoodAbility>();
            var myFood = GetComponent<ComponentFoodAbility>();
            if (food is not null && food.TotalMass < myFood.TotalMass)
            {
                myFood.EatObject(food);
            }
        }
        protected override void OnUpdate()
        {
            position += _velocity * objTimer.deltaTime * _speed;
            if (position.X > 2560 || position.X < 0)
                _velocity.X *= -1f;

            if (position.Y > 1440 || position.Y < 0)
                _velocity.Y *= -1f;
        }
    }
}
