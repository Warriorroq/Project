using System;
using System.Collections.Generic;

namespace Project.Game
{
    public abstract class Component : ICloneable
    {
        public GameObject owner;
        public Component(GameObject owner)
        {
            this.owner = owner;
        }
        public void SetOwner(GameObject newOwner)
            => owner = newOwner;
        public virtual void Update() { }
        public void Destroy() {
            OnDestroy();
        }
        public virtual object Clone() => throw new Exception("Cloning uncloanable");
        protected virtual void OnDestroy() { }
    }
}
