using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

CourseManager courseManager = new CourseManager(new EfCourseDal());
foreach (var course in courseManager.GetByPrice(100,200))
{
    Console.WriteLine(course.CourseName);
}