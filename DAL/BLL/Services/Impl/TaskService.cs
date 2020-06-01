using System;
using System.Collections.Generic;
using System.Text;
using BLL.Services.Interfaces;
using BLL.Services;
using DAL.UnitOfWork;
using BLL.DTO;
using CCL.Security;
using DAL.Entities;
using AutoMapper;

namespace BLL.Services.Impl
{
    public class TaskService
        : ITaskService
    {
        private readonly IUnitOfWork _database;

        public TaskService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        public IEnumerable<TaskDTO> GetTasks(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();

            // get all tasks
            var tasksEntities =
                _database
                    .Tasks;
                    
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Task, TaskDTO>()
                    ).CreateMapper();
            var tasksDto =
                mapper
                    .Map<IEnumerable<Task>, List<TaskDTO>>(
                        tasksEntities);
            return tasksDto;
        }

        public void AddTask(TaskDTO task)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            validate(task);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, Task>()).CreateMapper();
            var taskEntity = mapper.Map<TaskDTO, Task>(task);
            _database.Tasks.Create(taskEntity);
        }

        private void validate(TaskDTO task)
        {
            if (string.IsNullOrEmpty(task.Title))
            {
                throw new ArgumentException("You can't add task without title!");
            }
        }
    }
}
