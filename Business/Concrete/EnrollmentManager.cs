using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EnrollmentManager : IEnrollmentService
    {
        private readonly IEnrollmentDal _enrollmentDal;
        public EnrollmentManager(IEnrollmentDal enrollmentDal)
        {
            _enrollmentDal = enrollmentDal;
        }
        public IResult Add(Enrollment enrollment)
        {
            var existingEnrollment = _enrollmentDal.Get(e =>
            e.StudentId == enrollment.StudentId &&
            e.CourseId == enrollment.CourseId &&
            e.CompletionDate == null);
            if (existingEnrollment != null)
            {
                return new ErrorResult("Bu öğrenci zaten bu kursa aktif olarak kayıtlı.");
            }
            enrollment.EnrollDate = DateTime.Now;
            _enrollmentDal.Add(enrollment);
            return new SuccessResult("Kayıt başarılı.");
        }

        public IResult Delete(Enrollment enrollment)
        {
            var existingEnrollment = _enrollmentDal.Get(e => e.EnrollmentId == enrollment.EnrollmentId);
            if (existingEnrollment == null)
            {
                return new ErrorResult("Kayıt bulunamadı.");
            }
            _enrollmentDal.Delete(existingEnrollment);
            return new SuccessResult("Kayıt silindi.");
        }

        public IDataResult<List<Enrollment>> GetAll()
        {
            return new SuccessDataResult<List<Enrollment>>(_enrollmentDal.GetAll());
        }

        public IDataResult<Enrollment> GetById(int id)
        {
            return new SuccessDataResult<Enrollment>(_enrollmentDal.Get(e => e.EnrollmentId == id));
        }

        public IDataResult<List<EnrollmentDetailDto>> GetEnrollmentDetails()
        {
            if (DateTime.Now.Hour == 13)
            {
                return new ErrorDataResult<List<EnrollmentDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<EnrollmentDetailDto>>(_enrollmentDal.GetEnrollmentDetails());
        }

        public IResult Update(Enrollment enrollment)
        {
            var existingEnrollment = _enrollmentDal.Get(e => e.EnrollmentId == enrollment.EnrollmentId);
            if (existingEnrollment == null)
            {
                return new ErrorResult("Kayıt bulunamadı.");
            }
            existingEnrollment.CompletionDate = enrollment.CompletionDate;
            _enrollmentDal.Update(existingEnrollment);
            return new SuccessResult("Kayıt güncellendi.");
        }
    }
}
