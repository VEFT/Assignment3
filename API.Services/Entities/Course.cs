using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Services.Entities
{
    /// <summary>
    /// This class represents a row containing a single course in
    /// the database table "Courses".
    /// </summary>
    [Table("Courses")]
    class Course
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
        /// The maximum number of students that can be
        /// enrolled in the course.
        /// </summary>
        public int MaxStudents { get; set; }
    }
}
