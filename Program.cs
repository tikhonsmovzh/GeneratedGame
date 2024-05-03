using GeneratedGame.Draw;
using GeneratedGame.Time;
using GeneratedGame.Units;
using GeneratedGame.Window;

IWindow window = new SFMLWindow(new Vector2Float(400, 400), "game", 120, Color.BLACK);

var polygon = new RenderPolygon(new Vector2Float[] { new(-50, 0), new(-20, -20), new(50, 0), new(0, 50) }, new Vector2Float(100, 100), Angle.ofDegree(0), Color.GREEN, Color.WHITE, 10);

window.OnFixedUpdate += () =>
{
    polygon.Rotation += Angle.ofDegree(1);

    polygon.OutlineThickness += 0.05f;
};

window.OnShow += (window) =>
{
    window.Draw(polygon);
};

while (window.IsOpen)
    window.Update();