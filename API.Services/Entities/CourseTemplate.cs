using System.ComponentModel.DataAnnotations.Schema;

namespace API.Services.Entities
{
    /// <summary>
    /// This class represents a row containing a single course template
    /// in the database table "CourseTemplates".
    /// </summary>
    [Table("CourseTemplates")]
    class CourseTemplate
    {
        /// <summary>
        /// Database generated unique identifier of the course template.
        /// Example: 1337.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// An identifier of the course template.
        /// Example: "T-514-VEFT".
        /// </summary>
        public string TemplateID { get; set; }

        /// <summary>
        /// The name of the course template.
        /// Example: "Vefþjónustur".
        /// </summary>
        public string Name { get; set; }
    }
}
