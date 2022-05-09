using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TrackerManager : ITrackerService
    {
        IEfUserProductTrackerDal _trackerDal;

        public TrackerManager(IEfUserProductTrackerDal trackerDal)
        {
            _trackerDal = trackerDal;
        }

        public void Add(UserProductTracker entity)
        {
            
            _trackerDal.Add(entity);

        }

        public void Delete(UserProductTracker entity)
        {
            _trackerDal.Delete(entity);
        }

        public List<UserProductTracker> GetAll()
        {
            return _trackerDal.GetAll();
        }

        public UserProductTracker GetById(int id)
        {
            return _trackerDal.Get(id);
        }

        public void Update(UserProductTracker entity)
        {
            _trackerDal.Delete(entity);
        }
    }
}
