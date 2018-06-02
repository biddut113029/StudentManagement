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
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=myDB;Data Source=DESKTOP-7V61I4R";

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

                        CourseName.ID = Convert.ToInt32(rdr["ID"]);
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

                    cmd.Parameters.AddWithValue("@credit", Course.credit);
                    cmd.Parameters.AddWithValue("@course", Course.course);
                    cmd.Parameters.AddWithValue("@student", Course.student);
                    cmd.Parameters.AddWithValue("@semester", Course.semester);
                    cmd.Parameters.AddWithValue("@CourseID", Course.CourseID);
                    cmd.Parameters.AddWithValue("@StudentID", Course.StudentID);


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

                    cmd.Parameters.AddWithValue("@CrsId", Course.ID);
                    cmd.Parameters.AddWithValue("@credit", Course.credit);
                    cmd.Parameters.AddWithValue("@course)", Course.course);
                    cmd.Parameters.AddWithValue("@student", Course.student);
                    cmd.Parameters.AddWithValue("@semester", Course.semester);

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
                    string sqlQuery = "SELECT * FROM tblCourse WHERE CourseID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Course.ID = Convert.ToInt32(rdr["CourseID"]);
                        Course.credit = rdr["credit"].ToString();
                        Course.course = rdr["course"].ToString();
                        Course.student = rdr["student"].ToString();
                        Course.semester = rdr["semester"].ToString();
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

                    cmd.Parameters.AddWithValue("@CrsId", id);

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
