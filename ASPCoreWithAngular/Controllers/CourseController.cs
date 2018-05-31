using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using ASPCoreWithAngular.Models;

namespace ASPCoreWithAngular.Controllers
{
    public class CourseController : Controller
    {
        CourseDataAccessLayer objCourse = new CourseDataAccessLayer();

        [HttpGet("[action]")]
        [Route("api/Course/Index")]
        public IEnumerable<Course> Index()
        {
            return objCourse.GetAllCourses();
        }

        [HttpPost]
        [Route("api/Course/Create")]
        public int Create([FromBody] Course Course)
        {
            return objCourse.AddCourse(Course);
        }

        [HttpGet]
        [Route("api/Course/Details/{id}")]
        public Course Details(int id)
        {
            return objCourse.GetCourseData(id);
        }

        [HttpPut]
        [Route("api/Course/Edit")]
        public int Edit([FromBody]Course Course)
        {
            return objCourse.UpdateCourse(Course);
        }

        [HttpDelete]
        [Route("api/Course/Delete/{id}")]
        public int Delete(int id)
        {
            return objCourse.DeleteCourse(id);
        }
    }
}
