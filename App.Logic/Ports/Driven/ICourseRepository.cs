using App.Logic.Entities;

namespace App.Logic.Ports.Driven
{
    public interface ICourseRepository
    {
        public Course? GetCourseBy(Guid id);
    }
}
