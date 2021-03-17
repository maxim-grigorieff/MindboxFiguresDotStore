namespace FiguresDotStore.Controllers
{
    internal interface IRedisClient
	{
		int Get(string type);
		void Set(string type, int current);
	}
}
