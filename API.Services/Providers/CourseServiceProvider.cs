using API.Models.Course.Students;
using API.Services.Repositories;
using System.Collections.Generic;
using System.Linq;
using API.Services.Exceptions;
using API.Services.Entities;
using API.Models.Courses;
using API.Models.Courses.Students;

namespace API.Services
{
    /// <summary>
    /// This class contains all business logic for Courses.
    /// </summary>
    public class CoursesServiceProvider
    {
        /// <summary>
        /// Private variable that contains the connection to the
        /// AppDataContext.
        /// </summary>
        private readonly AppDataContext _db;

        /// <summary>
        /// Empty constructor.
        /// Initiate our '_db' variable.
        /// </summary>
        public CoursesServiceProvider()
        {
            _db = new AppDataContext();
        }

        /// <summary>
        /// Method that returns a course with a given ID.
        /// </summary>
        /// <param name="id">ID of the course</param>
        /// <returns>A single course (DTO class)</returns>
        public CourseDetailsDTO GetCourseById(int id)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == id);
            if (course == null)
            {
                throw new AppObjectNotFoundException();
            }

            var courseTemplate = _db.CourseTemplates.SingleOrDefault(x => x.TemplateID == course.TemplateID);
            if (courseTemplate == null)
            {
                throw new AppInternalServerException();
            }

            var students = GetStudentsInCourse(id);

            var result = new CourseDetailsDTO
            {
                ID = course.ID,
                Name = courseTemplate.Name,
                TemplateID = courseTemplate.TemplateID,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                StudentCount = students.Count,
                Students = students,
                Semester = course.Semester
            };

