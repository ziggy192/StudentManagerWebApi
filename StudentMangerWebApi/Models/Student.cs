using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMangerWebApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ParentsPhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public bool IsMale { get; set; }
        public bool IsPaid { get; set; }

        public static Student DefaultStudent(int studentId)
        {
            return new Student()
            {
                Id = studentId,
                Name = "Nguyen Hoang Hai Dang",
                DateOfBirth = "19/02/1997",
                PhoneNumber = "0905456483",
                ParentsPhoneNumber = "0905167468",
                IsMale = true,
                IsPaid = true
            };
        }
    }
}