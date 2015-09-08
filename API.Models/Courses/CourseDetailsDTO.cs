using API.Models.Courses.Students;
using System;
using System.Collections.Generic;

namespace API.Models.Courses
{
    /// <summary>
    /// This class represents a single course, and contains various
    /// details about the course.
    /// </summary>
    public class CourseDetailsDTO
    {
        /// <summary>
        /// Database generated unique identifier of the course.
        /// Example: 1337.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// An identifier of the template of the course.
        /// Example: "T-514-VEFT".
        /// </summary>
        public string TemplateID { get; set; }

        /// <summary>
        /// The name of the course.
        /// Example: "Vefþjónustur".
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The date when the course starts.
        /// Example: "20. 08. 2015".
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The date when the course ends.
        /// Example: "20. 11. 2015".
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// The semester when the course is active.
        /// Examples:
        /// 1. "20151" -> spring 2015.
        /// 2. "20152" -> summer 2015.
        /// 3. "20153" -> fall 2015.
        /// </summary>
        public string Semester { get; set; }

        /// <summary>
        /// List of students in the course.
        /// Example: [
        ///             {
        ///                 "Name: "Jón Jónsson"
        ///                 "SSN: "1234567890"
        ///             }]
        /// </summary>
        public List<StudentDTO> Students { get; set; }

        /// <summary>
        /// The number of students in the course.
        /// Example: 12.
        /// </summary>
        public int StudentCount { get; set; }
    }
}