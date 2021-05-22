using SFML.Window;
using System;

namespace Project.Game.GameObjects.AgarIo
{
    public class BigBallPlayer : BigBall
    {
        public BigBallPlayer()
        {
            Screen.window.MouseMoved += MouseMoved;
        }
        private void MouseMoved(object sender, MouseMoveEventArgs e)
        {
            position.X = e.X;
            position.Y = e.Y;
        }
    }
}
