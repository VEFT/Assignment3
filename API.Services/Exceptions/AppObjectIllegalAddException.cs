using System;

namespace API.Services.Exceptions
{
    /// <summary>
    /// An instance of this class will be thrown if we try to add
    /// a student to a course and the student is already in the course.
    /// </summary>
    public class AppObjectIllegalAddException : ApplicationException
    {
    }
}
