using App.Logic.Dtos;
using App.Logic.Ports.Driven;

namespace App.Logic.Ports.Driving.Commands
{
    public interface IEnrollStudentCommandHandler
    {
        Result Handle(EnrollStudentCommand command);
    }

    public class EnrollStudentCommand
    {
        public EnrollStudentCommand(Guid studentId, Guid courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }

        public Guid StudentId { get; }

        public Guid CourseId { get; }
    }

    public class EnrollStudentCommandHandler : IEnrollStudentCommandHandler
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public EnrollStudentCommandHandler(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public Result Handle(EnrollStudentCommand command)
        {
            var course = _courseRepository.GetCourseBy(command.CourseId);

            if (course is null)
                return  new Result(false, "Course not found.");

            var student = _studentRepository.GetStudentBy(command.StudentId);
            
            if (student is null)
                return new Result(false, "Student not found.");

            student.Enroll(course);
            _studentRepository.UpdateStudent(student);

            return new Result(true);
        }
    }
}
