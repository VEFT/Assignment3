using System.ComponentModel.DataAnnotations;

namespace API.Models.Course.Students
{
    /// <summary>
    /// This class represent a single student object being added
    /// by a user to a course object.
    /// The attributes that are required to create a instance are:
    ///     1. SSN
    /// </summary>
    public class AddStudentViewModel
    {
        /// <summary>
        /// The social security number of the student.
        /// Example: "1006922879".
        /// </summary>
        [Required]
        public string SSN { get; set; }
    }
}