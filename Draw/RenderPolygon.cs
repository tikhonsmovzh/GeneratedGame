using GeneratedGame.Units;
using SFML.Graphics;
using Color = GeneratedGame.Units.Color;

namespace GeneratedGame.Draw
{
    internal class RenderPolygon : IDrawable
    {
        public Drawable[] GetDrawable(float aspect)
        {
            var shape = new ConvexShape((uint)Points.Length);

            shape.FillColor = new SFML.Graphics.Color(FillColor.R, FillColor.G, FillColor.B);
            shape.Position = new SFML.System.Vector2f(Position.X * aspect, Position.Y);

            var outlineShape = new ConvexShape(shape);

            outlineShape.FillColor = new SFML.Graphics.Color(OutlineColor.R, OutlineColor.G, OutlineColor.B);

            bool skipOutline = false;

            for (var i = 0; i < Points.Length; i++)
            {
                var rot = Angle.ofRadian((float)Math.Atan2(Points[i].Y, Points[i].X)) + Rotation;
                var lenght = (float)Math.Sqrt(Points[i].X * Points[i].X + Points[i].Y * Points[i].Y);

                outlineShape.SetPoint((uint)i, new SFML.System.Vector2f(Angle.Cos(rot) * lenght * aspect, Angle.Sin(rot) * lenght));

                if (!skipOutline)
                {
                    if (lenght > OutlineThickness)
                        shape.SetPoint((uint)i, new SFML.System.Vector2f(Angle.Cos(rot) * (lenght - OutlineThickness) * aspect, Angle.Sin(rot) * (lenght - OutlineThickness)));
                    else
                        skipOutline = true;
                }
            }

            if (!skipOutline)
                return new[] { outlineShape, shape };

            return new[] { outlineShape };
        }

        public Color FillColor { get; set; }

        public Vector2Float[] Points { get; set; }

        public Vector2Float Position { get; set; }

        public Angle Rotation { get; set; }

        public RenderPolygon(Vector2Float[] points, Vector2Float position, Angle rotation, Color fillColor)
        {
            if (points.Length < 3)
                throw new Exception($"not to build polygon by {points.Length} points");

            FillColor = fillColor;
            Points = points;
            Position = position;
            Rotation = rotation;

            OutlineColor = Color.WHITE;
            OutlineThickness = 0;
        }

        public Color OutlineColor { get; set; }

        public float OutlineThickness { get; set; }

        public RenderPolygon(Vector2Float[] points, Vector2Float position, Angle rotation, Color fillColor, Color outlineColor, float outlineThickness) :
            this(points, position, rotation, fillColor)
        {
            OutlineColor = outlineColor;
            OutlineThickness = outlineThickness;
        }
    }
}
