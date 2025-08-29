using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseDal _courseDal;
        private readonly ICategoryService _categoryService;
        public CourseManager(ICourseDal courseDal, ICategoryService categoryService)
        {
            _courseDal = courseDal;
            _categoryService = categoryService;
        }

        public IResult Add(Course course)
        {
            IResult? result = BusinessRules.Run(CheckIfCourseNameExists(course.CourseName), CheckIfCategoryLimitExceded());
            if (result != null)
            {
                return result;
            }
            _courseDal.Add(course);
            return new SuccessResult(Messages.CourseAdded);
        }
        public IDataResult<List<Course>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Course>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(), Messages.CoursesListed);
        }
        public IDataResult<List<Course>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(c => c.CategoryId == categoryId));
        }
        public IDataResult<Course> GetById(int id)
        {
            return new SuccessDataResult<Course>(_courseDal.Get(c => c.CourseId == id));
        }
        public IDataResult<List<Course>> GetByPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(c => c.Price >= min && c.Price <= max));
        }
        public IDataResult<List<CourseDetailDto>> GetCourseDetails()
        {
            if (DateTime.Now.Hour == 13)
            {
                return new ErrorDataResult<List<CourseDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetCourseDetails());
        }
        private IResult CheckIfCourseNameExists(string courseName)
        {
            var result = _courseDal.GetAll(c => c.CourseName == courseName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CourseNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 8)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
