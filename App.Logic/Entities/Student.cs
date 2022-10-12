
namespace App.Logic.Entities
{
    public class Student
    {
        public Student(string name, string cpf)
        {
            Name = name;
            Cpf = cpf;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public string Name { get; }

        public string Cpf { get; }

        public IList<Enrollment>? Enrollments { get; private set; }

        public void Enroll(Course course)
        {
            if (Enrollments is null)
                Enrollments = new List<Enrollment>();

            Enrollments.Add(new Enrollment(Id, course.Id));
        }

        public void CancelEnrollment(Guid courseId)
        {
            if (Enrollments is null) return;

            var enrollment = Enrollments.FirstOrDefault(f => f.CourseId == courseId);

            if (enrollment is not null)
                Enrollments.Remove(enrollment);
        }
    }
}
