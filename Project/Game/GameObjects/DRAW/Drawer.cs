﻿using SFML.Window;
using SFML.Graphics;
using SFML.System;
using Project.Game.AeroHokey;
using System;

namespace Project.Game.DRAW
{
    public class Drawer : GameObject
    {
        public Drawer(Scene scene) : base(scene)
        {
            Screen.window.MouseMoved += Moved;
            objTimer.Init(1f/40f);
            AddComponent(new ComponentRender(this, new CircleShape(5) { FillColor = Color.Black, Origin = new Vector2f(10, 10) / 2f }, scene) {layer = 2 });
            AddComponent(new ComponentGravityParticlesCollide(this, scene, 1));
        }
        private void Moved(object sender, MouseMoveEventArgs e)
        {
            position.X = e.X;
            position.Y = e.Y;
            GetComponent<ComponentGravityParticlesCollide>().CreateParticles();
        }
    }
}
