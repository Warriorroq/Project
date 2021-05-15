using System;
using SFML.System;
namespace Project.Game.AeroHokey
{
    public class Spawner : GameObject
    {
        private GameObject _prefab;
        private Scene _scene;
        public Spawner(Scene scene) : base(scene)
        {
            _scene = scene;
        }
        public void Init(GameObject gameObject)
        {
            if(gameObject is ICloneable)
            {
                _prefab = gameObject;
                objTimer.InvokeRepeating(SpawnMine, 0f, 1f);
            }
        }
        private void SpawnMine()
        {
            var obj = (_prefab as ICloneable)?.Clone() as GameObject;
            obj.CreateSceneBind(_scene);
            obj.position = new Vector2f(Game.random.Next(0, (int)Screen.widthWindow), 
                Game.random.Next(0, (int)Screen.heightWindow));
            _scene.Add(obj);
        }
    }
}
