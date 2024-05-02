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

            for(var i = 0; i < Points.Length; i++)
            {
                var rot = Angle.ofRadian((float)Math.Atan2(Points[i].Y, Points[i].X)) + Rotation;
                var lenght = (float)Math.Sqrt(Points[i].X * Points[i].X + Points[i].Y * Points[i].Y);

                shape.SetPoint((uint)i, new SFML.System.Vector2f(Angle.Cos(rot) * lenght * aspect, Angle.Sin(rot) * lenght));
            }

            shape.FillColor = new SFML.Graphics.Color(FillColor.R, FillColor.G, FillColor.B);
            shape.Position = new SFML.System.Vector2f(Position.X * aspect, Position.Y);

            return new[] { shape };
        }

        public Color FillColor { get; set; }

        public Vector2Float[] Points { get; set; }

        public Vector2Float Position { get; set; }

        public Angle Rotation { get; set; }

        public RenderPolygon(Vector2Float[] points, Vector2Float position, Angle rotation, Color fillColor)
        {
            FillColor = fillColor;
            Points = points;
            Position = position;
            Rotation = rotation;

            if (points.Length < 3)
                throw new Exception($"not to build polygon by {points.Length} points");
        }
    }
}
