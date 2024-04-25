# LiteNinja Commands Library

LiteNinja Commands is a C# library that provides a simple and efficient way to manage and execute commands in your application. It is particularly useful in scenarios where you need to decouple the execution of a task from the UI or other parts of your application.

## Getting Started

To use the LiteNinja Commands library, you first need to install it. You can do this by adding it as a dependency in your project.

## Dependencies

- [LiteNinja Injection](https://github.com/sponticelli/LiteNinja-Injection.git)
- [UniTask](https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask)

## Usage

### Creating a Command

Commands in LiteNinja are classes that derive from the `ACommand` or `AAsyncCommand` base classes. Here's an example of a simple command:

```csharp
public class MyCommand : ACommand
{
    protected override void Run()
    {
        // Your command logic goes here
    }
}
```

For asynchronous commands, you can use the `AAsyncCommand` base class and override the `Run` method:

```csharp
public class MyAsyncCommand : AAsyncCommand
{
    protected override UniTask Run(CancellationToken cancellationToken)
    {
        // Your asynchronous command logic goes here
        return UniTask.CompletedTask;
    }
}
```

### Executing a Command

To execute a command, you first need to create an instance of it. This is where the `CommandFactory` comes in. You can use the `Get<T>` method to create a new instance of a command:

```csharp
var commandFactory = new CommandFactory(new Injector());
var myCommand = commandFactory.Get<MyCommand>();
myCommand.Execute();
```

For asynchronous commands, you can use the `ExecuteAsync` method to execute the command:

```csharp
var myAsyncCommand = commandFactory.Get<MyAsyncCommand>();
await myAsyncCommand.ExecuteAsync();
```

## Error Handling

If there's an error while creating or executing a command, the library will throw an exception. You can catch these exceptions and handle them in a way that makes sense for your application.