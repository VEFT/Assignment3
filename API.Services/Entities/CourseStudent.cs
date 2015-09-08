using System.ComponentModel.DataAnnotations.Schema;

namespace API.Services.Entities
{
    /// <summary>
    /// This class represent a single row in the database table
    /// "CourseStudents".
    /// The purpose having this class is to connect the "Courses"
    /// and "Persons" tables.
    /// </summary>
    [Table("CourseStudents")]
    class CourseStudent
    {
        /// <summary>
        /// Database-generated ID of the record.
        /// Example: 2.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The database-generated ID of the course.
        /// Example: 15
        /// </summary>
        public int CourseID { get; set; }

        /// <summary>
        /// The database-generated ID of the person which is registered
        /// in the course. 
        /// Example: 28
        /// </summary>
        public int StudentID { get; set; }
    }
}
