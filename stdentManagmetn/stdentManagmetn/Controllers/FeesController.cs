using System;
using System.Collections.Generic;
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
    public class FeesController : ControllerBase
    {
        [HttpGet ("{id}")]
        public IActionResult Get(int id)        
        {            
            using (var ctx = new StudentInfoManagmentDbContext())
            {
                var studentDetail = ctx.StudentDetails.Where(t => t.StudentId == id).FirstOrDefault<StudentDetails>();
                return Ok(studentDetail);
            }
        }

        [HttpPost]
        public IActionResult Post(StudentDetails sd)
        {
            using(var ctx = new StudentInfoManagmentDbContext())
            {
                var studentDetail = new StudentDetails()
                {
                    StudentId = sd.StudentId,
                    CourseId = sd.CourseId,
                    FeeStatus = sd.FeeStatus
                };
                ctx.StudentDetails.Add(studentDetail);
                ctx.SaveChanges();

                return Ok(studentDetail);
            }
        }
        [HttpPut]
        public IActionResult Put(StudentDetails sd)
        {
            using (var ctx = new StudentInfoManagmentDbContext())
            {
                var v = ctx.Database.ExecuteSqlCommand("spUpdateFee @StudentId",
                    new SqlParameter("@StudentId", sd.StudentId)
                    );
                return Ok(v);
            }
        }
   }
}