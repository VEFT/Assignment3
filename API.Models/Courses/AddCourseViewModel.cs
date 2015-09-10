using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Courses
{
    /// <summary>
    /// This class represent a single item being created by a user as
    /// a course object.
    /// The attributes that are required to create a instance are:
    ///     1. CourseID
    ///     2. Semester
    ///     3. StartDate
    ///     4. EndDate
    ///     5. MaxStudents
    /// </summary>
    public class AddCourseViewModel
    {
        /// <summary>
        /// The ID of the course being created.
        /// Example: "T-514-VEFT".
        /// </summary>
        [Required]
        public string TemplateID { get; set; }

        /// <summary>
        /// The semester in which the course is taught.
        /// Example: "20153".
        /// </summary>
        [Required]
        public string Semester { get; set; }

        /// <summary>
        /// The date when the course starts.
        /// Exemple: "20. 08. 2015"
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The date when the coure finishes.
        /// Example: "20. 11. 2015"
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// The maximum number of students that can be
        /// enrolled in the course.
        /// </summary>
        [Required]
        public int MaxStudents { get; set; }
    }
}