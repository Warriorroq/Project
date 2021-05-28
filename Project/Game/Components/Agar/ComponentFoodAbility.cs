using System;
using SFML.Graphics;
namespace Project.Game.Components.Agar
{
    public class ComponentFoodAbility : Component
    {
        public event Action<float> massUpdate;
        public float TotalMass
        {
            get
                => _startMass + mass;
            set
            {
                if (value < 0)
                    return;
                mass = value;
                massUpdate?.Invoke(RenderMass);
            }
        }
        public float RenderMass => _startMass + mass * 0.1f;
        public float mass;
        private const int _startMass = 10;
        public ComponentFoodAbility(GameObject owner, float startWeight) : base(owner)
        {
            mass = startWeight;
        }            
        public void EatObject(ComponentFoodAbility foodAbility)
        {
            /*var objDistances = owner.position.DistanceWithOutSqrt(foodAbility.owner.position);
            var shape = foodAbility.owner.GetComponent<ComponentRender>().shape as CircleShape;
            var ownerShape = owner.GetComponent<ComponentRender>().shape as CircleShape;*/
            if (TotalMass - foodAbility.TotalMass > foodAbility.TotalMass / 5)
            {
                //if (objDistances < MathF.Pow(ownerShape.Radius - shape.Radius / 2f, 2)) {
                    TotalMass += foodAbility.mass;
                    foodAbility.owner.Destroy();
                //}
            }
        }
    }
}