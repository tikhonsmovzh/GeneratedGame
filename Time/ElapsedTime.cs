namespace GeneratedGame.Time
{
    internal class ElapsedTime
    {
        private long _startTime = 0;

        public ElapsedTime() => Restart();

        public void Restart() => _startTime = Time.Micros;

        public long Micros => Time.Micros - _startTime;

        public float Millis => Micros / 1000f;

        public float Seconds => Millis / 1000f;

        public float Minute => Seconds / 60f;

        public float Hour => Minute / 60f;

        public float Day => Hour / 24f;
    }
}
