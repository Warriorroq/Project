using System;
using SFML.Graphics;
using SFML.System;
using Project.Game.AeroHokey;
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
            Input.Init(gameTime);
            currentScene.Init();
            //CreateZomb();
            CreateHokey();
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
            Debug(currentScene.Count);
            //DebugFPS();
        }
        private void DebugFPS()
            => Debug($"FPS:{1 / gameTime.deltaTime:0.00}");
        private void CreateZomb()
        {
            var player = new Player();
            var wall = new Wall();
            currentScene.Add(player);
            currentScene.Add(wall);
            var gameObject = new Zombie(currentScene);
            currentScene.Add(gameObject);
        }
        private void CreateHokey()
        {
            var ball = new Ball(
                new CircleShape(5)
            {
                FillColor = Color.Blue,
                Origin = new Vector2f(10, 10) / 2f
            });
            currentScene.Add(ball);

            var plate = new Plate(new RectangleShape(new Vector2f(20, 100))
            {
                FillColor = Color.Black
            });
            currentScene.Add(plate);

            var spawner = new Spawner(currentScene);

            var bomb = new Mine();
            spawner.InfiniteCreateObjectsStart(bomb);

            currentScene.Add(spawner);

            var bot = new PlateBot(new RectangleShape(new Vector2f(20, 105))
            {
                FillColor = Color.Black
            });
            currentScene.Add(bot);
        }
    }
}
