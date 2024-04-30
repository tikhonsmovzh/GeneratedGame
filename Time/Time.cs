namespace GeneratedGame.Time
{
    internal class Time
    {
        public static long GetMillis() => DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }
}
