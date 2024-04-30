using GeneratedGame.Units;
using SFML.Graphics;

namespace GeneratedGame.Window
{
    internal class SFMLWindow : IWindow
    {
        private readonly RenderWindow _window;

        public override bool IsOpen => _window.IsOpen;

        public override void Draw(Drawable drawable)
        {
            _window.Draw(drawable);
        }

        private long _lastFrameTime = 0;

        public override void Update()
        {
            _window.DispatchEvents();

            _window.Clear();

            OnUpdate?.Invoke(this);

            if(_lastFrameTime + (long)(1000f / _fixedFps) < Time.Time.GetMillis())
            {
                _lastFrameTime = Time.Time.GetMillis();

                OnFixedUpdate?.Invoke(this);
            }

            _window.Display();
        }

        private readonly int _fixedFps;

        public SFMLWindow(Vector2Float size, string name, int fixedFps)
        {
            _window = new RenderWindow(new SFML.Window.VideoMode((uint)size.X, (uint)size.Y), name);

            _window.Closed += (a, b) => _window.Close();

            _fixedFps = fixedFps;
        }
    }
}
