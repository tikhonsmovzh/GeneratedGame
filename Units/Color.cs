using SFML.Graphics;

namespace GeneratedGame.Units
{
    internal class Color
    {
        public byte R {  get; set; }
        public byte G {  get; set; }
        public byte B {  get; set; }

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Color(Color copy): this(copy.R, copy.G, copy.B) {}

        public Color(SFML.Graphics.Color sfmlColor) : this(sfmlColor.R, sfmlColor.G, sfmlColor.B) { }

        public static readonly Color WHITE = new Color(255, 255, 255);
        public static readonly Color RED = new Color(255, 0, 0);
        public static readonly Color GREEN = new Color(0, 255, 0);
        public static readonly Color BLUE = new Color(0, 0, 255);
        public static readonly Color BLACK = new Color(0, 0, 0);
    }
}
