namespace FiguresDotStore.Controllers
{
    internal interface IFigureCache
	{
		bool CheckIfAvailable(string type, int count);
		void Reserve(string type, int count);
	}
}
