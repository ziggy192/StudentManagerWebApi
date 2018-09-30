using StudentMangerWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentManagerDataAccess;
using StudentMangerWebApi.Models.DTO;
using ClassDetail = StudentMangerWebApi.Models.ClassDetail;

namespace StudentMangerWebApi.Controllers
{
    public class SlotRequestedsController : ApiController
    {
        static List<SlotRequestedModel> slotRequestedmodels = new List<SlotRequestedModel>()
        {
            new SlotRequestedModel()
            {
                Id = 1,
                State = SlotRequestedModel.ACCEPTED_STATE,
                ClassDetail = ClassDetail.DefaultInstance("English 01"),
                StudentId = 1
            },
            new SlotRequestedModel()
            {
                Id = 2,
                State = SlotRequestedModel.DENIED_STATE,
                ClassDetail = ClassDetail.DefaultInstance("English 02"),
                StudentId = 1
            },
            new SlotRequestedModel()
            {
                Id = 3,
                State = SlotRequestedModel.WAITING_STATE,
                ClassDetail = ClassDetail.DefaultInstance("Japanese 01"),
                StudentId = 1
            },
            new SlotRequestedModel()
            {
                Id = 4,
                State = SlotRequestedModel.WAITING_STATE,
                ClassDetail = ClassDetail.DefaultInstance("Math 01"),
                StudentId = 1
            }
        };


        public IHttpActionResult GetAllSlotRequestedsByStudentId(int id)
        {
            WebAdminDBEntities db = new WebAdminDBEntities();

            var results = db.ClassRequests.Where(request => request.StudentId == id).ToList();
            return Ok(results.Select(model => new SlotRequestedModel()
            {
                Id = model.ClassRequestId,
                StudentId = model.StudentId.GetValueOrDefault(4),
                State = transState(model.State.GetValueOrDefault(0)),
                ClassDetail = new ClassDetail()
                {
                    ClassDetailId = model.ClassDetailId.GetValueOrDefault(4),
                    ClassName = model.ClassDetail.ClassName,
                    RoomName = model.ClassDetail.Room.Name,
                    SubjectName = model.ClassDetail.Subject.Name,
                    TeacherName = model.ClassDetail.Teacher.Name,
                    TimeSlotModels = model.ClassDetail.ClassDetailSlots.ToList().Select(
                        timeslot => new ClassSlotModel()
                        {
                            Id = timeslot.ClassDetailSlotId,
                            ClassDetailId = model.ClassDetail.ClassDetailId,
                            Date = timeslot.DayOfWeek,
                            Time = ClassSlotModel.getTime(timeslot.StartTime.GetValueOrDefault()
                                , timeslot.EndTime.GetValueOrDefault())
                        }).ToList()
                }
            }));

//            var slotRequestedList = slotRequestedmodels.Where(model => model.StudentId == id).ToList();
//
//            return Ok(slotRequestedList);

        }
        
        private static string transState(int state)
        {
            switch (state)
            {
                case 0:
                    return SlotRequestedModel.WAITING_STATE;
                case 1:
                    return SlotRequestedModel.ACCEPTED_STATE;
                default:
                    return SlotRequestedModel.DENIED_STATE;
            }
        }
      

        
        public IHttpActionResult PostFormRequestByStudentId(int id, SlotRequestPostDTO slotRequestPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            WebAdminDBEntities db = new WebAdminDBEntities();
            int maxId = db.ClassRequests.Max(m => m.ClassRequestId);
            maxId++;
            db.ClassRequests.Add(
                new ClassRequest()
                {
                    ClassRequestId = maxId,
                    ClassDetailId = slotRequestPostDto.ClassDetailId,
                    StudentId = id
                    ,State = 0
                });
            db.SaveChanges();


            var model = db.ClassRequests.OrderByDescending(p => p.ClassDetailId).FirstOrDefault();

            return Ok(new SlotRequestedModel()
            {
                Id = model.ClassRequestId,
                StudentId = model.StudentId.GetValueOrDefault(4),
                State = transState(model.State.GetValueOrDefault(0)),
                ClassDetail = new ClassDetail()
                {
                    ClassDetailId = model.ClassDetailId.GetValueOrDefault(4),
                    ClassName = model.ClassDetail.ClassName,
                    RoomName = model.ClassDetail.Room.Name,
                    SubjectName = model.ClassDetail.Subject.Name,
                    TeacherName = model.ClassDetail.Teacher.Name,
                    TimeSlotModels = model.ClassDetail.ClassDetailSlots.ToList().Select(
                        timeslot => new ClassSlotModel()
                        {
                            Id = timeslot.ClassDetailSlotId,
                            ClassDetailId = model.ClassDetail.ClassDetailId,
                            Date = timeslot.DayOfWeek,
                            Time = ClassSlotModel.getTime(timeslot.StartTime.GetValueOrDefault()
                            ,timeslot.EndTime.GetValueOrDefault())
                                
                        }).ToList()
                },
            });
            //todo add to database
//            var dummyClassDetail = ClassDetailsController.classDetailList[0];
//
//
//            var slotRequestedModel = new SlotRequestedModel()
//            {
//                Id = 10,
//                ClassDetail = dummyClassDetail,
//                State = SlotRequestedModel.WAITING_STATE,
//                StudentId = id
//            };
//
//            //todo change id here
//            slotRequestedmodels.Add(slotRequestedModel);
//
//
//
//            return Ok(slotRequestedmodels);
        }
    }
}