using SFML.System;
using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace Project.Game
{
    public abstract class GameObject
    {
        public Vector2f position;
        public Action Destroy;
        public event Action<GameObject> Collision;
        public Timer objTimer;
        protected List<Component> _components;
        public GameObject(Scene scene)
        {
            objTimer = new Timer();
            _components = new List<Component>();
            if(!(scene is null)) {
                CreateSceneBind(scene);
            }
            else {
                Destroy = OnDestroy;
            }
        }
        public void Update()
        {
            if (objTimer.IsUpdate())
            {
                foreach (var component in _components)
                    component.Update();
                OnUpdate();
            }
        }
        public void AddComponent(Component component)
            =>_components?.Add(component);
        public T GetComponent<T>() where T : Component
        {
            foreach(var component in _components) {
                if (component.GetType() == typeof(T))
                    return component as T;
            }
            return default(T);
        }
        public Component GetChildComponent<T>() where T : Component
        {
            foreach (var component in _components) {
                if (component is T)
                    return component;
            }
            return default(T);
        }
        public void RemoveComponent<T>() where T : Component
            => _components?.Remove(GetComponent<T>());
        public void RemoveChildComponent<T>() where T : Component
            =>_components?.Remove(GetChildComponent<T>());
        public virtual void OnCollisionWith(GameObject gameObject)
            =>Collision?.Invoke(gameObject);
        public void CreateSceneBind(Scene scene)
        {
            OnSceneBind(scene);
            scene.update += Update;
            Destroy = (() => {
                _components.ForEach(x => x.Destroy());
                scene.Destroy(this);
                scene.update -= Update;
                OnDestroy();
            });
        }
        protected virtual void OnSceneBind(Scene scene) {}
        protected virtual void OnDestroy(){}
        protected virtual void OnUpdate(){}

    }
}
