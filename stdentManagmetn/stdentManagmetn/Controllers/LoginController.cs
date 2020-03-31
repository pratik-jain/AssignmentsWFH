using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInfoMgmt.Models;

namespace StudentInfoMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(Students s)
        {
            using(var context = new StudentInfoManagmentDbContext())
            {
                var isAvail = context.Students.Where(t => t.Email == s.Email && t.Password == s.Password).FirstOrDefault<Students>();
                if(isAvail != null)
                {
                    return Ok(isAvail);
                }
                else
                {
                    return Ok(0);
                }
            }
        }
    }
}