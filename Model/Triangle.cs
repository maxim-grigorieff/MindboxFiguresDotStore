using System;

namespace FiguresDotStore.Model
{
    internal class Triangle : IFigure
    {
        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public double GetArea()
        {
            var p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public bool Validate()
        {
            if (SideA <= 0 || SideB <= 0 || SideC <= 0)
            {
                return false;
            }
            if (!CheckTriangleInEquality(SideA, SideB, SideC))
            {
                return false;
            }
            if (!CheckTriangleInEquality(SideB, SideA, SideC))
            {
                return false;
            }
            if (!CheckTriangleInEquality(SideC, SideB, SideA))
            {
                return false;
            }
            return true;
        }

        public decimal Cast()
        {
            return (decimal)GetArea() * 1.2m;
        }

        private bool CheckTriangleInEquality(double a, double b, double c) => a < b + c;

    }

}
