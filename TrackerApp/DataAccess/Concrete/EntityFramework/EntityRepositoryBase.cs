using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EntityRepositoryBase<T>:IEntityRepository<T> where T : class
    {
        public void Add(T entity)
        {
            using (TrackerDbContext context = new TrackerDbContext())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (TrackerDbContext context = new TrackerDbContext())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public T Get(int id)
        {
            using (TrackerDbContext context = new TrackerDbContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public List<T> GetAll()
        {
            using (TrackerDbContext context = new TrackerDbContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            using (TrackerDbContext context = new TrackerDbContext())
            {
                return context.Set<T>().Where(filter).ToList();
            }
        }

        public void Update(T entity)
        {
            using (TrackerDbContext context = new TrackerDbContext())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
