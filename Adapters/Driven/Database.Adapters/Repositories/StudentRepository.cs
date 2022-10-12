using App.Logic.Entities;
using App.Logic.Ports.Driven;

namespace Database.Adapters.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public Student? GetStudentBy(Guid id)
        {
            return FakeDatabase.Students.FirstOrDefault(f => f.Id == id);
        }

        public Student? GetStudentBy(string cpf)
        {
            return FakeDatabase.Students.FirstOrDefault(f => f.Cpf == cpf);
        }

        public void RegisterStudent(Student student)
        {
            FakeDatabase.Students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            var oldStudent = FakeDatabase.Students.First(f => f.Id == student.Id);
            FakeDatabase.Students.Remove(oldStudent);
            FakeDatabase.Students.Add(student);
        }
    }
}
