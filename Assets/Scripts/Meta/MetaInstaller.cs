using Zenject;

public class MetaInstaller : MonoInstaller<MetaInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<GameBoardHandler>().AsSingle();
    }
}
