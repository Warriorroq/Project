using System;
using Project.Game.AeroHokey;
using Project.Debug;
using Project.Game.Components.Graph;
using Project.Game.GameObjects.AgarIo;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
namespace Project.Game
{
    public class Game : GameLoop
    {
        private Scene currentScene;
        public Game() : base("Aero hokey")
        {
            Screen.window.SetView(new View(new Vector2f(1280, 720), new Vector2f(2560, 1440)));
            currentScene = new Scene(3);
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
        private void CreateAgar()
        {
            var foodSpawner = new Spawner(currentScene);
            foodSpawner.Init(new Food(), .05f, 
                obj => obj.position = Program.random.RandomVector(new Vector2i(20, 20), new Vector2i(2540, 1420)), 
                obj => { if (Food.foodCount > 200) obj?.Destroy(); });
            for(int i =0;i<10;i++)
                currentScene.Add(new FoodBall());
            currentScene.Add(foodSpawner);
        }
    }
}
