using System;
using System.Linq;
using theFood.Domain.Abstract;
using theFood.Domain.DbModel;

namespace theFood.Domain.Concrete
{
    public class EatTimeRepository:IEatTime
    {
        private readonly Model_theFoodDbContainer _dbContext = new Model_theFoodDbContainer();
        public IQueryable<EatingTime> EatingTimes
        {
            get { return _dbContext.EatingTimeSet; }
        }
    }
}