            return result;
        }

        /// <summary>
        /// Returns a list of courses belonging to a given semester.
        /// If no semester is provided, the current semester will be used.
        /// </summary>
        /// <param name="semester">The semester</param>
        /// <returns>List of courses (DTO class)</returns>
        public List<CourseDTO> GetCoursesBySemester(string semester = null)
        {
            if (string.IsNullOrEmpty(semester))
            {
                semester = "20153";
            }

            var result = (from c in _db.Courses
                          join ct in _db.CourseTemplates on c.TemplateID equals ct.TemplateID
                          where c.Semester == semester
                          select new CourseDTO
                          {
                              ID = c.ID,
                              Name = ct.Name,
                              StartDate = c.StartDate,
                              StudentCount = _db.CourseStudents.Count(x => x.CourseID == c.ID)
                          }).ToList();

            return result;
        }

        /// <summary>
        /// Method that updates a course with a givin ID.
        /// The attributes that are updated are given with a view model class.
        /// </summary>
        /// <param name="id">ID of the course</param>
        /// <param name="model">Update course view model (ViewModel class)</param>
        /// <returns>The updated course (DTO class)</returns>
        public CourseDetailsDTO UpdateCourse(int id, UpdateCourseViewModel model)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == id);
            if (course == null)
            {
                throw new AppObjectNotFoundException();
            }

            var courseTemplate = _db.CourseTemplates.SingleOrDefault(x => x.TemplateID == course.TemplateID);
            if (courseTemplate == null)
            {
                throw new AppInternalServerException();
            }

            course.StartDate = model.StartDate;
            course.EndDate = model.EndDate;
            _db.SaveChanges();

            var students = GetStudentsInCourse(id);

            var result = new CourseDetailsDTO
            {
                ID = course.ID,
                Name = courseTemplate.Name,
                TemplateID = courseTemplate.TemplateID,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                StudentCount = students.Count,
                Students = students,
                Semester = course.Semester
            };

            return result;
        }

        /// <summary>
        /// Method that adds a new course to the database.
        /// The attributes needed to add a new course are given with a view model class.
        /// </summary>
        /// <param name="model">Add course view model (ViewModel class)</param>
        /// <returns>The newly added course (DTO class)</returns>
        public CourseDTO CreateCourse(AddCourseViewModel model)
        {
            var courseTemplate = _db.CourseTemplates.SingleOrDefault(x => x.TemplateID == model.TemplateID);
            if (courseTemplate == null)
            {
                throw new AppInternalServerException();
            }

            var course = new Course
            {
                TemplateID = model.TemplateID,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Semester = model.Semester,
                MaxStudents = model.MaxStudents
            };

            _db.Courses.Add(course);
            _db.SaveChanges();

            var result = new CourseDTO
            {
                ID = course.ID,
                Name = course.TemplateID,
                StartDate = course.StartDate,
                StudentCount = 0
            };

            return result;
        }

        /// <summary>
        /// Method that takes in a ID of a course and returns a list of
        /// students in that course.
        /// </summary>
        /// <param name="id">ID of the course</param>
        /// <returns>A list of students (DTO class)</returns>
        public List<StudentDTO> GetStudentsInCourse(int id)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == id);
            if (course == null)
            {
                throw new AppObjectNotFoundException();
            }

            var result = (from cs in _db.CourseStudents
                          join s in _db.Students on cs.StudentID equals s.ID
                          where cs.CourseID == course.ID && cs.IsActive == true
                          select new StudentDTO
                          {
                              Name = s.Name,
                              SSN = s.SSN
                          }).ToList();

            return result;
        }

        /// <summary>
        /// Method that takes in a ID of a course and deletes the course
        /// from the database.
        /// </summary>
        /// <param name="id">ID of the course</param>
        public void DeleteCourse(int id)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == id);
            if (course == null)
            {
                throw new AppObjectNotFoundException();
            }

            _db.Courses.Remove(course);
            _db.SaveChanges();
        }

        /// <summary>
        /// Method that gets the waiting list of a course with a
        /// given ID.
        /// </summary>
        /// <param name="id">ID of the course</param>
        /// <returns>A list of students (DTO class)</returns>
        public List<StudentDTO> GetCourseWaitingList(int id)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == id);
            if(course == null)
            {
                throw new AppObjectNotFoundException();
            }

            var result = (from wl in _db.WaitingLists
                          join s in _db.Students on wl.StudentID equals s.ID
                          where wl.CourseID == course.ID
                          select new StudentDTO
                          {
                              Name = s.Name,
                              SSN = s.SSN
                          }).ToList();

            return result;
        }

        /// <summary>
        /// Mehod that adds a student to a course with a givin ID.
        /// The attributes needed to add a student to a course are given with 
        /// a view model class.
        /// </summary>
        /// <param name="id">ID of the course</param>
        /// <param name="model">Add student view model (ViewModel class)</param>
        /// <returns>The student that was added to the course (DTO class)</returns>
        public StudentDTO AddStudentToCourse(int id, AddStudentViewModel model)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == id);
            var student = _db.Students.SingleOrDefault(x => x.SSN == model.SSN);
            if (course == null || student == null)
            {
                throw new AppObjectNotFoundException();
            }

            var studentInCourse = _db.CourseStudents.SingleOrDefault(x => x.CourseID == id && x.StudentID == student.ID && x.IsActive == true);
            if(studentInCourse != null)
            {
                throw new AppObjectIllegalAddException();
            }

            if (course.MaxStudents <= GetStudentsInCourse(id).Count)
            {
                throw new AppMaxReachedException();
            }

            var studentInWaitingList = _db.WaitingLists.SingleOrDefault(x => x.CourseID == id && x.StudentID == student.ID);
            if(studentInWaitingList != null)
            {
                _db.WaitingLists.Remove(studentInWaitingList);
            }

            var courseStudent = _db.CourseStudents.SingleOrDefault(x => x.CourseID == id && x.StudentID == student.ID && x.IsActive == false);

            if(courseStudent != null)
            {
                courseStudent.IsActive = true;
            }
            else
            {
                var newCourseStudent = new CourseStudent
                {
                    CourseID = course.ID,
                    StudentID = student.ID,
                    IsActive = true
                };
                _db.CourseStudents.Add(newCourseStudent);
            }

            _db.SaveChanges();

            var result = new StudentDTO
            {
                Name = student.Name,
                SSN = student.SSN
            };

            return result;
        }

        /// <summary>
        /// Method that returns a student with a given SSN in a
        /// course with a given ID.
        /// </summary>
        /// <param name="id">ID of the course</param>
        /// <param name="SSN">SSN of the student</param>
        /// <returns>Single student (DTO class)</returns>
        public StudentDTO GetStudentInCourse(int id, string SSN)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == id);
            var student = _db.Students.SingleOrDefault(x => x.SSN == SSN);
            var courseStudent = _db.CourseStudents.SingleOrDefault(x => x.CourseID == id && x.StudentID == student.ID && x.IsActive == true);
            if (course == null || student == null || courseStudent == null)
            {
                throw new AppObjectNotFoundException();
            }

            var result = new StudentDTO
            {
                Name = student.Name,
                SSN = student.SSN
            };

            return result;
        }

        /// <summary>
        /// Method that removes a student with a given SSN
        /// in a course withe a given ID.
        /// </summary>
        /// <param name="id">ID of the course</param>
        /// <param name="SSN">SSN of the student</param>
        public void RemoveStudentFromCourse(int id, string SSN)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == id);
            var student = _db.Students.SingleOrDefault(x => x.SSN == SSN);
            var courseStudent = _db.CourseStudents.SingleOrDefault(x => x.CourseID == id && x.StudentID == student.ID && x.IsActive == true);
            if (course == null || student == null || courseStudent == null)
            {
                throw new AppObjectNotFoundException();
            }

            courseStudent.IsActive = false;
            _db.SaveChanges();
        }

        /// <summary>
        /// Mehod that adds a student to the waiting list of a course 
        /// with a givin ID. The attributes needed to add a student to  
        /// the waiting list are given with a view model class.
        /// </summary>
        /// <param name="id">ID of the course</param>
        /// <param name="model">Add student view model (ViewModel class)</param>
        /// <returns>The student that was added to the waiting list (DTO class)</returns>
        public StudentDTO AddStudentToWaitingList(int id, AddStudentViewModel model)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == id);
            var student = _db.Students.SingleOrDefault(x => x.SSN == model.SSN);
            if (course == null || student == null)
            {
                throw new AppObjectNotFoundException();
            }

            var studentsInCourse = _db.CourseStudents.SingleOrDefault(x => x.CourseID == id && x.StudentID == student.ID);
            var studentInWaitingList = _db.WaitingLists.SingleOrDefault(x => x.CourseID == id && x.StudentID == student.ID);
            if (studentsInCourse != null || studentInWaitingList != null)
            {
                throw new AppObjectIllegalAddException();
            }

            var waitingList = new WaitingListEntry
            {
                CourseID = course.ID,
                StudentID = student.ID
            };

            _db.WaitingLists.Add(waitingList);
            _db.SaveChanges();

            var result = new StudentDTO
            {
                Name = student.Name,
                SSN = student.SSN
            };

            return result;
        }
    }
}