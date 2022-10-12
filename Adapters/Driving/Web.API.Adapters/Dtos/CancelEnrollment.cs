namespace Web.API.Adapters.Dtos
{
    public class CancelEnrollment
    {
        public Guid StudentId { get; set; }

        public Guid CourseId { get; set; }
    }
}
