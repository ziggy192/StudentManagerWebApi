using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentManagerDataAccess;
using Student = StudentMangerWebApi.Models.Student;


namespace StudentMangerWebApi.Controllers
{
    public class StudentsController : ApiController
    {
        Student[] students = new Student[]
        {
            Student.DefaultStudent(1), Student.DefaultStudent(2), Student.DefaultStudent(3), Student.DefaultStudent(4),
            Student.DefaultStudent(5)
        };


        public IHttpActionResult GetStudent(int id)
        {
            //            var student = students.FirstOrDefault(s => s.Id == id);
            //            if (student == null)
            //            {
            //                return NotFound();
            //            }
            WebAdminDBEntities dbContext = new WebAdminDBEntities();

            var student = dbContext.Students.FirstOrDefault(s => s.StudentID == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(new Student()
            {
                Id = student.StudentID
                ,
                DateOfBirth = student.DateOfBirth.GetValueOrDefault().ToString("dd/MM/yyyy")
                ,
                IsMale = student.IsMale.GetValueOrDefault(true)
                ,
                IsPaid = student.IsPaid.GetValueOrDefault(true),
                Name = student.Name
                ,
                PhoneNumber = student.StudentPhone
                ,
                ParentsPhoneNumber = student.ParrentPhone
            });
        }



        public IHttpActionResult PutStudent(Student studentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            int studentId = studentModel.Id;
            WebAdminDBEntities dbContext = new WebAdminDBEntities();

            var student = dbContext.Students.FirstOrDefault(s => s.StudentID == studentModel.Id);

            if (student == null)
            {
                return BadRequest();
            }


            //todo update student from database
            //Dont update isPaid
            //setStudentId = id
            dbContext.Entry(student).CurrentValues.SetValues(
                new StudentManagerDataAccess.Student()
                {
                    StudentID = studentModel.Id,
                    DateOfBirth = DateTime.ParseExact(studentModel.DateOfBirth,"dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsMale = studentModel.IsMale,
                    IsPaid = studentModel.IsPaid,
                    Name = studentModel.Name,
                    StudentPhone = studentModel.PhoneNumber,
                    ParrentPhone = studentModel.ParentsPhoneNumber,
                    Grade = 7,
                    TuitionFee = 500
                    ,StartingDay = DateTime.Now
                    
                });
//            student = studentModel;
            dbContext.SaveChanges();
            return Ok(studentModel);
        }
    }
}