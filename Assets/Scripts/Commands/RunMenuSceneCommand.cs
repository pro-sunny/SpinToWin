using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunMenuSceneCommand : ExecutableCommand
{
    protected override async void ExecuteInternal()
    {
        Suspend();

        var task = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Additive);
        while (!task.isDone)
        {
            await Task.Yield();
        }
        
        ReleaseAndComplete();
    }
}