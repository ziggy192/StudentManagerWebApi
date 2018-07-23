using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentMangerWebApi.Models
{
    public class SlotRequestedModel
    {
        public static readonly string ACCEPTED_STATE = "accepted";
        public static readonly string DENIED_STATE = "denied";
        public static readonly string WAITING_STATE = "waiting";
        

        
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string State { get; set; }
        public ClassDetail ClassDetail { get; set; }

       
    }
}