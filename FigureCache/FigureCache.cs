using System;

namespace FiguresDotStore.Controllers
{
    internal class FigureCache : IFigureCache
    {
        public FigureCache(IRedisClient redisClient)
        {
            RedisClient = redisClient;
        }

        private IRedisClient RedisClient { get; }

        public bool CheckIfAvailable(string type, int count)
        {
            return RedisClient.Get(type) >= count;
        }

        public void Reserve(string type, int count)
        {
            if (!CheckIfAvailable(type, count))
            {
                throw new ArgumentException(nameof(type));
            }

            var current = RedisClient.Get(type);
            RedisClient.Set(type, current - count);
        }
    }
}
