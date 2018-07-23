using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMangerWebApi.Models
{
    public class Account
    {
        public string UserId { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public int AuthorizationLevel { get; set; }

        public static readonly int AUTHORIZATION_LEVEL_ADMIN = 0;
        public static readonly int AUTHORIZATION_LEVEL_STUDENT = 1;

    }
}