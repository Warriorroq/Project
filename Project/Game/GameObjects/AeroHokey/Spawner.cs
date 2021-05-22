using System;
using SFML.System;
namespace Project.Game.AeroHokey
{
    public class Spawner : GameObject
    {
        private GameObject _prefab;
        private Scene _scene;
        public Spawner(Scene scene)
        {
            _scene = scene;
        }
        public void Init(GameObject prefab, float time)
        {
            if(prefab is ICloneable)
            {
                _prefab = prefab;
                objTimer.InvokeRepeating(SpawnObject, 0f, time);
            }
        }
        private void SpawnObject()
        {
            var obj = (_prefab as ICloneable)?.Clone() as GameObject;
            obj.position = new Vector2f(Program.random.Next(0, (int)Screen.widthWindow),
                Program.random.Next(0, (int)Screen.heightWindow));
            _scene.Add(obj);
        }
    }
}
