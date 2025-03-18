using NUnit.Framework;
using Microsoft.AspNetCore.Routing;
using RamSoft_Task_Tool.Model;
using System;

namespace RamSoft_Task_Tool_Project
{
    [TestFixture]
    public class TaskServiceTests
    {
        private TaskService _taskService;

        [SetUp]
        public void SetUp()
        {
            _taskService = new TaskService();
        }

        [Test]
        public void AddTask_ShouldAddNewTask()
        {
            // Arrange
            var task = new TaskItem
            {
                Name = "Test Task",
                Description = "This is a test task",
                Deadline = DateTime.UtcNow.AddDays(1)
            };

            // Act
            var result = _taskService.AddTask(task);

            // Assert
            Assert.IsNotNull(result.Id);
            Assert.AreEqual("Test Task", result.Name);
        }

        [Test]
        public void EditTask_ShouldUpdateTaskDetails()
        {
            // Arrange
            var task = _taskService.AddTask(new TaskItem
            {
                Name = "Old Task",
                Description = "Old Description",
                Deadline = DateTime.UtcNow.AddDays(1)
            });

            var updatedTask = new TaskItem
            {
                Name = "Updated Task",
                Description = "Updated Description",
                Deadline = DateTime.UtcNow.AddDays(2)
            };

            // Act
            var result = _taskService.EditTask(task.Id, updatedTask);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Updated Task", result.Name);
        }

        [Test]
        public void DeleteTask_ShouldRemoveTask()
        {
            // Arrange
            var task = _taskService.AddTask(new TaskItem
            {
                Name = "Task to Delete",
                Description = "To be removed"
            });

            // Act
            var result = _taskService.DeleteTask(task.Id);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNull(_taskService.GetTaskById(task.Id));
        }

        [Test]
        public void GetTaskById_ShouldReturnCorrectTask()
        {
            // Arrange
            var task = _taskService.AddTask(new TaskItem
            {
                Name = "Find Me",
                Description = "Retrieve this task"
            });

            // Act
            var result = _taskService.GetTaskById(task.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Find Me", result.Name);
        }
    }
}