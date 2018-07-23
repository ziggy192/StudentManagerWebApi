using StudentMangerWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentMangerWebApi.Models.DTO;

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
            var slotRequestedList = slotRequestedmodels.Where(model => model.StudentId == id).ToList();

            return Ok(slotRequestedList);
        }

        private static bool checkStudentId(int studentId)
        {
            return true;
        }

        private static bool checkClassDetailID(int classId)
        {
            return true;
        }

        public IHttpActionResult PostFormRequestByStudentId(int id, SlotRequestPostDTO slotRequestPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //check student id
            if (!checkStudentId(id))
            {
                return BadRequest();
            }

            //check class detailId
            if (!checkClassDetailID(slotRequestPostDto.ClassDetailId))
            {
                return BadRequest();
            }

            //todo add to database
            var dummyClassDetail = ClassDetailsController.classDetailList[0];


            var slotRequestedModel = new SlotRequestedModel()
            {
                Id = 10,
                ClassDetail = dummyClassDetail,
                State = SlotRequestedModel.WAITING_STATE,
                StudentId = id
            };

            //todo change id here
            slotRequestedmodels.Add(slotRequestedModel);



            return Ok(slotRequestedmodels);
        }
    }
}