using System;

namespace Project.Game.Components.Agar
{
    public class ComponentFoodAbility : Component
    {
        public event Action<int> massUpdate;
        public int TotalMass
        {
            get
                => _startMass + _mass;
            set
            {
                if (value < 0)
                    return;
                _mass = value;
                massUpdate?.Invoke(TotalMass);
            }
        }
        private int _startMass;
        private int _mass;
        public ComponentFoodAbility(GameObject owner, int startWeight) : base(owner)
        {
            _startMass = startWeight;
        }            
        public void EatObject(ComponentFoodAbility foodAbility)
        {
            if (TotalMass - foodAbility.TotalMass > foodAbility.TotalMass / 5)
            {
                TotalMass += foodAbility._mass;
                foodAbility.owner.Destroy();
            }
        }
    }
}
