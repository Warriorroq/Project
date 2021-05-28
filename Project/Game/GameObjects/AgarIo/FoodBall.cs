using Project.Game.Components.Agar;
using SFML.Graphics;
using SFML.System;
using System;
namespace Project.Game.GameObjects.AgarIo
{
    public class FoodBall : GameObject
    {
        public FoodBall()
        {
            position = new Vector2f(0, 100);

            AddComponent(new ComponentBallLogicMovement(this));
            AddComponent(new ComponentCollide(this));

            var render = new ComponentRender(this, new CircleShape(10));
            render.shape.Position = position;
            render.shape.FillColor = new Color().CreateRandom();
            AddComponent(render);

            var food = new ComponentFoodAbility(this, 50);
            food.massUpdate += ShapeUpdate;
            ShapeUpdate(food.RenderMass);
            AddComponent(food);
        }

        private void ShapeUpdate(float size)
        {
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
    }
}
