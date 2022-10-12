using Database.Adapters.Querys.Dtos;

namespace Database.Adapters.Querys
{
    public interface IGetAllStudentsQueryHandler
    {
        public IEnumerable<Student> GetAllStudents();
    }

    public class GetAllStudentQueryHandler : IGetAllStudentsQueryHandler
    {
        public IEnumerable<Student> GetAllStudents()
        {
            return FakeDatabase.Students.Select(f => new Student 
            { 
                Id = f.Id,
                Name = f.Name,
                Cpf = f.Cpf
            });
        }
    }
}
