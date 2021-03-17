using FiguresDotStore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FiguresDotStore.Model
{
    internal class CartConvertor : ICartConvertor
    {
        private const string CircleType   = "Circle";
        private const string ScuareType   = "Square";
        private const string TriangleType = "Triangle";

        private static readonly Dictionary<string, Func<Position, IFigure>> Factory = new()
        {
            { CircleType, (position) => new Circle(position.SideA) },
            { ScuareType, (position) => new Square(position.SideA) },
            { TriangleType, (position) => new Triangle(position.SideA, position.SideB, position.SideC) }
        };

        public Order ConvertTo(Cart cart)
        {
            Validate(cart);
            var figures = cart.Positions.Select(position => Factory[position.Type](position)).ToList();
            Validate(figures);

            return new Order
            {
                Positions = figures
            };
        }

        private static void Validate(IEnumerable<IFigure> figures)
        {
            var invalidFigure = figures.FirstOrDefault(figure => !figure.Validate());
            if (invalidFigure != null)
            {
                throw new ArgumentException($"Invalid figure argument: {nameof(invalidFigure)}.");
            }
        }

        private static void Validate(Cart cart)
        {
            var invalidPos = cart.Positions.FirstOrDefault(position => !Factory.ContainsKey(position.Type));
            if (invalidPos != null)
            {
                throw new ArgumentException($"Unrecognized position: {nameof(invalidPos)}.");
            }
        }
    }
}
