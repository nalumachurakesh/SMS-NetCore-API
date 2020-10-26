using Microsoft.EntityFrameworkCore;
using SMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Data
{
    //https://www.learnentityframeworkcore.com/migrations
    public class SMSContext : DbContext
    {
        public SMSContext(DbContextOptions<SMSContext> options) : base(options)
        {

        }

        public DbSet<Student> Student { get; set; }
    }
}
