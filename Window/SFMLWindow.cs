using GeneratedGame.Draw;
using GeneratedGame.Units;
using SFML.Graphics;
using SFML.System;

namespace GeneratedGame.Window
{
    internal class SFMLWindow : IWindow
    {
        private readonly RenderWindow _window;

        public override bool IsOpen => _window.IsOpen;

        public override void Draw(IDrawable dr)
        {
            var drawables = dr.GetTransformable((float)_window.Size.Y / _window.Size.X);

            foreach(var i in drawables)
                _window.Draw(i);
        }

        private uint _fpsCounter = 0;
        private long _lastFrameTime = 0;

        private readonly Clock _fpsClock;

        public override void Update()
        {
            _window.DispatchEvents();

            OnUpdate?.Invoke();

            if (_lastFrameTime + (long)(1000f / _fixedFps) < Time.Time.GetMillis())
            {
                _lastFrameTime = Time.Time.GetMillis();

                OnFixedUpdate?.Invoke();
            }

            _window.Clear(new SFML.Graphics.Color(BackgroundColor.R, BackgroundColor.G, BackgroundColor.B));

            if (_fpsClock.ElapsedTime.AsMilliseconds() / 1000f >= 1f)
            {
                FPS = _fpsCounter;
                _fpsCounter = 0;
                _fpsClock.Restart();
            }

            _fpsCounter++;

            OnShow?.Invoke(this);

            _window.Display();
        }

        private readonly int _fixedFps;


        public Units.Color BackgroundColor { get; set; }

        public SFMLWindow(Vector2Float size, string name, int fixedFps, Units.Color backgroundColor)
        {
            _window = new RenderWindow(new SFML.Window.VideoMode((uint)size.X, (uint)size.Y), name);

            _window.Closed += (a, b) => _window.Close();

            _fixedFps = fixedFps;

            BackgroundColor = backgroundColor;

            _fpsClock = new Clock();

            OnFixedUpdate += () => Console.WriteLine(FPS);
        }
    }
}
