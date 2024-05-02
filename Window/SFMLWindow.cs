using GeneratedGame.Draw;
using GeneratedGame.Time;
using GeneratedGame.Units;
using SFML.Graphics;

namespace GeneratedGame.Window
{
    internal class SFMLWindow : IWindow
    {
        private readonly RenderWindow _window;

        public override bool IsOpen => _window.IsOpen;

        public override void Draw(IDrawable dr)
        {
            var drawables = dr.GetDrawable((float)_window.Size.Y / _window.Size.X);

            foreach(var i in drawables)
                _window.Draw(i);
        }


        private readonly ElapsedTime _fixedClock;

        private readonly FPSCounter _fpsCounter;

        public override void Update()
        {
            _window.DispatchEvents();

            OnUpdate?.Invoke();

            if (_fixedClock.Micros > 1000000f / _fixedFps)
            {
                _fixedClock.Restart();

                OnFixedUpdate?.Invoke();
            }

            _fpsCounter.tick();

            _window.Clear(new SFML.Graphics.Color(BackgroundColor.R, BackgroundColor.G, BackgroundColor.B));

            OnShow?.Invoke(this);

            _window.Display();
        }

        public override uint FPS => _fpsCounter.FPS;

        private readonly int _fixedFps;

        public Units.Color BackgroundColor { get; set; }

        public SFMLWindow(Vector2Float size, string name, int fixedFps, Units.Color backgroundColor)
        {
            _window = new RenderWindow(new SFML.Window.VideoMode((uint)size.X, (uint)size.Y), name);
            _window.SetVerticalSyncEnabled(false);

            _window.Closed += (sender, args) => _window.Close();

            _window.KeyPressed += (sender, args) =>
            {
                if (args.Code == SFML.Window.Keyboard.Key.Escape)
                    _window.Close();
            };

            _fixedFps = fixedFps;

            BackgroundColor = backgroundColor;

            _fixedClock = new ElapsedTime();
            _fpsCounter = new FPSCounter();

            OnFixedUpdate += () => _window.SetTitle($"{ name } {FPS} fps");
        }
    }
}
