using System;
namespace Labb2
{
    public class Position
    {

        private double x;
        private double y;

        public double X
        {
            get => x;
            set => x = Math.Abs(value);
        }


        public double Y
        {
            get => y;
            set => y = Math.Abs(value);
        }

        public Position(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(X,2) + Math.Pow(Y,2));
        }

        public bool Equals(Position p)
        {
            return X.Equals(p.X) && Y.Equals(p.Y);
        }

        public Position Clone()
        {
            return new Position(X, Y);
        }

        public override string ToString() => $"({ X }, { Y })";

        public static bool operator >(Position p1, Position p2)
        {
            if (p1.Length().Equals(p2.Length()) )
            {
                return p1.X > p2.X;
            }
            return p1.Length() > p2.Length();
        }

        public static bool operator <(Position p1, Position p2)
        {
            if (p1.Length().Equals(p2.Length()))
            {
                return p1.X < p2.X;
            }
            return p1.Length() < p2.Length();
        }

        public static Position operator +(Position p1, Position p2) => new Position(p1.X + p2.X, p1.Y + p2.Y);

        public static Position operator -(Position p1, Position p2) => new Position(p1.X - p2.X, p1.Y - p2.Y);

        public static double operator %(Position p1, Position p2) => Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }
}
