using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentMangerWebApi.Models;

namespace StudentMangerWebApi.Controllers
{
    public class StudentsController : ApiController
    {
        Student[] students = new Student[]
        {
            Student.DefaultStudent(1)
            ,Student.DefaultStudent(2)
            ,Student.DefaultStudent(3)
            ,Student.DefaultStudent(4)
            ,Student.DefaultStudent(5)

        };


        public IHttpActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
                
        }

        private static bool checkStudentId(int studentId)
        {
            return true;
        }


        public IHttpActionResult PutStudent(Student studentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
			int studentId  = studentModel.Id;
            

            var student = students.FirstOrDefault(model => model.Id == studentId);


            //check if studentId valid
            if (student == null)
            {
                return BadRequest();
            }

            //todo update student from database
            //Dont update isPaid
            //setStudentId = id

            student = studentModel;
            return Ok(student);
        }
    }
}
