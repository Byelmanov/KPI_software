using System;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface ITaskRepository
        : IRepository<Task>
    {
    }
}
