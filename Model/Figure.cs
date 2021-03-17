using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiguresDotStore.Model
{
    public interface IFigure
    {
        bool    Validate();
        double  GetArea();
        decimal Cast();
    }

}
