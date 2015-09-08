using System.ComponentModel.DataAnnotations.Schema;

namespace API.Services.Entities
{
    /// <summary>
    /// This class represents a row containing a single person in
    /// the database table "Persons".
    /// </summary>
    [Table("Students")]
    class Student
    {
        /// <summary>
        /// Database generated unique identifier of the person.
        /// Example: 13.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The social security number of the student.
        /// Example: "1006922879".
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// The name of the student.
        /// Example: "Daníel Benediktsson".
        /// </summary>
        public string Name { get; set; }
    }
}
