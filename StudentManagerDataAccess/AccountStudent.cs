//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentManagerDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountStudent
    {
        public int AccountStudentId { get; set; }
        public string UserID { get; set; }
        public Nullable<int> StudentId { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Student Student { get; set; }
    }
}
