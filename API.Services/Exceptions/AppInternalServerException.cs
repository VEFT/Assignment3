using System;

namespace API.Services.Exceptions
{
    /// <summary>
    /// An instance of this class will be thrown if "CourseTemplate" does
    /// not exist for a given "Course".
    /// </summary>
    public class AppInternalServerException : ApplicationException
    {
    }
}