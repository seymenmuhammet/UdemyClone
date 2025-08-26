using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCourseDal : EfEntityRepositoryBase<Course, UdemyCloneContext>, ICourseDal
    {
        public List<CourseDetailDto> GetCourseDetails()
        {
            using (UdemyCloneContext context = new UdemyCloneContext())
            {
                var result = from c in context.Courses
                             join cat in context.Categories on c.CategoryId equals cat.CategoryId
                             join i in context.Instructors on c.InstructorId equals i.InstructorId
                             select new CourseDetailDto
                             {
                                 CourseId = c.CourseId,
                                 CourseName = c.CourseName,
                                 CategoryName = cat.CategoryName,
                                 InstructorName = i.User.FirstName + " " + i.User.LastName,
                                 Price = c.Price
                             };
                return result.ToList();
            }
        }
    }
}
