using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LectureOnline2.Models;
using LectureOnline2.Services;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Mvc;

namespace LectureOnline2
{   [ApiController]
    [Route("api/students")]
    
    public class StudentsController : ControllerBase
    {
        private string ConnString = "Data Source=db-mssql;Initial Catalog=s19183;Integrated Security=True";
        private IStudentsDb _dbService;

        public StudentsController(IStudentsDb db)
        {
            _dbService = db;
        }        [HttpGet]
        public IActionResult GetStudents()
        {
            // var sqlConBuilder = new SqlConnectionStringBuilder();
            // sqlConBuilder.InitialCatalog("s19183");
            var result = new List<Student>();
            
            
            using(SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand com = new SqlCommand())
            {

                com.Connection = con;
                com.CommandText = " SELECT * FROM STUDENTS";
                
                con.Open();
                SqlDataReader dr=com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    result.Add(st);
                }
            }    

            
            
            return Ok(result);
        }
        [HttpGet("{IndexNumber}")]
        public IActionResult GetStudent(string IndexNumber)
        {
            
            var result = new List<Student>();
            
            
            using(SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand com = new SqlCommand())
            {

                com.Connection = con;
                com.CommandText = " SELECT * FROM STUDENT WHERE IndexNumber =@index";

                //com.Parameters.AddWithValue("index", IndexNumber);
                SqlParameter par1 = new SqlParameter();
                par1.ParameterName = "value";
                par1.Value = IndexNumber;
                
                
                con.Open();
                SqlDataReader dr=com.ExecuteReader();
                if (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    return Ok(st);
                }
            }    
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateStudent([FromServices] IStudentsDb service, Student newStudent)
        {
            using(SqlConnection con = new SqlConnection())
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "insert into students(IndexNumber,FirstName,LastName) values (@par1,@par2,@par3)";

                com.Parameters.AddWithValue("@par1", newStudent.IndexNumber);
                com.Parameters.AddWithValue("@par2", newStudent.FirstName);
                com.Parameters.AddWithValue("@par3", newStudent.LastName);
                
                con.Open();
                int affectedRows = com.ExecuteNonQuery();


            }    

                return Ok();
        }
        [HttpGet("procedure")]
        public IActionResult GetStudents2()
        {
            using (SqlConnection con = new SqlConnection())
            using (SqlCommand com = new SqlCommand())
            {
                com.CommandText = "TestProc2";
                com.CommandType = System.Data.CommandType.StoredProcedure;

                com.Parameters.AddWithValue("LastName", "Kowalski");

                var dr = com.ExecuteReader();
            }

            return Ok();
        }
        [HttpGet("procedure")]
        public IActionResult GetStudents3()
        {
            using(SqlConnection con = new SqlConnection())
            using (SqlCommand com = new SqlCommand())
            {
                com.CommandText = "insert ...";
                com.Connection = con;

                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    com.ExecuteNonQuery();
                    com.CommandText = "update smth...";
                    com.ExecuteNonQuery();

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                }

            }    
                return Ok();
        }
    }
}