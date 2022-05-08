using DataAccess.Abstract;
using DataAccess.Entity;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserProductTrackerDal : EntityRepositoryBase<UserProductTracker>, IEfUserProductTrackerDal
    {
    }
}
