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
        public IEnumerable<Course> GetAllCourses()
        {
            try
            {
                List<Course> lstCourse = new List<Course>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllCourses", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Course Course = new Course();

                        Course.ID = Convert.ToInt32(rdr["CourseID"]);
                        Course.Name = rdr["Name"].ToString();
                        Course.Gender = rdr["Gender"].ToString();
                        Course.Department = rdr["Department"].ToString();
                        Course.City = rdr["City"].ToString();

                        lstCourse.Add(Course);
                    }
                    con.Close();
                }
                return lstCourse;
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

                    cmd.Parameters.AddWithValue("@Name", Course.Name);
                    cmd.Parameters.AddWithValue("@Gender", Course.Gender);
                    cmd.Parameters.AddWithValue("@Department", Course.Department);
                    cmd.Parameters.AddWithValue("@City", Course.City);

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
                    cmd.Parameters.AddWithValue("@Name", Course.Name);
                    cmd.Parameters.AddWithValue("@Gender", Course.Gender);
                    cmd.Parameters.AddWithValue("@Department", Course.Department);
                    cmd.Parameters.AddWithValue("@City", Course.City);

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
                        Course.Name = rdr["Name"].ToString();
                        Course.Gender = rdr["Gender"].ToString();
                        Course.Department = rdr["Department"].ToString();
                        Course.City = rdr["City"].ToString();
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
