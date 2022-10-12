
namespace App.Logic.Entities
{
    public class Enrollment
    {
        public Enrollment(Guid studentId, Guid courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }

        public long Id { get; }

        public Guid StudentId { get; }

        public Guid CourseId { get; }
    }
}
