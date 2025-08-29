using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Student : IEntity
    {
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public string EducationLevel { get; set; } = string.Empty;

        public User User { get; set; } 
    }
}
