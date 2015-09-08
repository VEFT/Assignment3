using System;

namespace API.Models.Courses
{
    /// <summary>
    /// This class represents an item in a list of courses.
    /// </summary>
    public class CourseDTO
    {
        /// <summary>
        /// Database generated unique identifier of the course.
        /// Example: 1337
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The name of the course.
        /// Example: "Vefþjónustur".
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The date when the course starts.
        /// Example: "20. 08. 2015"
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The number of active students in the course.
        /// Example: 95.
        /// </summary>
        public int StudentCount { get; set; }
    }
}