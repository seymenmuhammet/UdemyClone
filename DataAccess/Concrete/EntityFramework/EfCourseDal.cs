using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCourseDal : ICourseDal
    {
        public void Add(Course entity)
        {
            // IDisposable pattern implementation c#
            using (UdemyCloneContext context = new UdemyCloneContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Course entity)
        {
            using (UdemyCloneContext context = new UdemyCloneContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Course Get(Expression<Func<Course, bool>> filter)
        {
            using (UdemyCloneContext context = new UdemyCloneContext())
            {
                var entity = context.Set<Course>().SingleOrDefault(filter);
                if (entity is null)
                    throw new InvalidOperationException("Kurs bulunamadı");
                return entity;
            }
        }

        public List<Course> GetAll(Expression<Func<Course, bool>>? filter = null)
        {
           using(UdemyCloneContext context = new UdemyCloneContext())
            {
                return filter == null ? context.Set<Course>().ToList() : context.Set<Course>().Where(filter).ToList();
            }
        }

        public void Update(Course entity)
        {
            using (UdemyCloneContext context = new UdemyCloneContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
