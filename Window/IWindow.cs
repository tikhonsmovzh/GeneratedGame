using GeneratedGame.Draw;
using SFML.Graphics;

namespace GeneratedGame.Window
{
    internal delegate void UpdateDelegate();
    internal delegate void FixedUpdateDelegate();
    internal delegate void OnShowDelegate(IWindow window);

    internal abstract class IWindow
    {
        public UpdateDelegate OnUpdate { get; set; }
        public FixedUpdateDelegate OnFixedUpdate { get; set; }
        public OnShowDelegate OnShow { get; set; }

        public abstract uint FPS { get; }

        public abstract bool IsOpen { get; }

        public abstract void Update();

        public abstract void Draw(IDrawable drawable);
    }
}
