using System;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.EF
{
    public class TaskContext
        : DbContext
    {
        public DbSet<Task> Phones { get; set; }

        public TaskContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
