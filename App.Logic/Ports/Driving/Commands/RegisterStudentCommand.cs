using App.Logic.Dtos;
using App.Logic.Entities;
using App.Logic.Ports.Driven;

namespace App.Logic.Ports.Driving.Commands
{
    public interface IRegisterStudentCommandHandler
    {
        RegisterStudentResponse Handle(RegisterStudentCommand command);
    }

    public class RegisterStudentCommand
    {
        public RegisterStudentCommand(string name, string cpf)
        {
            Name = name;
            Cpf = cpf;
        }

        public string Name { get; }

        public string Cpf { get; }
    }

    public class RegisterStudentCommandHandler : IRegisterStudentCommandHandler
    {
        private readonly IStudentRepository _studentRepository;

        public RegisterStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public RegisterStudentResponse Handle(RegisterStudentCommand command)
        {
            var studentFound = _studentRepository.GetStudentBy(command.Cpf);

            if (studentFound is not null)
                return (RegisterStudentResponse)new Result(false, "Student already exists.");

            var student = new Student(command.Name, command.Cpf);
            _studentRepository.RegisterStudent(student);

            return new RegisterStudentResponse(student.Id);
        }
    }
}
