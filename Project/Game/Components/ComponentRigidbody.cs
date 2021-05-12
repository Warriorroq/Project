using SFML.System;
using System;

namespace Project.Game
{
    public sealed class ComponentRigidbody : Component
    {
        public Vector2f Velocity {
            get => _velocity;
        }
        private Vector2f _gravityVector;
        private Vector2f _velocity;
        public ComponentRigidbody(GameObject parent) : base(parent)
        {
            _gravityVector = new Vector2f(0f, 100f);
        }
        public void SetVelocity(Vector2f newVelocity)
            => _velocity = newVelocity;
        public sealed override void Update()
        {
            owner.position += _velocity * owner.objTimer.deltaTime;
            _velocity += _gravityVector * owner.objTimer.deltaTime;
        }
    }
}
