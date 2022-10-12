using App.Logic.Entities;

namespace Database.Adapters
{
    public class FakeDatabase
    {
        public static List<Student> Students { get; } = new();

        public static List<Course> Courses { get; } = new() 
        { 
            new Course(Guid.NewGuid(), "Computer Science"),
            new Course(Guid.NewGuid(), "Computer Enginnering"),
            new Course(Guid.NewGuid(), "Systems Analysis"),
            new Course(Guid.NewGuid(), "Computers Networks")
        };
    }
}
