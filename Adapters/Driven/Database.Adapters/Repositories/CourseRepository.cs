using App.Logic.Entities;
using App.Logic.Ports.Driven;

namespace Database.Adapters.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public Course? GetCourseBy(Guid id)
        {
            return FakeDatabase.Courses.FirstOrDefault(f => f.Id == id);
        }
    }
}
