using App.Logic.Entities;

namespace App.Logic.Ports.Driven
{
    public interface IStudentRepository
    {
        public void RegisterStudent(Student student);

        public void UpdateStudent(Student student);

        public Student? GetStudentBy(Guid id);

        public Student? GetStudentBy(string cpf);
    }
}
