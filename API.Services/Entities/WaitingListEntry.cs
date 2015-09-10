using System.ComponentModel.DataAnnotations.Schema;

namespace API.Services.Entities
{
    /// <summary>
    /// This class represent a single row in the database table
    /// "WaitingListEntries". A single row represents one instance of
    /// a student on a waiting list for a specific course.
    /// </summary>
    [Table("WaitingListEntries")]
    class WaitingListEntry
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
        /// in the waiting list of the course. 
        /// Example: 28
        /// </summary>
        public int StudentID { get; set; }
    }
}
