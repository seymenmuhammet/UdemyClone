using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEnrollmentService
    {
        IDataResult<List<Enrollment>> GetAll();
        IDataResult<Enrollment> GetById(int id);
        IResult Add(Enrollment enrollment);
        IResult Update(Enrollment enrollment);
        IResult Delete(Enrollment enrollment);
        IDataResult<List<EnrollmentDetailDto>> GetEnrollmentDetails();

    }
}
