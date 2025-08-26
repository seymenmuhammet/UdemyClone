using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Instructor : IEntity
    {
        public int InstructorId { get; set; }
        public int UserId { get; set; }
        public string Branch { get; set; } = string.Empty;

        public User User { get; set; }
    }
}
