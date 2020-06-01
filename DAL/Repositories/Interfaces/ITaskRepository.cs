using System;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface ITaskRepository
        : IRepository<Task>
    {
        void Find(Func<Task, bool> func, int v1, int v2);
    }
}
