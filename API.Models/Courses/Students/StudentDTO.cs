namespace API.Models.Courses.Students
{
    /// <summary>
    /// This class represents a single item in a list of students.
    /// </summary>
    public class StudentDTO
    {
        /// <summary>
        /// The name of the student.
        /// Example: "Daníel Benediktsson".
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The social security number of the student.
        /// Example: "1006922879".
        /// </summary>
        public string SSN { get; set; }
    }
}