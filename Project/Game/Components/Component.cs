using System;
using System.Collections.Generic;

namespace Project.Game
{
    public abstract class Component
    {
        public GameObject owner;
        public Action OnDestroy;
        public Component(GameObject owner)
        {
            this.owner = owner;
        }
        public virtual void Update() { }
        public void Destroy() {
            OnDestroy?.Invoke();
        }
    }
}
