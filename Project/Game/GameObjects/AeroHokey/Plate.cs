using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Project.Game.AeroHokey
{
    public class Plate : GameObject
    {
        protected float _speed = Screen.heightWindow;
        protected float _deltaSpeed = 0f;
        public float directionScale;
        public Plate(Shape shape) : base()
        {
            AddComponent(new ComponentCollide(this));
            AddComponent(new ComponentRender(this, shape) { layer = 1 });
            position = new Vector2f(50, 300);
            directionScale = 1f;
            Screen.window.KeyPressed += VelocityWithKey;
        }
        private void VelocityWithKey(object sender, KeyEventArgs e)
        {
            if(e.Code.Equals(Keyboard.Key.S))
                _deltaSpeed = _speed * objTimer.deltaTime;
            
            else if(e.Code.Equals(Keyboard.Key.W))
                _deltaSpeed = -_speed * objTimer.deltaTime;
        }
        protected override void OnUpdate()
        {
            if (position.Y + _deltaSpeed + 100 > Screen.heightWindow || position.Y + _deltaSpeed < 0)
                _deltaSpeed = 0;
           
            position.Y += _deltaSpeed * directionScale;
        }
        protected override void OnDestroy()
        {
            Screen.window.KeyPressed -= VelocityWithKey;
        }
        public override void OnCollisionWith(GameObject gameObject)
        {
            if (IsMine(gameObject))
            {
                directionScale = 0.1f;
                gameObject.Destroy();
                objTimer.Invoke(ResumeMoving, 2f);
            }
        }
        public bool IsMine(GameObject gameObject)
            => gameObject as Mine is not null;
        public void ResumeMoving()
            => directionScale = 1f;
    }
}
