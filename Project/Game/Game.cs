using System;
using SFML.Graphics;
using SFML.System;
using Project.Game.AeroHokey;
using Project.Game.DRAW;
using Project.Game.Zomb;
using Project.Debug;
using Project.Game.Components.Graph;
namespace Project.Game
{
    public class Game : GameLoop
    {
        public static Random random;
        private Scene currentScene;
        public Game() : base("Aero hokey")
        {
            random = new Random(DateTime.UtcNow.Second + DateTime.UtcNow.Minute * 60);
            currentScene = new Scene(3);
        }
        public override void Init()
        {
            GraphMaps.Init();
            currentScene.Init();
            CreateZomb();
            //CreateHokey();
            //CreateDrawer();
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
        private void CreateZomb()
        {
            var gameObject = new Zombie(currentScene);
            currentScene.Add(gameObject);
        }
        private void CreateDrawer()
        {
            var gameObject = new Drawer(currentScene);
            currentScene.Add(gameObject);
            Screen.window.SetMouseCursorVisible(false);
        }
        private void CreateHokey()
        {
            var bg = new Bg(currentScene, new RectangleShape(new Vector2f(Screen.widthWindow, Screen.heightWindow)));
            currentScene.Add(bg);
            var ball = new Ball(currentScene, new CircleShape(5)
            {
                FillColor = Color.Blue,
                Origin = new Vector2f(10, 10) / 2f
            });
            currentScene.Add(ball);
            var plate = new Plate(currentScene, new RectangleShape(new Vector2f(20, 100))
            {
                FillColor = Color.Black
            });
            currentScene.Add(plate);
            var bot = new PlateBot(currentScene, new RectangleShape(new Vector2f(20, 105))
            {
                FillColor = Color.Black
            });
            currentScene.Add(bot);
        }
    }
}
