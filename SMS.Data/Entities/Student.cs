using SMS.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SMS.Data.Entities
{
    public class Student : AuditableEntity
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime? JoiningDate { get; set; }
        //public int ParentId { get; set; }

    }
}
