
using SFML.Graphics;
namespace Project.Game.AeroHokey
{
    public class Bg : GameObject
    {
        public Bg(Scene scene, Shape shape) : base(scene)
        {
            AddComponent(new ComponentRender(this, shape));
        }
    }
}
