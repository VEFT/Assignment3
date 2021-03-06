﻿using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Courses
{
    /// <summary>
    /// This class represents the data needed to update a course.
    /// The attributes that are required to update a instance are:
    ///     1. StartDate
    ///     2. EndDate
    ///     3. MaxStudents
    /// </summary>
    public class UpdateCourseViewModel
    {
        /// <summary>
        /// The date when the course starts.
        /// Example: "20. 08. 2015".
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The date when the course ends.
        /// Example: "20. 11. 2015".
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