
namespace App.Logic.Dtos
{
    public class Result
    {
        public bool Succeeded { get; }

        public string? Message { get; }

        public Result(bool succeeded, string? message = null)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public static implicit operator bool(Result result) =>
            result.Succeeded;
    }
}
