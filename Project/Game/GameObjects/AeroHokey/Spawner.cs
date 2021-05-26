using System;
using SFML.System;
using System.Linq;
using System.Collections.Generic;

namespace Project.Game.AeroHokey
{
    public class Spawner : GameObject
    {
        private GameObject _prefab;
        private Scene _scene;
        private List<Action<GameObject>> _SpawnActions;
        public Spawner(Scene scene)
        {
            _scene = scene;
        }
        public void Init(GameObject prefab, float time, params Action<GameObject>[] spawnActions)
        {
            if(prefab is ICloneable)
            {
                _SpawnActions = new(spawnActions);
                _prefab = prefab;
                objTimer.InvokeRepeating(SpawnObject, 0f, time);
            }
        }
        private void SpawnObject()
        {
            var obj = (_prefab as ICloneable)?.Clone() as GameObject;
            _scene.Add(obj);
            _SpawnActions.ForEach(x => x.Invoke(obj));
        }
    }
}
