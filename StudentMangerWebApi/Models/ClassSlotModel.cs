using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMangerWebApi.Models
{
    public class ClassSlotModel
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public int ClassDetailId { get; set; }

        public static List<ClassSlotModel> DefaultTimeSlotModelList(int classId)
        {
            var list = new List<ClassSlotModel>();
            list.Add(new ClassSlotModel() {ClassDetailId = classId, Time = "15:00PM - 17:00PM", Date = "Monday"});
            list.Add(new ClassSlotModel() { ClassDetailId = classId, Time = "15:00PM - 17:00PM", Date = "Wednesday" });
            list.Add(new ClassSlotModel() { ClassDetailId = classId, Time = "15:00PM - 17:00PM", Date = "Friday" });
            return list;
        }

    }
}