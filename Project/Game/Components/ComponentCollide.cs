using SFML.Graphics;

namespace Project.Game
{
    public class ComponentCollide : Component
    {

        public ComponentCollide(GameObject parent) : base(parent) { }
        public void Collide(GameObject gameObject)
        {
            var bounds = GetBounds(gameObject);
            if (GetBounds(owner).Intersects(bounds))
                owner.OnCollisionWith(gameObject);
        }
        public FloatRect GetBounds(GameObject obj)
            => obj.GetComponent<ComponentRender>().shape.GetGlobalBounds();
        public override object Clone()
            => new ComponentCollide(null);
    }
}
