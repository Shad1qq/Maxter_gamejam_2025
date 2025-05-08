using Zenject;

public class UntitledInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InputPlayer>().FromNew().AsSingle();
    }
}