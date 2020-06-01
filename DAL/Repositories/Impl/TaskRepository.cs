using System;
using Catalog.DAL.Repositories.Interfaces;
using DAL.EF;
using DAL.Entities;

namespace DAL.Repositories.Impl
{
    public class TaskRepository
        : BaseRepository<Task>, ITaskRepository
    {
        internal TaskRepository(TaskContext context)
            : base(context)
        {
        }
    }
}
