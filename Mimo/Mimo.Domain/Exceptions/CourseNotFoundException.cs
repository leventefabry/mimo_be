namespace Mimo.Domain.Exceptions;

public class CourseNotFoundException : Exception
{
    public CourseNotFoundException()
    {
    }

    public CourseNotFoundException(string message) : base(message)
    {
    }
}