using FiguresDotStore.Controllers;

namespace FiguresDotStore.Model
{
    internal interface ICartConvertor
    {
		Order ConvertTo(Cart cart);
	}
}
