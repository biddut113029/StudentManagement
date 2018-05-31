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
    public class StudentController : Controller
    {
        StudentDataAccessLayer objStudent = new StudentDataAccessLayer();

        [HttpGet("[action]")]
        [Route("api/Student/Index")]
        public IEnumerable<Student> Index()
        {
            return objStudent.GetAllStudents();
        }

        [HttpPost]
        [Route("api/Student/Create")]
        public int Create([FromBody] Student Student)
        {
            return objStudent.AddStudent(Student);
        }

        [HttpGet]
        [Route("api/Student/Details/{id}")]
        public Student Details(int id)
        {
            return objStudent.GetStudentData(id);
        }

        [HttpPut]
        [Route("api/Student/Edit")]
        public int Edit([FromBody]Student Student)
        {
            return objStudent.UpdateStudent(Student);
        }

        [HttpDelete]
        [Route("api/Student/Delete/{id}")]
        public int Delete(int id)
        {
            return objStudent.DeleteStudent(id);
        }
    }
}
