using Zenject;

public interface ICommandsExecutor
{
    ICommandsExecutionChain Execute<T>() where T: IExecutableCommand;
}

public class CommandsExecutor : ICommandsExecutor
{
    private DiContainer _container;

    public CommandsExecutor(DiContainer container)
    {
        _container = container;
    }
    
    public ICommandsExecutionChain Execute<T>() where T : IExecutableCommand
    {
        return new CommandsExecutionChain(_container.Instantiate<T>(), _container);
    }
}