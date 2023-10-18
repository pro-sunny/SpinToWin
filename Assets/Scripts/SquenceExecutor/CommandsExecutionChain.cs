using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public interface ICommandsExecutionChain
{
    ICommandsExecutionChain ExecuteNext<T>() where T : IExecutableCommand;
}

public class CommandsExecutionChain : ICommandsExecutionChain
{
    private DiContainer _container;
    private List<IExecutableCommand> _queue = new List<IExecutableCommand>();

    private IExecutableCommand _currentCommand;
    
    public CommandsExecutionChain(IExecutableCommand currentCommand, DiContainer container)
    {
        _currentCommand = currentCommand;
        _container = container;
        Start(_currentCommand);
    }
    
    public ICommandsExecutionChain ExecuteNext<T>() where T : IExecutableCommand
    {
        _queue.Add(_container.Instantiate<T>());
        ExecuteNextCommand();
        return this;
    }

    private void OnComplete()
    {
        _currentCommand = null;
        ExecuteNextCommand();
    }

    private void ExecuteNextCommand()
    {
        if (_queue.Any() && _currentCommand == null)
        {
            _currentCommand = _queue[0];
            _queue.RemoveAt(0);
            Start(_currentCommand);
        }
    }

    private void Start(IExecutableCommand currentCommand)
    {
        currentCommand.Execute(OnComplete);
        Debug.Log( currentCommand + " executed");
    }
}