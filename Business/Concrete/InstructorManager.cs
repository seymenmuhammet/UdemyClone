using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InstructorManager : IInstructorService
    {
        IInstructorDal _instructorDal;
        public InstructorManager(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }

        public IResult Add(Instructor instructor)
        {
            if ((instructor.User.FirstName + instructor.User.LastName).Length < 2)
            {
                return new ErrorResult("Eğitmen ismi en az 2 karakter olmalı");
            }
            _instructorDal.Add(instructor);
            return new SuccessResult("Eğitmen eklendi");
        }

        public IDataResult<List<Instructor>> GetAll()
        {
            return new SuccessDataResult<List<Instructor>>(_instructorDal.GetAll(), "Eğitmenler listelendi");
        }

        public IDataResult<Instructor> GetById(int id)
        {
            return new SuccessDataResult<Instructor>(_instructorDal.Get(i => i.InstructorId == id), "Eğitmen getirildi");
        }
    }
}
