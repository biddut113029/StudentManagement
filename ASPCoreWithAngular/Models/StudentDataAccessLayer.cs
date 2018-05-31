using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWithAngular.Models
{
    public class StudentDataAccessLayer
    {
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=myDB;Data Source=DESKTOP-7V61I4R";

        //To View all Students details
        public IEnumerable<Student> GetAllStudents()
        {
            try
            {
                List<Student> lstStudent = new List<Student>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllStudents", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Student Student = new Student();

                        Student.ID = Convert.ToInt32(rdr["StudentID"]);
                        Student.Name = rdr["Name"].ToString();
                        Student.Gender = rdr["Gender"].ToString();
                        Student.Department = rdr["Department"].ToString();
                        Student.City = rdr["City"].ToString();

                        lstStudent.Add(Student);
                    }
                    con.Close();
                }
                return lstStudent;
            }
            catch
            {
                throw;
            }
        }

        //To Add new Student record 
        public int AddStudent(Student Student)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", Student.Name);
                    cmd.Parameters.AddWithValue("@Gender", Student.Gender);
                    cmd.Parameters.AddWithValue("@Department", Student.Department);
                    cmd.Parameters.AddWithValue("@City", Student.City);

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

        //To Update the records of a particluar Student
        public int UpdateStudent(Student Student)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StdId", Student.ID);
                    cmd.Parameters.AddWithValue("@Name", Student.Name);
                    cmd.Parameters.AddWithValue("@Gender", Student.Gender);
                    cmd.Parameters.AddWithValue("@Department", Student.Department);
                    cmd.Parameters.AddWithValue("@City", Student.City);

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

        //Get the details of a particular Student
        public Student GetStudentData(int id)
        {
            try
            {
                Student Student = new Student();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM tblStudent WHERE StudentID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Student.ID = Convert.ToInt32(rdr["StudentID"]);
                        Student.Name = rdr["Name"].ToString();
                        Student.Gender = rdr["Gender"].ToString();
                        Student.Department = rdr["Department"].ToString();
                        Student.City = rdr["City"].ToString();
                    }
                }
                return Student;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record on a particular Student
        public int DeleteStudent(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StdId", id);

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
