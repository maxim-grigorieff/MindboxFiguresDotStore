using System;

namespace FiguresDotStore.Model
{
    internal class Circle : IFigure
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; set; }

        public bool Validate()
        {
            return Radius > 0;
        }

        public double GetArea() => Math.PI * Math.Pow(Radius, 2);

        public decimal Cast()
        {
            return (decimal)GetArea() * 0.9m;
        }
    }

}
