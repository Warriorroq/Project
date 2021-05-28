using System;
using SFML.Graphics;
namespace Project.Game.AeroHokey
{
    public class Mine : GameObject
    {
        public Mine()
        {
            AddComponent(new ComponentCollide(this));
            var shape = new CircleShape(10) { OutlineColor = Color.Red, OutlineThickness = 1f };
            AddComponent(new ComponentRender(this, shape));
        }
        public override object Clone()
        {
            var clone = new Mine();
            CloneComponentsToObject(clone);
            return clone;
        }
    }
}
