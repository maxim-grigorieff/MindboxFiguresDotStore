using System;

namespace FiguresDotStore.Model
{
    internal class Square : IFigure
    {
        public Square(double side)
        {
            Side = side;
        }

        public double Side { get; set; }

        public bool Validate()
        {
            return Side > 0;
        }

        public double GetArea()
        {
            return Math.Pow(Side, 2);
        }

        public decimal Cast()
        {
            return (decimal)GetArea();
        }
    }

}
