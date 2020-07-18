using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Data
{
    public class SMSContext : DbContext
    {
        public SMSContext(DbContextOptions<SMSContext> options): base(options)
        {

        }
    }
}
