using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCourseDal : ICourseDal
    {
        List<Course> _courses;
        public InMemoryCourseDal()
        {
            _courses = new List<Course>
            {
                new Course{CourseId=1,CategoryId=1,InstructorId=1,CourseName="C# Kursu",Price=100,Description="C# Programlama Dili"},
                new Course{CourseId=2,CategoryId=2,InstructorId=2,CourseName="Java Kursu",Price=150,Description="Java Programlama Dili"},
                new Course{CourseId=3,CategoryId=3,InstructorId=3,CourseName="Python Kursu",Price=200,Description="Python Programlama Dili"},
                new Course{CourseId=4,CategoryId=1,InstructorId=1,CourseName="C# İleri Düzey",Price=250,Description="C# Programlama Dili İleri Düzey Eğitimi"},
                new Course{CourseId=5,CategoryId=2,InstructorId=2,CourseName="JavaScript Kursu",Price=120,Description="JavaScript Programlama Dili"},
            };
        }
        public void Add(Course course)
        {
            _courses.Add(course);
            Console.WriteLine("Kurs eklendi: " + course.CourseName);
        }

        public void Delete(Course course)
        {
            Course courseToDelete = _courses.SingleOrDefault(c => c.CourseId == course.CourseId) ?? throw new InvalidOperationException("Kurs Bulanamadı.");
            _courses.Remove(courseToDelete);
        }

        public Course Get(Expression<Func<Course, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAll()
        {
            return _courses;
        }

        public List<Course> GetAll(Expression<Func<Course, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetByCategoryId(int categoryId)
        {
            _courses.Where(c => c.CategoryId == categoryId).ToList();
            return _courses; 
        }

        public List<CourseDetailDto> GetCourseDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Course course)
        {
            Course courseToUpdate = _courses.SingleOrDefault(c => c.CourseId == course.CourseId) ?? throw new InvalidOperationException("Kurs Bulanamadı.");
            if (courseToUpdate != null)
            {
                courseToUpdate.CategoryId = course.CategoryId;
                courseToUpdate.InstructorId = course.InstructorId;
                courseToUpdate.CourseName = course.CourseName;
                courseToUpdate.Price = course.Price;
                courseToUpdate.Description = course.Description;
                Console.WriteLine("Kurs güncellendi: " + course.CourseName);
            }
        }
    }
}
