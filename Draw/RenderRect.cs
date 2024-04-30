using GeneratedGame.Units;
using SFML.Graphics;
using Color = GeneratedGame.Units.Color;

namespace GeneratedGame.Draw
{
    internal class RenderRect : IDrawable
    {
        public Vector2Float Size
        {
            get => new Vector2Float(_shape.Size);
            set => _shape.Size = new SFML.System.Vector2f(value.X, value.Y);
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

        private readonly RectangleShape _shape;

        public RenderRect(Vector2Float size, Vector2Float position, Color fillColor)
        {
            _shape = new RectangleShape();

            FillColor = fillColor;
            Size = size;
            Position = position;
        }

        public RenderRect(Vector2Float size, Vector2Float position, Color fillColor, Color outlineColor, float outlineThickness) : this(size, position, fillColor)
        {
            if (outlineColor != null)
            {
                OutlineColor = outlineColor;

                OutlineThickness = outlineThickness;

                return;
            }

            OutlineColor = fillColor;
            OutlineThickness = 0;
        }

        public Drawable GetTransformable(float aspect)
        {
            var shape = new RectangleShape(_shape);

            shape.Scale = new SFML.System.Vector2f(_shape.Scale.X * aspect, _shape.Scale.Y);
            shape.Position = new SFML.System.Vector2f(_shape.Position.X * aspect, _shape.Position.Y);

            return shape;
        }
    }
}
