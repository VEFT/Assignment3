using API.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Net;
using API.Models.Course.Students;
using API.Services.Exceptions;
using API.Models.Courses;
using API.Models.Courses.Students;

namespace Assignment2.Controllers
{
    /// <summary>
    /// This controller handles all HTTP functionality and
    /// communication with the course provider.
    /// The only functionality that does not concern HTTP
    /// is validation.
    /// </summary>
    [RoutePrefix("api/courses")]
    public class CoursesController : ApiController
    {
        /// <summary>
        /// Private variable that contains the connection
        /// to the course provider.
        /// </summary>
        private readonly CoursesServiceProvider _service;

        /// <summary>
        /// Empty constructor.
        /// Initiate our '_service' variable.
        /// </summary>
        public CoursesController()
        {
            _service = new CoursesServiceProvider();
        }

        /// <summary>
        /// Returns a list of courses belonging to a given semester.
        /// If no semester is provided, the current semester will be used.
        /// </summary>
        /// <param name="semester">The semester</param>
        /// <returns>List of courses (DTO class)</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<CourseDTO>))]
        public IHttpActionResult GetCourses(string semester = null)
        {
            return Ok(_service.GetCoursesBySemester(semester));
        }

        /// <summary>
        /// Method that returns a course with a given ID.
        /// </summary>
        /// <param name="id">ID of the course</param>
        /// <returns>A single course (DTO class)</returns>
        [HttpGet]
        [Route("{id}", Name = "GetCourseById")]
        [ResponseType(typeof(CourseDTO))]
        public IHttpActionResult GetCourseById(int id)
        {
            try
            {
                return Ok(_service.GetCourseById(id));
            }
            catch (AppObjectNotFoundException)
            {
                return NotFound();
            }
            catch (AppInternalServerException)
            {
                return InternalServerError();
            }

        }

        /// <summary>
        /// Method that takes in a ID of a course and returns a list of
        /// students in that course.
        /// </summary>
        /// <param name="id">ID of the course</param>
        /// <returns>List of students (DTO class)</returns>
        [HttpGet]
        [Route("{id}/students")]
        [ResponseType(typeof(List<StudentDTO>))]
        public IHttpActionResult GetStudentsInCourse(int id)
        {
            try
            {
                return Ok(_service.GetStudentsInCourse(id));
            }
            catch (AppObjectNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Method that creates a new course.
        /// The attributes needed to add a new course are given with a view model class.
        /// </summary>
        /// <param name="model">Add course view model (ViewModel class)</param>
        /// <returns>201 status code if everything was ok, along with the location and content of the course</returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateCourse(AddCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _service.CreateCourse(model);
                    var location = Url.Link("GetCourseById", new { id = result.ID });
                    return Created(location, result);
                }
                catch (AppInternalServerException)
                {
                    return StatusCode(HttpStatusCode.InternalServerError);
                }

            }

            return StatusCode(HttpStatusCode.PreconditionFailed);
        }

        /// <summary>
        /// Mehod that adds a student to a course with a givin ID.
        /// The attributes needed to add a student to a course are given with 
        /// a view model class.
        /// </summary>
        /// <param name="id">ID of the course</param>
        /// <param name="model">Student view model (ViewModel class)</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/students")]
        [ResponseType(typeof(StudentDTO))]
        public IHttpActionResult AddStudentToCourse(int id, AddStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _service.AddStudentToCourse(id, model);
                    var students = _service.GetStudentsInCourse(id);
                    return Ok(students);
                }
                catch (AppObjectNotFoundException)
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }
            }
            else
            {
                return StatusCode(HttpStatusCode.PreconditionFailed);
            }
        }

        /// <summary>
        /// Method that updates a course with a givin ID.
        /// The attributes that are updated are given with a view model class.
        /// </summary>
        /// <param name="id">ID of the course</param>
        /// <param name="model">Update course view model (ViewModel class)</param>
        /// <returns>The updated course (DTO class)</returns>
        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(CourseDTO))]
        public IHttpActionResult UpdateCourse(int id, UpdateCourseViewModel model)
        {
            try
            {
                return Ok(_service.UpdateCourse(id, model));
            }
            catch (AppObjectNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            catch (AppInternalServerException)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Method that takes in a ID of a course and deletes the course
        /// </summary>
        /// <param name="id">ID of the course</param>
        /// <returns>204 status code if everything was ok</returns>
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteCourse(int id)
        {
            try
            {
                _service.DeleteCourse(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (AppObjectNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/waitinglist")]
        public IHttpActionResult GetCourseWaitingList(int id)
        {
            try
            {
                return Ok(_service.GetCourseWaitingList(id));
            }
            catch (AppObjectNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        [Route("{id}/waitingList")]
        public IHttpActionResult AddStudentToWaitingList(int id)
        {
            // todo
            return null;
        }
    }
}