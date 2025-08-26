using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Enrollment : IEntity
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime EnrollDate { get; set; }
        public DateTime? CompletionDate { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
