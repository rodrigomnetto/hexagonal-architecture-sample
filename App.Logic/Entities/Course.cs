
namespace App.Logic.Entities
{
    public class Course
    {
        public Course(Guid id, string name) 
        { 
            Id = id;
            Name = name;
        }   

        public Guid Id { get; }

        public string Name { get; }
    }
}
