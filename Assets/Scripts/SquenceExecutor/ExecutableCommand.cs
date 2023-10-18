using System;

public interface IExecutableCommand
{
    void Execute(Action OnComplete);
}

public abstract class ExecutableCommand : IExecutableCommand
{
    private bool suspended;

    private Action onComplete;

    public void Execute(Action onComplete)
    {
        ExecuteInternal();
        if (!suspended)
        {
            onComplete?.Invoke();
        }
        else
        {
            this.onComplete = onComplete;
        }
    }

    protected abstract void ExecuteInternal();

    protected void Suspend()
    {
        suspended = true;
    }

    protected void ReleaseAndComplete()
    {
        if (suspended)
        {
            suspended = false;
            onComplete?.Invoke();
        }
    }
}