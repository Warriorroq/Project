using SFML.System;
using System;

namespace Project.Game.Components.Agar
{
    public class ComponentBallLogicMovement : Component
    {
        private Vector2f _velocity;
        private float _speed;
        public ComponentBallLogicMovement(GameObject owner) : base(owner)
        {
            _velocity = Program.random.RandomVector(new Vector2i(-90, -90), new Vector2i(90, 90));
            _speed = 3;
        }
        public override void Update()
        {
            owner.position += _velocity * owner.objTimer.deltaTime * _speed;
            if (owner.position.X > 2560 || owner.position.X < 0)
                _velocity.X *= -1f;

            if (owner.position.Y > 1440 || owner.position.Y < 0)
                _velocity.Y *= -1f;
        }
    }
}
