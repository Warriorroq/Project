using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
namespace Project.Game.AeroHokey
{
    public class Mine : GameObject, ICloneable
    {
        private Scene _scene;
        public Mine(Scene scene) : base(scene)
        {
            _scene = scene;
            AddComponent(new ComponentCollide(this));
            var shape = new CircleShape(10) { OutlineColor = Color.Red, OutlineThickness = 1f };
            AddComponent(new ComponentRender(this, shape));
        }
        public object Clone()
        {
            var clone = new Mine(_scene);
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
