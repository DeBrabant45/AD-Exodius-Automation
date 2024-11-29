using AD.Exodius.Utility.Tasks;

namespace AD.Exodius.Utility.UnitTests.Tasks;

public class ThenTests
{
    [Fact]
    public async Task Then_Should_ChainTasksAndReturnTransformedResult()
    {
        Task<int> initialTask = Task.FromResult(5);
        Func<int, Task<string>> nextJob = result => Task.FromResult($"Result is {result}");

        var finalResult = await initialTask.Then(nextJob);

        finalResult.Should().Be("Result is 5");
    }

    [Fact]
    public async Task Then_Should_ChainTasks_WhenNextJobIsNull()
    {
        Task<int> initialTask = Task.FromResult(10);
        Func<int, Task> nextJob = null;

        var finalResult = await initialTask.Then(nextJob);

        finalResult.Should().Be(10);
    }

    [Fact]
    public async Task Then_Should_ChainTasks_WhenNextJobIsVoid()
    {
        Task<int> initialTask = Task.FromResult(20);
        bool wasCalled = false;
        Func<int, Task> nextJob = result =>
        {
            wasCalled = true;
            return Task.CompletedTask;
        };

        var finalResult = await initialTask.Then(nextJob);

        wasCalled.Should().BeTrue();
        finalResult.Should().Be(20);
    }

    [Fact]
    public async Task Then_Should_HandleExceptionFromNextJob()
    {
        Task<int> initialTask = Task.FromResult(30);
        Func<int, Task<string>> nextJob = _ => throw new InvalidOperationException("Test exception");

        Func<Task> act = async () => await initialTask.Then(nextJob);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Test exception");
    }

    [Fact]
    public async Task Then_Should_HandleExceptionFromInitialTask()
    {
        Task<int> initialTask = Task.FromException<int>(new InvalidOperationException("Initial task exception"));
        Func<int, Task<string>> nextJob = result => Task.FromResult($"Result is {result}");

        Func<Task> act = async () => await initialTask.Then(nextJob);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Initial task exception");
    }

    [Fact]
    public async Task Then_SyncJob_Should_ChainTasksAndReturnTransformedResult()
    {
        int initialValue = 5;
        Func<int, Task<string>> nextJob = result => Task.FromResult($"Result is {result}");

        var finalResult = await initialValue.Then(nextJob);

        finalResult.Should().Be("Result is 5");
    }

    [Fact]
    public async Task Then_SyncJob_Should_HandleNullNextJob_ForValueResult()
    {
        int initialValue = 10;
        Func<int, Task> nextJob = null;

        Func<Task> act = async () => await initialValue.Then(nextJob);

        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task Then_SyncJob_Should_ChainTasks_WhenNextJobIsVoid()
    {
        int initialValue = 20;
        bool wasCalled = false;
        Func<int, Task> nextJob = result =>
        {
            wasCalled = true;
            return Task.CompletedTask;
        };

        await initialValue.Then(nextJob);

        wasCalled.Should().BeTrue();
    }
}
