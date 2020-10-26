using SMS.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Data.Entities
{
    public class Student : AuditableEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime JoiningDate { get; set; }
        //public int ParentId { get; set; }

    }
}
