using SFML.Graphics;

namespace GeneratedGame.Window
{
    internal delegate void Update(IWindow window);
    internal delegate void FixedUpdate(IWindow window);

    internal abstract class IWindow
    {
        public Update OnUpdate;
        public FixedUpdate OnFixedUpdate;

        public abstract bool IsOpen { get; }

        public abstract void Update();

        public abstract void Draw(Drawable drawable);
    }
}
