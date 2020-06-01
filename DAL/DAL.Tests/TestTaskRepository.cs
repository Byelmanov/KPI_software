using System;
using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
namespace DAL.Tests
{
    public class TestTaskRepository
        : BaseRepository<Task>
    {
        public TestTaskRepository(DbContext context)
            : base(context)
        {
        }
    }
}
