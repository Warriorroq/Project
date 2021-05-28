using SFML.System;
using SFML.Window;
using System;

namespace Project.Game
{
    public class ComponentObjectClickAbility : Component
    {
        private Action<GameObject> _clickAction;
        public ComponentObjectClickAbility(GameObject owner, Action<GameObject> ClickAction) : base(owner)
        {
            Screen.window.MouseButtonPressed += GlobalClick;
            _clickAction = ClickAction;
        }
        private void GlobalClick(object sender, MouseButtonEventArgs e)
        {
            Vector2f mappedpos = Screen.window.MapPixelToCoords(new Vector2i(e.X, e.Y));
            var shape = owner.GetComponent<ComponentRender>().shape;
            if (shape.GetGlobalBounds().Contains(mappedpos.X, mappedpos.Y))
                _clickAction?.Invoke(owner);
        }
        protected override void OnDestroy()
        {
            Screen.window.MouseButtonPressed -= GlobalClick;
        }
    }
}
