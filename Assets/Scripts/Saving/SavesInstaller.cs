using Zenject;

public class SavesInstaller : MonoInstaller<SavesInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<SavesComposer>().AsSingle();
        Container.BindInterfacesTo<LocalIOWorker>().AsSingle();
        Container.BindInterfacesTo<SaveLoadHandler>().AsSingle();
        Container.BindInterfacesTo<JsonSaveSerializer>().AsSingle();
        
        Container.BindInterfacesTo<Wallet>().AsSingle();
    }
}
