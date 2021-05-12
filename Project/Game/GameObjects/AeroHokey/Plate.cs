﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;
namespace Project.Game.AeroHokey
{
    public class Plate : GameObject
    {
        protected float _speed = Screen.heightWindow;
        protected float _deltaSpeed = 0f;
        public Plate(Scene scene, Shape shape) : base(scene)
        {
            AddComponent(new ComponentCollide(this));
            AddComponent(new ComponentRender(this, shape, scene) { layer = 1 });
            position = new Vector2f(50, 300);
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
           
            position.Y += _deltaSpeed;
        }
        protected override void OnDestroy()
        {
            Screen.window.KeyPressed -= VelocityWithKey;
        }
    }
}
