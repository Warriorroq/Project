
using SFML.Graphics;
namespace Project.Game.AeroHokey
{
    public class Bg : GameObject
    {
        public Bg(Shape shape)
        {
            AddComponent(new ComponentRender(this, shape));
        }
    }
}
