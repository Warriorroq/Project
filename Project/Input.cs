using SFML.Window;
using System;

namespace Project
{
    public static class Input
    {
        public static float Horisontal 
        {
            set
            {
                if (MathF.Abs(value) > 5f)
                    return;
                _horisontal = value;
            }
            get => _horisontal;
        }
        public static float Vertical
        {
            set
            {
                if (MathF.Abs(value) > 3.2f)
                    return;
                _vertical = value;
            }
            get => _vertical;
        }
        private static float _horisontal = 0;
        private static int _inputHorizontal = 0;
        private static float _vertical = 0;
        private static int _inputVertical = 0;
        public static void Init(Timer gameTimer)
        {
            Screen.window.KeyPressed += InputKey;
            Screen.window.KeyReleased += LetItGoKey;
            gameTimer.TimeUpdate += InputSides;
        }

        private static void LetItGoKey(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.D || e.Code == Keyboard.Key.A)
            {
                _inputVertical = 0;
                Vertical = 0;
            }
            if (e.Code == Keyboard.Key.S || e.Code == Keyboard.Key.W)
            {
                _inputHorizontal = 0;
                Horisontal = 0;
            }
        }

        private static void InputKey(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.D)
                _inputVertical = 1;
            else if(e.Code == Keyboard.Key.A)
                _inputVertical = -1;

            if (e.Code == Keyboard.Key.S)
                _inputHorizontal = 1;
            else if(e.Code == Keyboard.Key.W)
                _inputHorizontal = -1;
        }

        private static void InputSides(float time)
        {
            Horisontal += _inputHorizontal * time * 10f;
            Vertical += _inputVertical * time * 6.4f;
        }
    }
}
