using GeneratedGame.Units;
using SFML.Graphics;
using Color = GeneratedGame.Units.Color;

namespace GeneratedGame.Draw
{
    internal class RenderCircle : IDrawable
    {
        public Drawable[] GetTransformable(float aspect)
        {
            var shape = new CircleShape(_shape);

            shape.Scale = new SFML.System.Vector2f(_shape.Scale.X * aspect, _shape.Scale.Y);

            if (shape.Radius - OutlineThickness > 0)
                shape.Radius -= OutlineThickness;
            else
            {
                shape.FillColor = _shape.OutlineColor;
                shape.OutlineThickness = 0;
            }

            shape.Position = new SFML.System.Vector2f((_shape.Position.X - shape.Radius) * aspect, _shape.Position.Y - shape.Radius);

            return new[] { shape };
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

        public Color FillColor
        {
            get => new Color(_shape.FillColor);
            set => _shape.FillColor = new SFML.Graphics.Color(value.R, value.G, value.B);
        }

        public Color OutlineColor
        {
            get => new Color(_shape.OutlineColor);
            set => _shape.OutlineColor = new SFML.Graphics.Color(value.R, value.G, value.B);
        }
        public float OutlineThickness
        {
            get => _shape.OutlineThickness;
            set => _shape.OutlineThickness = value;
        }

        public RenderCircle(float radius, Vector2Float position, Color fillColor)
        {
            _shape = new CircleShape();

            Radius = radius;
            Position = position;
            FillColor = fillColor;

            OutlineColor = Color.WHITE;
            OutlineThickness = 0;
        }

        public RenderCircle(float radius, Vector2Float position, Color fillColor, Color outlineColor, float outlineThickness) : this(radius, position, fillColor)
        {
            OutlineColor = outlineColor;
            OutlineThickness = outlineThickness;
        }
    }
}
