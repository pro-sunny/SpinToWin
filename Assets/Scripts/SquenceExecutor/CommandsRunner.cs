using UnityEngine;
using Zenject;

public class CommandsRunner : MonoBehaviour
{
    private ICommandsExecutor _executor;
    
    [Inject]
    public void Contruct(ICommandsExecutor executor)
    {
        _executor = executor;
    }

    private void Start()
    {
        RunCommands();
    }

    private void RunCommands()
    {
        _executor.Execute<SavesInitCommand>()
            .ExecuteNext<RunMenuSceneCommand>()
            .ExecuteNext<UnloadBootSceneCommand>();
        // .ExecuteNext<InitGunsCommand>()
        // .ExecuteNext<HttpCheckCommand>()
        // .ExecuteNext<SavesInitCommand>();
    }
}