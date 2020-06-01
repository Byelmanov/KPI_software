using System;
using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]

        public void Create_InputStreetInstance_CalledAddMethodOfDBSetWithStreetInstance()

        {

            // Arrange

            DbContextOptions opt = new DbContextOptionsBuilder<TaskContext>()

                .Options;

            var mockContext = new Mock<TaskContext>(opt);

            var mockDbSet = new Mock<DbSet<Task>>();

            mockContext

               .Setup(context =>

                    context.Set<Task>(
                    ))
               .Returns(mockDbSet.Object);

            var repository = new TestTaskRepository(mockContext.Object);
            Task expectedTask = new Mock<Task>().Object;
            repository.Create(expectedTask);

            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedTask
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<TaskContext>()
                .Options;
            var mockContext = new Mock<TaskContext>(opt);
            var mockDbSet = new Mock<DbSet<Task>>();
            mockContext
                .Setup(context =>
                    context.Set<Task>(
                       ))
                .Returns(mockDbSet.Object);
            Task expectedStreet = new Task() { TaskId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.TaskId))
                     .Returns(expectedStreet);
            var repository = new TestTaskRepository(mockContext.Object);
    
            //Act
            var actualStreet = repository.Get(expectedStreet.TaskId);
      
            // Assert
            mockDbSet.Verify(
               dbSet => dbSet.Find(
                   expectedStreet.TaskId
                  ), Times.Once());
            Assert.Equal(expectedStreet, actualStreet);
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<TaskContext>()
                .Options;
            var mockContext = new Mock<TaskContext>(opt);
            var mockDbSet = new Mock<DbSet<Task>>();
            mockContext
               .Setup(context =>
                    context.Set<Task>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new TestTaskRepository(mockContext.Object);
            Task expectedStreet = new Task() { TaskId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.TaskId))
                     .Returns(expectedStreet);
            //Act
            repository.Delete(expectedStreet.TaskId);
  
            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStreet.TaskId
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedStreet
                    ), Times.Once());
        }

}
}
