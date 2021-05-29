using SFML.System;
using SFML.Window;
using System;

namespace Project.Game.Components.Agar
{
    public class ComponentPlayerMovemetLogic : Component
    {
        private Vector2f _velocity;
        private Scene _scene;
        public ComponentPlayerMovemetLogic(GameObject owner, Scene scene) : base(owner)
        {
            Screen.window.MouseButtonPressed += ButtonUsed;
            _scene = scene;
        }
        private void ButtonUsed(object sender, MouseButtonEventArgs e)
        {
            if(e.Button == Mouse.Button.Right)
            {
                CreateNewAngle(Screen.window.MapPixelToCoords(new Vector2i(e.X, e.Y)));
            }
        }
        public override void Update()
        {
            owner.position += _velocity * owner.objTimer.deltaTime;
        }
        private void CreateNewAngle(Vector2f pos)
        {
            _velocity = (pos - owner.position);
        }
        public override object Clone()
        {
            var clone = new ComponentPlayerMovemetLogic(null, _scene);
            clone._velocity = _velocity;
            return clone;
        }
    }
}
