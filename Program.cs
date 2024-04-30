using GeneratedGame.Time;
using GeneratedGame.Window;
using SFML.Graphics;
using SFML.System;

IWindow window = new SFMLWindow(new GeneratedGame.Units.Vector2Float(400, 400), "game", 60);

CircleShape circle = new CircleShape(50) { Position = new Vector2f(0, 0) };

window.OnFixedUpdate += (window) => circle.Position = new Vector2f(circle.Position.X + 1, circle.Position.Y);

window.OnUpdate += (window) => window.Draw(circle);

while (window.IsOpen)
    window.Update();