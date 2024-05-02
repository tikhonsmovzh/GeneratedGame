namespace GeneratedGame.Time
{
    internal class FPSCounter
    {
        private readonly ElapsedTime _fpsClock;

        public FPSCounter() {
            _fpsClock = new ElapsedTime();
        }

        private uint _fpsCounter = 0;

        public uint FPS = 60;

        public void tick()
        {
            if(_fpsClock.Seconds > 1f)
            {
                _fpsClock.Restart();
                FPS = _fpsCounter;
                _fpsCounter = 0;
            }

            _fpsCounter++;
        }
    }
}
