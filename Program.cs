using GeneratedGame.Draw;
using GeneratedGame.Units;
using GeneratedGame.Window;

IWindow window = new SFMLWindow(new Vector2Float(400, 400), "game", 60, Color.BLACK);

var rect = new RenderRect(new Vector2Float(100, 100), new Vector2Float(0, 0), Color.BLUE);
var rect2 = new RenderRect(new Vector2Float(100, 100), new Vector2Float(100, 0), Color.WHITE);

window.OnShow += (window) =>
{
    window.Draw(rect);
    window.Draw(rect2);
};

while (window.IsOpen)
    window.Update();