using System;
using SFML.Graphics;
using SFML.System;
using Project.Game.AeroHokey;
using Project.Game.Zomb;
using Project.Debug;
using Project.Game.Components.Graph;
using Project.Game.GameObjects.AgarIo;
using SFML.Window;

namespace Project.Game
{
    public class Game : GameLoop
    {
        private Scene currentScene;
        public Game() : base("Aero hokey")
        {
            currentScene = new Scene(3);
            Screen.window.KeyPressed += AgarKeyPressed;
        }
        public override void Init()
        {
            GraphMaps.Init();
            Input.Init(gameTime);
            currentScene.Init();
            CreateAgar();
        }
        public override void LoadContent()
        {
            Fonts.LoadContent();
            DebugUtility.LoadContent(Fonts.CEAZAR);
        }
        public override void Update()
        {
            currentScene.Update();
        }
        public override void Draw()
        {
            currentScene.Draw();
            DebugFPS();
        }
        private void DebugFPS()
            => Debug($"FPS:{1 / gameTime.deltaTime:0.00}");
        private void AgarKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Space)
            {
                currentScene.GetObjectOfType<BigBallPlayer>()?.Destroy();
                currentScene.Add(new BigBallPlayer());
            }
        }
        private void CreateAgar()
        {
            var foodSpawner = new Spawner(currentScene);
            foodSpawner.Init(new Food(), .45f);
            currentScene.Add(foodSpawner);

            var ballsSpawner = new Spawner(currentScene);
            ballsSpawner.Init(new BigBallBot(), 7f);
            currentScene.Add(ballsSpawner);

            currentScene.Add(new BigBallBot());
            currentScene.Add(new BigBallPlayer());
        }
    }
}
