using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentMangerWebApi.Models;

namespace StudentMangerWebApi.Controllers
{
    public class ClassDetailsController : ApiController
    {
        public static List<ClassDetail> classDetailList = new List<ClassDetail>()
        {
            ClassDetail.DefaultInstance("English 1"),
            ClassDetail.DefaultInstance("Japanese 1"),
            ClassDetail.DefaultInstance("Math 2"),
            ClassDetail.DefaultInstance("Physics 1"),
            ClassDetail.DefaultInstance("Chemistry 3")
        };


        public IHttpActionResult GetClassDetailsByStudentId(int id)
        {
            //todo get class details by student id 
            //assume return all class

            if (!checkStudentId(id))
            {
                return BadRequest();
            }
            var classDetails = classDetailList;
            return Ok(classDetails);
        }

        private static bool checkStudentId(int studentId)
        {
            return true;
        }


    }
}