using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEnrollmentDal : EfEntityRepositoryBase<Enrollment, UdemyCloneContext>, IEnrollmentDal
    {
        public List<EnrollmentDetailDto> GetEnrollmentDetails()
        {
            using (UdemyCloneContext context = new UdemyCloneContext())
            {
                var result = from e in context.Enrollments
                             join c in context.Courses on e.CourseId equals c.CourseId
                             join s in context.Students on e.StudentId equals s.StudentId
                             join u in context.Users on s.UserId equals u.UserId
                             select new EnrollmentDetailDto
                             {
                                 EnrollmentId = e.EnrollmentId,
                                 CourseName = c.CourseName,
                                 StudentName = u.FirstName + " " + u.LastName,
                                 EnrollDate = e.EnrollDate,
                                 CompletionDate = e.CompletionDate
                             };

                return result.ToList();
            }
        }
    }
}
