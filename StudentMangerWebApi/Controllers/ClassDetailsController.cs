using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentManagerDataAccess;
using StudentMangerWebApi.Models;
using ClassDetail = StudentMangerWebApi.Models.ClassDetail;

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

//            if (!checkStudentId(id))
//            {
//                return BadRequest();
//            }
//            var classDetails = classDetailList;
//            return Ok(classDetails);
            WebAdminDBEntities db = new WebAdminDBEntities();


            if (db.Students.FirstOrDefault(m => m.StudentID == id) == null)
            {
                return BadRequest();
            }

            var classDetails = db.ClassDetailStudents.Where(model => model.StudentId == id).Select(
                classDetailsStudent => classDetailsStudent.ClassDetail).ToList();


            return Ok(classDetails.Select(
                dao => new ClassDetail()
                {
                    ClassDetailId = dao.ClassDetailId,
                    ClassName = dao.ClassName,
                    RoomName = dao.Room.Name,
                    SubjectName = dao.Subject.Name,
                    TeacherName = dao.Teacher.Name,
                    TimeSlotModels = dao.ClassDetailSlots.ToList().Select(
                        timeslot => new ClassSlotModel()
                        {
                            Id = timeslot.ClassDetailSlotId,
                            ClassDetailId = dao.ClassDetailId,
                            Date = timeslot.DayOfWeek,
                            Time = ClassSlotModel.getTime(timeslot.StartTime.GetValueOrDefault()
                                , timeslot.EndTime.GetValueOrDefault())
                        }).ToList()
                }
            ));
        }


        [Route("api/subjects/{subjectId}/classDetails")]
        [HttpGet]
        public IHttpActionResult GetClassDetailsBySubjectId(int subjectId)
        {
            //todo get classDetails by subjectId from database 
//            return ClassDetailsController.classDetailList;
            WebAdminDBEntities db = new WebAdminDBEntities();


            if (db.Subjects.FirstOrDefault(m => m.SubjectID == subjectId) == null)
            {
                return BadRequest();
            }

            var classDetailsResult = db.ClassDetails.Where(classDetail => classDetail.SubjectId == subjectId).ToList();
            return Ok(classDetailsResult.Select(
                result => new ClassDetail()
                {
                    ClassDetailId = result.ClassDetailId,
                    ClassName = result.ClassName,
                    RoomName = result.Room.Name,
                    SubjectName = result.Subject.Name,
                    TeacherName = result.Teacher.Name,
                    TimeSlotModels = result.ClassDetailSlots.ToList().Select(
                        timeslot => new ClassSlotModel()
                        {
                            Id = timeslot.ClassDetailSlotId,
                            ClassDetailId = result.ClassDetailId,
                            Date = timeslot.DayOfWeek,
                            Time = ClassSlotModel.getTime(timeslot.StartTime.GetValueOrDefault()
                                , timeslot.EndTime.GetValueOrDefault())
                        }).ToList()
                }));
        }
    }
}