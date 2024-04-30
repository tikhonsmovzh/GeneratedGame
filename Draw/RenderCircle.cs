using GeneratedGame.Units;
using SFML.Graphics;

namespace GeneratedGame.Draw
{
    internal class RenderCircle : IDrawable
    {
        public Drawable GetTransformable(float aspect)
        {
            var shape = new CircleShape(_shape);

            shape.Scale = new SFML.System.Vector2f(_shape.Scale.X * aspect, _shape.Scale.Y);
            shape.Position = new SFML.System.Vector2f(_shape.Position.X * aspect, _shape.Position.Y);

            return shape;
        }

        private readonly CircleShape _shape;

        public float Radius
        {
            get => _shape.Radius;
            set => _shape.Radius = value;
        }

        public Vector2Float Position
        {
            get => new Vector2Float(_shape.Position);
            set => _shape.Position = new SFML.System.Vector2f(value.X, value.Y);
        }

        public RenderCircle(float radius, Vector2Float position)
        {
            _shape = new CircleShape();

            Radius = radius;
            Position = position;
        }
    }
}
