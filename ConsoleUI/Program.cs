using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        //DTO -- Data Transformation Object
        //IoC Container -- Inversion of Control
        //CourseTest();
        //CategoryTest();
        //InstructorTest();
        EnrollmentTest();
    }
    private static void InstructorTest()
    {
        InstructorManager instructorManager = new InstructorManager(new EfInstructorDal());
        Console.WriteLine("Eğitmen Listesi\n");
        Console.WriteLine("---------------\n");

        foreach (var (instructor, index) in instructorManager.GetAll().Data.Select((x, i) => (x, i + 1)))
        {
            Console.WriteLine($"{index}.{instructor.User.FirstName} {instructor.User.LastName}");
        }
    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        foreach (var category in categoryManager.GetAll().Data)
        {
            Console.WriteLine(category.CategoryName);
        }
    }

    //private static void CourseTest()
    //{
    //    CourseManager courseManager = new CourseManager(new EfCourseDal(),new);
    //    var result = courseManager.GetCourseDetails();
    //    if (result.Success)
    //    {
    //        foreach (var course in result.Data)
    //        {
    //            Console.WriteLine(course.CourseName + "/" + course.CategoryName + "/" + course.InstructorName +"/" + course.Price );
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine(result.Message);
    //    }        
    //}
    private static void EnrollmentTest()
    {
        EnrollmentManager enrollmentManager = new EnrollmentManager(new EfEnrollmentDal());
        var result = enrollmentManager.GetEnrollmentDetails();
        if (result.Success)
        {
            foreach (var enrollment in result.Data)
            {
                //Console.WriteLine(enrollment.EnrollmentId + "/" + enrollment.CourseName + "/" + enrollment.StudentName + "/" + enrollment.EnrollDate + "/" + enrollment.CompletionDate);
                Console.WriteLine($"{enrollment.StudentName} → {enrollment.CourseName} | Kayıt: {enrollment.EnrollDate} | Bitiş: {(enrollment.CompletionDate.HasValue ? enrollment.CompletionDate.Value.ToString() : "Devam ediyor")}");
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }
}