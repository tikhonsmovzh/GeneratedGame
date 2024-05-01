using GeneratedGame.Draw;
using SFML.Graphics;

namespace GeneratedGame.Window
{
    internal delegate void UpdateDelegate();
    internal delegate void FixedUpdateDelegate();
    internal delegate void OnShowDelegate(IWindow window);

    internal abstract class IWindow
    {
        public UpdateDelegate OnUpdate;
        public FixedUpdateDelegate OnFixedUpdate;
        public OnShowDelegate OnShow;

        public uint FPS = 60;

        public abstract bool IsOpen { get; }

        public abstract void Update();

        public abstract void Draw(IDrawable drawable);
    }
}
