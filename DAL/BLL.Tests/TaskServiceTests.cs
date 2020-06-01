using System;
using Xunit;
using System.Collections.Generic;
using BLL.Services.Interfaces;
using CCL.Security;
using BLL.Services.Impl;
using CCL.Security.Identity;
using Moq;
using DAL.UnitOfWork;
using DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;

namespace BLL.Tests
{
    public class TaskServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            IUnitOfWork nullUnitOfWork = null;

            Assert.Throws<ArgumentNullException>(() => new TaskService(nullUnitOfWork));
        }

        [Fact]
        public void GetTasks_ThrowMethodAccessException()
        {
            User user = new Admin(1, "test");
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            ITaskService taskService = new TaskService(mockUnitOfWork.Object);

            _ = Assert.ThrowsAsync<MethodAccessException>(() => taskService.GetTasks(0));
        }

        [Fact]
        public void GetTasks_TaskFromDAL_CorrectMappingToTaskDTO()
        {
            User user = new Developer(1, "test");
            SecurityContext.SetUser(user);
            var taskService = GetTaskService();

            var actualTaskDto = taskService.GetTasks(0).First();

            Assert.True(
                actualTaskDto.TaskId == 1
                && actualTaskDto.Title == "TODO something"
                );
        }

        ITaskService GetTaskService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedTask = new Task() { TaskId = 1, Title = "TODO againg"};
            var mockDbSet = new Mock<ITaskRepository>();
            mockDbSet.Setup(z =>
                z.Find(
                    It.IsAny<Func<Task, bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                  .Returns(
                    new List<Task>() { expectedTask }
                    );
            mockContext
                .Setup(context =>
                    context.Tasks)
                .Returns(mockDbSet.Object);

            ITaskService streetService = new TaskService(mockContext.Object);

            return streetService;
        }
    }
}
