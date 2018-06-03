using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWithAngular.Models
{
    public class CourseDataAccessLayer
    {
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=myDB;Data Source=DESKTOP-SDQAJLR";

        //To View all Courses details
        public IEnumerable<CourseName> GetAllCourses()
        {
            try
            {
                List<CourseName> lstCourseName = new List<CourseName>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllCourseNames", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        CourseName CourseName = new CourseName();

                        CourseName.ID = Convert.ToInt32(rdr["CourseID"]);
                        CourseName.Code = rdr["Code"].ToString();
                        CourseName.Name = rdr["Name"].ToString();
                        CourseName.Credit = rdr["Credit"].ToString();
                        lstCourseName.Add(CourseName);
                    }
                    con.Close();
                }
                return lstCourseName;
            }
            catch
            {
                throw;
            }
        }

        //To Add new Course record 
        public int AddCourse(Course Course)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddCourse", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@ID", Course.ID);
                    cmd.Parameters.AddWithValue("@Credit", Course.credit);
                    cmd.Parameters.AddWithValue("@Semester", Course.semester);                
                    cmd.Parameters.AddWithValue("@CourseID", Course.course);
                    cmd.Parameters.AddWithValue("@StudentID", Course.student);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar Course
        public int UpdateCourse(Course Course)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateCourse", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", Course.ID);
                    cmd.Parameters.AddWithValue("@Credit", Course.credit);
                    cmd.Parameters.AddWithValue("@Semester", Course.course);
                    cmd.Parameters.AddWithValue("@CourseID", Course.student);
                    cmd.Parameters.AddWithValue("@StudentID", Course.semester);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Course
        public Course GetCourseData(int id)
        {
            try
            {
                Course Course = new Course();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM tblCourse WHERE ID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Course.ID = Convert.ToInt32(rdr["CourseID"]);
                        Course.credit = rdr["Credit"].ToString();
                        Course.course = rdr["Semester"].ToString();
                        Course.student = rdr["StudentId"].ToString();
                        Course.semester = rdr["CourseID"].ToString();
                    }
                }
                return Course;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record on a particular Course
        public int DeleteCourse(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteCourse", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
