using GeneratedGame.Draw;
using GeneratedGame.Units;
using GeneratedGame.Window;

IWindow window = new SFMLWindow(new Vector2Float(400, 400), "game", 60, Color.BLACK);

var circle = new RenderCircle(50, new Vector2Float(100, 100), Color.GREEN, Color.WHITE, 5);
var circle2 = new RenderCircle(50, new Vector2Float(250, 100), Color.BLUE, Color.WHITE, 20);

window.OnShow += (window) =>
{
    window.Draw(circle);
    window.Draw(circle2);
};

while (window.IsOpen)
    window.Update();