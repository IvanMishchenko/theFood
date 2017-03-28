using System.Linq;
using theFood.Domain.DbModel;

namespace theFood.Domain.Abstract
{
    public interface IEatTime
    {
        IQueryable<EatingTime> EatingTimes { get; } 
    }
}
