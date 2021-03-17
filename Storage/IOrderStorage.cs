using System.Threading.Tasks;
using FiguresDotStore.Model;

namespace FiguresDotStore.Controllers
{
    public interface IOrderStorage
	{
		// сохраняет оформленный заказ и возвращает сумму
		Task<decimal> Save(Order order);
	}
}
