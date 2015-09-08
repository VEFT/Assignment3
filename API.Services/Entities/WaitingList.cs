using System.ComponentModel.DataAnnotations.Schema;

namespace API.Services.Entities
{
    /// <summary>
    /// todo
    /// </summary>
    [Table("WaitingLists")]
    class WaitingList
    {
        /// <summary>
        /// Database generated unique identifier of the waiting list.
        /// Example: 13.
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
