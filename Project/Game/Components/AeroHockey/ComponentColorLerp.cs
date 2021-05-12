using SFML.Graphics;
namespace Project.Game.AeroHokey
{
    public class ComponentColorLerp : Component
    {
        public float speed = 1f;
        private Color _deltaColor;        
        private Shape _shape;
        public ComponentColorLerp(GameObject parent, Shape shape, Color startColor, Color endColor, float time) : base(parent)
        {
            _shape = shape;
            _shape.FillColor = startColor;
            var color = endColor - startColor;
            var alfa = parent.objTimer.deltaTime / time * speed;
            color.A = (byte)(color.A * alfa * 2);
            color.R = (byte)(color.R * alfa * 2);
            color.G = (byte)(color.G * alfa * 2);
            color.B = (byte)(color.B * alfa * 2);
            _deltaColor = color;
        }
        public override void Update()
        {
            _shape.FillColor += _deltaColor;
        }
    }
}
