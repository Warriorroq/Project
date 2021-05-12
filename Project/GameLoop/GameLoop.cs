using System;
using SFML.Window;
using SFML.Graphics;
using Project.Debug;
namespace Project
{
    public abstract class GameLoop
    {
        public const int FPS = 145;
        public const float updateTime = 1f / FPS;
        public Timer gameTime;
        protected GameLoop(string nameOfTheWindow)
        {
            Screen.window = new RenderWindow(new VideoMode(Screen.widthWindow, Screen.heightWindow), nameOfTheWindow);
            Screen.window.Closed += WindowClosed;
            gameTime = new Timer();
        }
        public void Start()
        {

            LoadContent();
            Init();
            gameTime.Init(updateTime);
            while (Screen.window.IsOpen) {
                Screen.window.DispatchEvents();
                if (gameTime.IsUpdate()) {
                    Update();

                    Screen.window.Clear(Color.White);
                    Draw();
                    Screen.window.Display();
                }
            }
        }
        private void WindowClosed(object sender, EventArgs e)
            => Screen.window.Close();

        public abstract void LoadContent();
        public abstract void Init();
        public abstract void Update();
        public abstract void Draw();
        public void Debug(object message)
            => DebugUtility.Message(message);
    }
}
