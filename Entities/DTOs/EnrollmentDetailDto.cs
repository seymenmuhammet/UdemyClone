using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class EnrollmentDetailDto : IDto
    {
        public int EnrollmentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public DateTime EnrollDate { get; set; }
        public decimal Price { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}
