using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentInfoMgmt.Models;
namespace StudentInfoMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/Student
        [HttpGet]
        public IActionResult Get()
        {
            using (var ctx = new StudentInfoManagmentDbContext())
            {
                var param = new SqlParameter
                {
                    ParameterName = "@JsonOut",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = -1,
                    Direction = System.Data.ParameterDirection.Output
                };
                var students = ctx.Database.ExecuteSqlCommand("spAllStudents @JsonOut=@JsonOut OUTPUT",param);
                
                return Ok(param.Value.ToString());    
            }            
        }
        
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
           
            return "val";
        }

        [HttpPost]
        public IActionResult Post(Students students)
        {
            using (var ctx = new StudentInfoManagmentDbContext())
            {                
                var v = ctx.Database.ExecuteSqlCommand("spAddStudent @StudentName,@Mobile,@Email,@CourseId,@Password",
                    new SqlParameter("@StudentName", students.StudentName),
                    new SqlParameter("@Mobile", students.Mobile),
                    new SqlParameter("@Email", students.Email),
                    new SqlParameter("@CourseId",students.CourseId),
                    new SqlParameter("@Password", students.Password)
                    );
                return Ok(v);   
            }
        }        
        [HttpPut]
        public IActionResult Put(Students students)
        {
            using (var ctx = new StudentInfoManagmentDbContext())
            {
                var v = ctx.Database.ExecuteSqlCommand("spUpdateStudent @StudentId, @StudentName,@Mobile",
                    new SqlParameter("@StudentId", students.StudentId),
                    new SqlParameter("@StudentName", students.StudentName),
                    new SqlParameter("@Mobile", students.Mobile)           
                    );
                return Ok(v);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var ctx = new StudentInfoManagmentDbContext())
            {   
                var v = ctx.Database.ExecuteSqlCommand("spDeleteStudent @StudentId",
                    new SqlParameter("@StudentId", id));
                return Ok(1);
            }
        }
    }
}
