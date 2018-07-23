using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentMangerWebApi.Models;
using StudentMangerWebApi.Models.DTO;

namespace StudentMangerWebApi.Controllers
{
    public class AccountsController : ApiController
    {
        public IHttpActionResult PostLoginAccount(AccountDTO accountDTO)
        {
            string userId = accountDTO.UserId;
            string password = accountDTO.Password;
            var student = checkLogin(userId, password);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
                    
        }

        public static Student checkLogin(string userId, string password)
        {
            //todo check login compare password with hashed password 
            //if false then return null
            //if true then return studentModel
            return new Student();
        }
    }
}
