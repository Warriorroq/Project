using System;
using System.Collections.Generic;
using System.Linq;
namespace Project.Game
{
    public class Scene
    {
        public event Action update;
        public int Count => _objects.Count;

        protected List<List<ComponentRender>> _renderComponents;
        protected int maxLayer = 3;

        private List<GameObject> _objects;
        private List<GameObject> _objectsForDestroy;
        public Scene(int maxLayer)
        {
            this.maxLayer = maxLayer;
        }
        public void Init()
        {
            _renderComponents = new();
            for(int layer=0; layer<maxLayer; layer++)
                _renderComponents.Add(new List<ComponentRender>());
            _objects = new();
            _objectsForDestroy = new();
        }
        public void Update()
        {
            update?.Invoke();
            CheckCollisions();
            DestroyObjects();
        }
        public void Draw()
        {
            for (int layer = 0; layer < maxLayer; layer++)
                _renderComponents[layer].ForEach(x => x.Draw());
        }
        public void Add(GameObject obj)
        {
            _objects.Add(obj);
            var render = obj.GetComponent<ComponentRender>();
            if (render is not null)
                _renderComponents[render.layer].Add(render);
        }
        public void Destroy(GameObject obj)
            =>_objectsForDestroy.Add(obj);
        private void CheckCollisions()
        {
            var colliders = _objects.Where(x => !(x.GetComponent<ComponentCollide>() is null)).Select(x => x.GetComponent<ComponentCollide>()).ToArray();
            foreach (var obj1 in colliders) {
                foreach (var obj2 in colliders) {
                    if(obj1 != obj2)
                        obj1.Collide(obj2.owner);
                }
            }
        }
        private void DestroyObjects()
        {
            foreach(var obj in _objectsForDestroy)
            {
                _objects.Remove(obj);
                var render = obj.GetComponent<ComponentRender>();
                if (render is not null)
                    _renderComponents[render.layer].Remove(render);
            }
            _objectsForDestroy.Clear();
        }
    }
}
