using System;
using SFML.Graphics;
namespace Project.Game.AeroHokey
{
    public class Mine : GameObject, ICloneable
    {
        public Mine()
        {
            AddComponent(new ComponentCollide(this));
            var shape = new CircleShape(10) { OutlineColor = Color.Red, OutlineThickness = 1f };
            AddComponent(new ComponentRender(this, shape));
        }
        public object Clone()
        {
            var clone = new Mine();
            foreach (var component in _components)
            {
                var newComponent = component.Clone();
                (newComponent as Component).SetOwner(clone);
                clone.AddComponent(newComponent as Component);
            }
            return clone;
        }
    }
}
