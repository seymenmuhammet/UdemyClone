using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public void Add(Course course)
        {
            if(course.CourseName.Length < 2)
            {
                Console.WriteLine("Kurs ismi minimum 2 karakter olmalıdır.");
                return;
            }else if (course.Price < 0)
            {
                Console.WriteLine("Kurs fiyatı 0'dan büyük olmalıdır.");
                return;
            }
            _courseDal.Add(course);
            Console.WriteLine("Kurs Eklendi: " + course.CourseName);

        }

        public List<Course> GetAll()
        {
            return _courseDal.GetAll();
        }
        
        public List<Course> GetAllByCategoryId(int id)
        {
            return _courseDal.GetAll(c => c.CategoryId == id);
        }

        public List<Course> GetByPrice(decimal min, decimal max)
        {
            return _courseDal.GetAll(c => c.Price >= min && c.Price <= max);
        }
    }
}
