using System.Collections.Generic;
using System.Linq;

namespace FiguresDotStore.Model
{
    public class Order
	{
		public List<IFigure> Positions { get; set; }

		public decimal GetTotal() => Positions.Select(p => p.Cast()).Sum();
	}
}
