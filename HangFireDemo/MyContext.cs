using HangFireDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo
{
    public class MyContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public MyContext(DbContextOptions<MyContext> options)
          : base(options)
        {
        }
    }



}
