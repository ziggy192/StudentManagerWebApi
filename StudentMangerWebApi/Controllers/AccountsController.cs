using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentManagerDataAccess;
using StudentMangerWebApi.Models.DTO;
using Student = StudentMangerWebApi.Models.Student;

namespace StudentMangerWebApi.Controllers
{
    public class AccountsController : ApiController
    {
        public IHttpActionResult PostLoginAccount(AccountDTO accountDTO)
        {
            string userId = accountDTO.UserId;
            string password = accountDTO.Password;


            var student = CheckLogin(userId, password);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        public static Student CheckLogin(string userId, string password)
        {
            //todo check login compare password with hashed password 
            //if false then return null
            //if true then return studentModel

            WebAdminDBEntities dbContext = new WebAdminDBEntities();


            var accountt = dbContext.Accounts.FirstOrDefault(account => account.UserID == userId);
            if (accountt?.HashedPassword == password)
            {
                //login success
                var accStudent = dbContext.AccountStudents.FirstOrDefault(model => model.UserID == userId);
                if (accStudent == null)
                {
                    return null;
                }

                var student = dbContext.Students.FirstOrDefault(model => model.StudentID == accStudent.StudentId);
                if (student != null)
                {
                    return new Student()
                    {
                        Id = student.StudentID,
                        DateOfBirth = student.DateOfBirth.GetValueOrDefault().ToString("dd/MM/yyyy"),
                        IsMale = student.IsMale.GetValueOrDefault(true),
                        IsPaid = student.IsPaid.GetValueOrDefault(false),
                        Name = student.Name,
                        ParentsPhoneNumber = student.ParrentPhone,
                        PhoneNumber = student.StudentPhone
                    };
                }
                else
                {

                    return null;
                }
            }
                   
            else
            {
                return null;
            }

            return null;
        }
    }
}