using System;

namespace API.Services.Exceptions
{
    /// <summary>
    /// An instance of this class will be thrown if we try to
    /// add a student to a course that is already full.
    /// </summary>
    public class AppMaxReachedException : ApplicationException
    {
    }
}
