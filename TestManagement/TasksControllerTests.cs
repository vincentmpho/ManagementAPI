using ManagementAPI.Controllers;
using ManagementAPI.Model;
using ManagementAPI.Repository.Interface;
using Moq;

public class TasksControllerTests
{
    private readonly Mock<IMyTasks> MyTasks;
    public TasksControllerTests()
    {
        MyTasks = new Mock<IMyTasks>();
    }
    [Fact]
    public void GetMyTaskList_MyTaskList()
    {
        //arrange
        var MyTaskList = new List<MyTask>()
        {
            new MyTask { Id = 1, Description="Test", IsCompleted = true},
            new MyTask { Id = 2, Description="Test", IsCompleted = false},
            new MyTask { Id = 3, Description="Test", IsCompleted = true},
            new MyTask { Id = 4, Description="Test", IsCompleted = false},
            };

        MyTasks.Setup(x => x.GetTaskListAsync())
            .Returns(MyTaskList);
        var tasksController = new TasksController(MyTasks.Object);
        //act
        var Result = tasksController.TasksList();

        //assert
        Assert.NotNull(Result);
        Assert.Equal(MyTaskList.Count(), Result.Count());
        Assert.Equal(MyTaskList.ToString(), Result.ToString());
        Assert.True(MyTaskList.Equals(Result));

        //Assert.Equal(3, MyTaskList.Count());
    }

    [Theory]

    [InlineData(1, true)]
    [InlineData(2, false)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    public void GetTaskById_ReturnsTask(int taskId, bool isCompleted)
    {
        // Arrange
        var MyTaskList = new List<MyTask>()
        {
            new MyTask { Id = 1, Description = "Test", IsCompleted = true },
            new MyTask { Id = 2, Description = "Test", IsCompleted = false },
            new MyTask { Id = 3, Description = "Test", IsCompleted = true },
            new MyTask { Id = 4, Description = "Test", IsCompleted = false },
        };

        MyTasks.Setup(x => x.GetTaskListByIdAsync(taskId)).Returns(MyTaskList.Find(t => t.Id == taskId));
        var tasksController = new TasksController(MyTasks.Object);

        // Act
        var productResult = tasksController.GetTaskById(taskId);

        // Assert
        Assert.NotNull(productResult);
        Assert.Equal(taskId, productResult.Id);
        Assert.Equal(isCompleted, productResult.IsCompleted);
    }


    [Fact]
    public void GetTaskById_MyTask()
    {
        //arrange
        var myTaskList = new List<MyTask>()
        {
            new MyTask { Id = 1, Description="Test" , IsCompleted =true},
            new MyTask { Id = 2, Description="Test", IsCompleted = true},
            new MyTask { Id = 3, Description="Test", IsCompleted = false},
            new MyTask { Id = 4, Description="Test", IsCompleted = false},
            };

        MyTasks.Setup(x => x.GetTaskListByIdAsync(2))
                .Returns(myTaskList[1]);
        var tasksController = new TasksController(MyTasks.Object);
        //act
        var productResult = tasksController.GetTaskById(2);
        //assert
        Assert.NotNull(productResult);
        Assert.Equal(myTaskList[1].Id, productResult.Id);
        Assert.True(myTaskList[1].Id == productResult.Id);
    }

    [Fact]
    public void AddTask_ReturnsAddedTask()
    {
        // Arrange
        var newTask = new MyTask { Id = 5, Description = "New Task", IsCompleted = false };
        MyTasks.Setup(x => x.AddTaskAsync(newTask)).Returns(newTask);
        var tasksController = new TasksController(MyTasks.Object);

        // Act
        var productResult = tasksController.AddTask(newTask);

        // Assert
        Assert.NotNull(productResult);
        Assert.Equal(newTask.Id, productResult.Id);
        Assert.Equal(newTask.Description, productResult.Description);
        Assert.Equal(newTask.IsCompleted, productResult.IsCompleted);
    }


    [Fact]
    public void UpdateTask_ReturnsUpdatedTask()
    {
        // Arrange
        var updatedTask = new MyTask { Id = 1, Description = "Updated Task", IsCompleted = true };
        MyTasks.Setup(x => x.UpdateTaskAsync(updatedTask)).Returns(updatedTask);
        var tasksController = new TasksController(MyTasks.Object);

        // Act
        var productResult = tasksController.UpdateTask(updatedTask);

        // Assert
        Assert.NotNull(productResult);
        Assert.Equal(updatedTask.Id, productResult.Id);
        Assert.Equal(updatedTask.Description, productResult.Description);
        Assert.Equal(updatedTask.IsCompleted, productResult.IsCompleted);
    }

    [Fact]
    public void DeleteTask_ReturnsSuccessOrNotFound()
    {
        // Arrange
        MyTasks.Setup(x => x.DeleteTaskAsync(1)).Returns(true); // Successful deletion
        MyTasks.Setup(x => x.DeleteTaskAsync(5)).Returns(false); // Unsuccessful deletion
        var tasksController = new TasksController(MyTasks.Object);

        // Act
        var successResult = tasksController.DeleteTask(1);
        var notFoundResult = tasksController.DeleteTask(5);

        // Assert
        Assert.True(successResult);
        Assert.False(notFoundResult);
    }

}