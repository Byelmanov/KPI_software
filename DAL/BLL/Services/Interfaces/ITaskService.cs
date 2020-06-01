using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<TaskDTO> GetTasks(int page);
    }
}
