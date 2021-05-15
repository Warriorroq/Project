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
        public Mine() : base(null)
        {
            AddComponent(new ComponentCollide(this));
        }
        protected override void OnSceneBind(Scene scene)
        {
            _scene = scene;
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
            clone.CreateSceneBind(_scene);
            return clone;
        }
    }
}
