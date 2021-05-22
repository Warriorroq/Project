using SFML.System;
using System;

namespace Project.Game.GameObjects.AgarIo
{
    public class BigBallBot : BigBall, ICloneable
    {
        public Vector2f direction;
        public float directionScale;
        public BigBallBot()
        {
            direction = new Vector2f(Program.random.Next(100, 300), Program.random.Next(100, 300));
            directionScale = 0.7f;
        }
        public object Clone()
        {
            var newBall = new BigBallBot();
            newBall.TotalMass = TotalMass;
            return newBall;
        }
        protected override void OnUpdate()
        {
            position += direction * objTimer.deltaTime * directionScale;
            if (position.X > Screen.widthWindow || position.X < 0)
                direction.X *= -1f;

            if (position.Y > Screen.heightWindow || position.Y < 0)
                direction.Y *= -1f;
        }
    }
}
