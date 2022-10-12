
namespace App.Logic.Dtos
{
    public sealed class RegisterStudentResponse : Result
    {
        public Guid StudentId { get; }

        public RegisterStudentResponse(Guid studentId) : base(true)
        {
            StudentId = studentId;
        }
    }
}
