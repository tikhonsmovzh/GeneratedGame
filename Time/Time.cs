namespace GeneratedGame.Time
{
    internal class Time
    {
        public static long Millis => DateTimeOffset.Now.ToUnixTimeMilliseconds();

        public static long Micros => (long)(DateTimeOffset.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000));
    }
}
