using SFML.System;
using SFML.Window;
using System;

namespace Project.Game.Components.Agar
{
    public class ComponentPlayerMovemetLogic : Component
    {
        private Vector2f _velocity;
        public ComponentPlayerMovemetLogic(GameObject owner) : base(owner)
        {
            Screen.window.MouseButtonPressed += ButtonUsed;
        }

        private void ButtonUsed(object sender, MouseButtonEventArgs e)
        {
            if(e.Button == Mouse.Button.Right)
            {
                CreateNewAngle(new Vector2f(e.X, e.Y));
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
    }
}
