using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentMangerWebApi.Models;

namespace StudentMangerWebApi.Controllers
{
    public class SubjectsController : ApiController
    {
        Subject[] subjects = new Subject[]
        {
           new Subject(){SubjectId = 1, SubjectName = "English"}
           ,new Subject(){SubjectId = 2, SubjectName = "Japanese"}
            ,new Subject(){SubjectId = 3, SubjectName = "Math"}
            ,new Subject(){SubjectId = 4, SubjectName = "Physics"}
            ,new Subject(){SubjectId = 5, SubjectName = "Chemistry"}

        };
        public IEnumerable<Subject> GetAllSubjects()
        {
            return subjects;
        }

        [Route("{subjectId}/classDetails")]
        public IEnumerable<ClassDetail> GetClassDetailsBySubjectId(int subjectId)
        {

            //todo get classDetails by subjectId from database 
            return ClassDetailsController.classDetailList;
        }

    }
}
