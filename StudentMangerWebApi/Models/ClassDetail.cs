using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMangerWebApi.Models
{
    public class ClassDetail
    {
        public int ClassDetailId { get; set; }
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
        public string RoomName { get; set; }
        public string SubjectName { get; set; }

        public List<ClassSlotModel> TimeSlotModels { get; set; }


        public static ClassDetail DefaultInstance(string className)
        {
            return new ClassDetail()
            {
                ClassName = className,
                RoomName = "R101",
                TimeSlotModels = ClassSlotModel.DefaultTimeSlotModelList(1),
                TeacherName = "DangNHH",
                SubjectName = "English"
            };
        }
    }
}