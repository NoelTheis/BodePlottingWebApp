namespace BodePlotting.Drawing.MyMath
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector operator + (Vector a, Vector b)
            => new (a.X + b.X, a.Y + b.Y);
        public static Vector operator -(Vector a, Vector b)
            => new (a.X - b.X, a.Y - b.Y);
        public static Vector operator *(double a, Vector b)
            => new (a * b.X, a * b.Y);
        public static Vector operator *(Vector a, double b)
            => new(a.X * b, a.Y * b);
        public static double operator *(Vector a, Vector b)
            => a.X * b.X + a.Y * b.Y;

        public override string ToString()
        {
            return string.Format("{0}, {1}", X, Y);
        }
    }
}
