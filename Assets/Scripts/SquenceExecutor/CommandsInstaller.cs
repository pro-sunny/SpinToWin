using Zenject;

public class CommandsInstaller : MonoInstaller<CommandsInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<ICommandsExecutor>().To<CommandsExecutor>().AsSingle();
    }
}
