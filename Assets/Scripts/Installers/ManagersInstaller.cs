using Zenject;

public class ManagersInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().AsSingle().NonLazy();
        Container.Bind<ScreensManager>().AsSingle().NonLazy();
        Container.Bind<GameSavesManager>().AsSingle().NonLazy();

        Container.Bind<FileSaverBase>().To<JsonFileSaver>().AsSingle();
    }
}