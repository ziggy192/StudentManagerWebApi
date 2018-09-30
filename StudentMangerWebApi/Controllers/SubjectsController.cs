using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentManagerDataAccess;
using Subject = StudentMangerWebApi.Models.Subject;

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
            WebAdminDBEntities dbContext = new WebAdminDBEntities();
            return dbContext.Subjects.Select(
                model => new Subject()
                {
                    SubjectId = model.SubjectID
                    ,SubjectName = model.Name
                });

        }

       

    }
}
