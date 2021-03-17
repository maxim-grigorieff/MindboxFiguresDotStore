using System;
using System.Linq;
using System.Threading.Tasks;
using FiguresDotStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FiguresDotStore.Controllers
{

    [ApiController]
	[Route("[controller]")]
	public class FiguresController : ControllerBase
	{
		private readonly ILogger<FiguresController> _logger;
		private readonly IOrderStorage _orderStorage;
		private readonly ICartConvertor _cartConvertor;
		private readonly IFigureCache _figureCache;

		// корректно сконфигурированный и готовый к использованию клиент Редиса
		private static IRedisClient RedisClient { get; }

		public FiguresController(ILogger<FiguresController> logger, IOrderStorage orderStorage)
		{
			_logger = logger;
			_orderStorage = orderStorage;
			_cartConvertor = new CartConvertor();
			_figureCache = new FigureCache(RedisClient);
		}

		// хотим оформить заказ и получить в ответе его стоимость
		[HttpPost]
		public async Task<ActionResult> Order(Cart cart)
        {
            if (!CheckIfAvailable(cart))
            {
                _logger.LogError("Product in the cart is not in cache.");
                return new BadRequestResult();
            }

            decimal result;
            try
            {
                result = await CreateOrder(cart);
            }
            catch (Exception exc)
            {
				_logger.LogError($"Error: {exc.Message}.");
				return new BadRequestResult();
			}

            return new OkObjectResult(result);
        }

        private async Task<decimal> CreateOrder(Cart cart)
        {
            var order = _cartConvertor.ConvertTo(cart);
            Update(cart);

            return await _orderStorage.Save(order);
        }

        private bool CheckIfAvailable(Cart cart)
        {
			return cart.Positions.Any(position => !_figureCache.CheckIfAvailable(position.Type, position.Count)) == false;
		}

		private void Update(Cart cart)
        {
			foreach (var position in cart.Positions)
			{
				_figureCache.Reserve(position.Type, position.Count);
			}
		}
	}
}
