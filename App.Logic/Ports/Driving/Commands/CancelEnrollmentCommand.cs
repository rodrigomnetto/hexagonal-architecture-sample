using App.Logic.Dtos;
using App.Logic.Ports.Driven;

namespace App.Logic.Ports.Driving.Commands
{
    public interface ICancelEnrollmentCommandHandler
    {
        Result Handle(CancelEnrollmentCommand command);
    }

    public class CancelEnrollmentCommand
    {
        public CancelEnrollmentCommand(Guid studentId, Guid courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }

        public Guid StudentId { get; }

        public Guid CourseId { get; }
    }

    public class CancelEnrollmentCommandHandler : ICancelEnrollmentCommandHandler
    {
        private IStudentRepository _studentRepository;
        private ICourseRepository _courseRepository;

        public CancelEnrollmentCommandHandler(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public Result Handle(CancelEnrollmentCommand command)
        {
            var courseFound = _courseRepository.GetCourseBy(command.CourseId);

            if (courseFound is null)
                return new Result(false, "Course not found.");

            var studentFound = _studentRepository.GetStudentBy(command.StudentId);

            if (studentFound is null)
                return new Result(false, "Student not found.");

            var enrollment = studentFound.Enrollments?
                .FirstOrDefault(f => f.CourseId == command.CourseId);

            if (enrollment is null)
                return new Result(false, $"Student is not registered in the course {courseFound.Name}.");

            studentFound.Enrollments?.Remove(enrollment);
            _studentRepository.UpdateStudent(studentFound);

            return new Result(true);
        }
    }
}
