namespace GeneratedGame.Units
{
    internal class Angle
    {
        private float _radianAngle = 0, _degreeAngle = 0;

        private Angle() { }

        public float Degree
        {
            get => _degreeAngle;
            set
            {
                _degreeAngle = value;
                _radianAngle = toRadian(value);

                Chop();
            }
        }

        public float Radian
        {
            get => _radianAngle;
            set
            {
                _degreeAngle = toDegree(value);
                _radianAngle = value;

                Chop();
            }
        }

        private void Chop()
        {
            while (Math.Abs(_degreeAngle) > 180)
                _degreeAngle -= 360 * Math.Sign(_degreeAngle);

            _radianAngle = toRadian(_degreeAngle);
        }

        public static Angle ofRadian(float angle) =>  new Angle() { Radian = angle };
        public static Angle ofDegree(float angle) =>  new Angle() { Degree = angle };

        public static float toRadian(float angle) => (float)(angle / 180 * Math.PI);
        public static float toDegree(float angle) => (float)(angle / Math.PI * 180);

        public static Angle operator +(Angle a, Angle b) => ofRadian(a.Radian + b.Radian);
        public static Angle operator -(Angle a, Angle b) => ofRadian(a.Radian - b.Radian);

        public static Angle operator *(Angle a, Angle b) => ofRadian(a.Radian * b.Radian);
        public static Angle operator /(Angle a, Angle b) => ofRadian(a.Radian / b.Radian);

        public static float Sin(Angle angle) => (float)Math.Sin(angle.Radian);
        public static float Cos(Angle angle) => (float)Math.Cos(angle.Radian);
        public static float Tan(Angle angle) => (float)Math.Tan(angle.Radian);
    }
}
