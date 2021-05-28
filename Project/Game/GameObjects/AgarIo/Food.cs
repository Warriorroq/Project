using System;
using SFML.Graphics;
using SFML.System;
using Project.Game.Components.Agar;
namespace Project.Game.GameObjects.AgarIo
{
    public class Food : GameObject
    {
        public static int foodCount;
        public Food()
        {
            var food = new ComponentFoodAbility(this, 1);
            AddComponent(food);
            AddComponent(new ComponentCollide(this));
            var render = new ComponentRender(this, new CircleShape(10) {Origin = new Vector2f(10,10) });
            render.shape.FillColor = new Color().CreateRandom();
            AddComponent(render);
            objTimer.Init(1f);
        }
        protected override void OnSceneBind(Scene scene)
        {
            foodCount++;
        }
        protected override void OnDestroy()
        {
            foodCount--;
        }
        public override object Clone()
        {
            return new Food();
        }
    }
}
