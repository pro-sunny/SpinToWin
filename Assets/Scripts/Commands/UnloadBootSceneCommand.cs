using UnityEngine;
using UnityEngine.SceneManagement;

public class UnloadBootSceneCommand : ExecutableCommand
{
    protected override void ExecuteInternal()
    {
        Suspend();
        var asyncOperation = SceneManager.UnloadSceneAsync("Boot");
        asyncOperation.completed += ReleaseCommand;
        
    }

    private void ReleaseCommand(AsyncOperation asyncOperation)
    {
        ReleaseAndComplete();
    }
}