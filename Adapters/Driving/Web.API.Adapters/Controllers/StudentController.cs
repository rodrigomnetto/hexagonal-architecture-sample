using App.Logic.Ports.Driving.Commands;
using Database.Adapters.Querys;
using Microsoft.AspNetCore.Mvc;
using Web.API.Adapters.Dtos;

namespace Web.API.Adapters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IRegisterStudentCommandHandler _registerStudentCommandHandler;
        private readonly IEnrollStudentCommandHandler _enrollStudentCommandHandler;
        private readonly ICancelEnrollmentCommandHandler _cancelEnrollmentCommandHandler;
        private readonly IGetAllStudentsQueryHandler _getAllStudentsQueryHandler;

        public StudentController(IRegisterStudentCommandHandler registerStudentCommandHandler,
            IEnrollStudentCommandHandler enrollStudentCommandHandler,
            ICancelEnrollmentCommandHandler cancelEnrollmentCommandHandler,
            IGetAllStudentsQueryHandler getAllStudentsQueryHandler)
        {
            _registerStudentCommandHandler = registerStudentCommandHandler;
            _enrollStudentCommandHandler = enrollStudentCommandHandler;
            _cancelEnrollmentCommandHandler = cancelEnrollmentCommandHandler;
            _getAllStudentsQueryHandler = getAllStudentsQueryHandler;
        }

        public IActionResult RegisterStudent(RegisterStudent registerStudent)
        {
            var command = new RegisterStudentCommand(registerStudent.Name, registerStudent.Cpf);
            var response = _registerStudentCommandHandler.Handle(command);

            if (response)
                return Ok(response.StudentId);

            return BadRequest(response.Message);
        }

        public IActionResult EnrollStudent(EnrollStudent enrollStudent)
        {
            var command = new EnrollStudentCommand(enrollStudent.StudentId, enrollStudent.CourseId);
            var response = _enrollStudentCommandHandler.Handle(command);

            if (response)
                return Ok();

            return BadRequest(response.Message);
        }

        public IActionResult CancelEnrollment(CancelEnrollment cancelEnrollment)
        {
            var command = new CancelEnrollmentCommand(cancelEnrollment.StudentId, cancelEnrollment.CourseId);
            var response = _cancelEnrollmentCommandHandler.Handle(command);

            if (response)
                return Ok();

            return BadRequest(response.Message);
        }

        public IActionResult GetAllStudents()
        {
            var students = _getAllStudentsQueryHandler.GetAllStudents();
            return Ok(students);
        }
    }
}
